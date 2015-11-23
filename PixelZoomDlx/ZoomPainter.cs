using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx
{
    class ZoomPainter : IDisposable
    {
        #region Fields
        private Size _displaySize;
        private Pen _cursorPen = new Pen(Color.Red);
        private SolidBrush _pixelBrush;
        private readonly Object _paintLock = new Object();
        private Task _task;
        private CancellationTokenSource _tokenSource;

        #endregion

        #region Events
        /// <summary>
        /// Occurs when a new image is available.
        /// </summary>
        internal event ImageEventHandler NewImage;
        #endregion


        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomPainter"/> class.
        /// </summary>
        /// <param name="displaySize">The display size.</param>
        public ZoomPainter(Size displaySize)
        {
            this.ZoomFactor = ZoomFactor.Depth4;
            this.DisplaySize = displaySize;
            this._pixelBrush = new SolidBrush(Color.Black);

            this._tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            Action processImage = () =>
            {
                while (!token.IsCancellationRequested)
                {
                    ProcessImage();

                    Thread.Sleep(1);
                }
            };

            _task = Task.Factory.StartNew(processImage);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Dispose()
        {
            // Cancel the image processing
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource = null;
            }

            // Wait until the task really has been finished
            if (_task != null)
            {
                _task.Wait();
                _task = null;
            }

            // Now dispose image related stuff
            if (_cursorPen != null)
            {
                _cursorPen.Dispose();
                _cursorPen = null;
            }

            if (_pixelBrush != null)
            {
                _pixelBrush.Dispose();
                _pixelBrush = null;
            }
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        private void ProcessImage()
        {
            var zoomFactor = (int)this.ZoomFactor;

            var grabRect = ZoomRectCalculator.GetGrabRectangle(_displaySize, zoomFactor);

            var cursorRect = ZoomRectCalculator.GetCursorRectangle(_displaySize, zoomFactor);

            var result = GetAccurateImage(_displaySize, grabRect, cursorRect, zoomFactor);

            NotifyNewImage(result);
        }

        /// <summary>
        /// Display image. This routine is slow and very little optimized. But it's accurate and
        /// fast enough for normal computers.
        /// </summary>
        private Image GetAccurateImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
        {
            var resultBitmap = new Bitmap(displaySize.Width, displaySize.Height);

            using (var sourceBitmap = new Bitmap(grabRect.Width, grabRect.Height))
            {
                using (var screenGraphics = Graphics.FromImage(sourceBitmap))
                {
                    var sourceX = Cursor.Position.X - grabRect.Width/2;
                    var sourceY = Cursor.Position.Y - grabRect.Height/2;

                    screenGraphics.CopyFromScreen(sourceX, sourceY, 0, 0, grabRect.Size);
                }

                using (var resultGraphics = Graphics.FromImage(resultBitmap))
                {
                    resultGraphics.Clear(Color.Black);

                    for (int ty = grabRect.Height - 1; ty > 0; ty--)
                    {
                        for (int tx = grabRect.Width - 1; tx > 0; tx--)
                        {
                            int resultPositionY = (ty - 1) * zoomFactor - 1;
                            int resultPositionX = (tx - 1) * zoomFactor - 1;

                            _pixelBrush.Color = sourceBitmap.GetPixel(tx, ty);

                            resultGraphics.FillRectangle(_pixelBrush,
                                resultPositionX,
                                resultPositionY,
                                zoomFactor,
                                zoomFactor);
                        }
                    }

                    // Draw cursor
                    resultGraphics.DrawRectangle(_cursorPen, cursorRect);
                }
            }

            return resultBitmap;
        }

        /// <summary>
        /// Notifies the new image.
        /// </summary>
        /// <param name="image">The image.</param>
        private void NotifyNewImage(Image image)
        {
            NewImage?.Invoke(this, new ImageEventArgs(image));
        }

        public void ZoomIn()
        {
            var nextFactor = (int)ZoomFactor * 2;

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                ZoomFactor = (ZoomFactor)nextFactor;
            }
        }

        public void ZoomOut()
        {
            var nextFactor = (ZoomFactor)((int)ZoomFactor / 2);

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                ZoomFactor = nextFactor;
            }
        }
        #endregion

        #region Properties

        public bool CanZoomOut
        {
            get { return this.ZoomFactor > ZoomFactor.Depth2; }
        }

        public bool CanZoomIn
        {
            get { return this.ZoomFactor < ZoomFactor.Depth8; }
        }

        /// <summary>
        /// Gets or sets the display size.
        /// </summary>
        /// <value>The display size.</value>
        public Size DisplaySize
        {
            get { return _displaySize; }
            set
            {
                lock (_paintLock)
                {
                    this._displaySize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the zoom factor.
        /// </summary>
        /// <value>The zoom factor.</value>
        public ZoomFactor ZoomFactor { get; private set; }
        #endregion

  
    }
}
