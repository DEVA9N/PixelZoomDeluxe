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
        private Size displaySize;
        private Pen cursorPen = new Pen(Color.Red);
        private SolidBrush pixelBrush;
        private Object paintLock = new Object();
        private Task task;
        private CancellationTokenSource tokenSource;
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
            this.AccurateImage = true;
            this.ZoomFactor = ZoomFactor.Depth4;
            this.DisplaySize = displaySize;

            this.pixelBrush = new SolidBrush(Color.Black);

            this.tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            Action processImage = () =>
            {
                while (!token.IsCancellationRequested)
                {
                    ProcessImage();
                }
            };

            task = Task.Factory.StartNew(processImage);
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
            if (tokenSource != null)
            {
                tokenSource.Cancel();
                tokenSource = null;
            }

            // Wait until the task really has been finished
            if (task != null)
            {
                task.Wait();
                task = null;
            }

            // Now dispose image related stuff
            if (cursorPen != null)
            {
                cursorPen.Dispose();
                cursorPen = null;
            }

            if (pixelBrush != null)
            {
                pixelBrush.Dispose();
                pixelBrush = null;
            }
        }

        /// <summary>
        /// Processes the image.
        /// </summary>
        private void ProcessImage()
        {
            var zoomFactor = (int)this.ZoomFactor;

            // Grab rectangle settings
            int grabWidth = displaySize.Width / zoomFactor;
            int grabHeight = displaySize.Height / zoomFactor;
            var grabRect = new Rectangle(0, 0, grabWidth, grabHeight);

            // Cross-hair settings
            int curserPosX = (displaySize.Width / 2) - zoomFactor - 2;
            int curserPosY = (displaySize.Height / 2) - zoomFactor - 2;
            int cursorWidth = zoomFactor + 1;
            int curserHeight = zoomFactor + 1;
            var cursorRect = new Rectangle(curserPosX, curserPosY, cursorWidth, curserHeight);

            Image result = null;

            if (AccurateImage)
            {
                result = GetAccurateImage(displaySize, grabRect, cursorRect, zoomFactor);
            }
            else
            {
                result = GetFastImage(displaySize, grabRect, cursorRect);
            }

            NotifyNewImage(result);
        }

        /// <summary>
        /// Display image. This routine is slow and very little optimized. But it's accurate and
        /// fast enough for normal computers.
        /// </summary>
        private Image GetAccurateImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
        {
            Bitmap sourceBitmap = new Bitmap(grabRect.Width, grabRect.Height);
           
            using (Graphics screenGraphics = Graphics.FromImage(sourceBitmap))
            {
                screenGraphics.CopyFromScreen(Cursor.Position.X - grabRect.Width / 2, Cursor.Position.Y - grabRect.Height / 2, 0, 0, grabRect.Size);
            }

            // Create ouput
            Bitmap resultBitmap = new Bitmap(displaySize.Width, displaySize.Height);
            
            using (Graphics resultGraphics = Graphics.FromImage(resultBitmap))
            {
                resultGraphics.Clear(Color.Black);

                for (int ty = grabRect.Height - 1; ty > 0; ty--)
                {
                    for (int tx = grabRect.Width - 1; tx > 0; tx--)
                    {
                        int resultPositionY = (ty - 1) * zoomFactor - 1;
                        int resultPositionX = (tx - 1) * zoomFactor - 1;

                        pixelBrush.Color = sourceBitmap.GetPixel(tx, ty);

                        resultGraphics.FillRectangle(pixelBrush, resultPositionX, resultPositionY, zoomFactor, zoomFactor);
                    }
                }

                // Draw cursor
                resultGraphics.DrawRectangle(cursorPen, cursorRect);
            }

            return resultBitmap;
        }


        /// <summary>
        /// This is an try for a fast image display. The quality is very poor due to
        /// much aliasing or something similiar. 
        /// </summary>
        private Image GetFastImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect)
        {
            Bitmap screenGrabBitmap = new Bitmap(grabRect.Width, grabRect.Height);
            Graphics screenGrabGraphics = Graphics.FromImage(screenGrabBitmap);
            screenGrabGraphics.CopyFromScreen(Cursor.Position.X - grabRect.Width / 2, Cursor.Position.Y - grabRect.Height / 2, 0, 0, grabRect.Size);
            screenGrabGraphics.Dispose();

            // Create ouput
            Bitmap displayBitmap = new Bitmap(displaySize.Width, displaySize.Height);
            Graphics displayGraphics = Graphics.FromImage(displayBitmap);

            displayGraphics.Clear(Color.Black);
            displayGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            displayGraphics.DrawImage(screenGrabBitmap,
                new Rectangle(0, 0, displaySize.Width, displaySize.Height),
                new Rectangle(0, 0, grabRect.Width, grabRect.Height),
                GraphicsUnit.Pixel);

            // Draw cursor
            displayGraphics.DrawRectangle(cursorPen, cursorRect);
            displayGraphics.Dispose();

            return displayBitmap;
        }

        /// <summary>
        /// Notifies the new image.
        /// </summary>
        /// <param name="image">The image.</param>
        private void NotifyNewImage(Image image)
        {
            if (NewImage != null)
            {
                NewImage(this, new ImageEventArgs(image));
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the accurate image.
        /// </summary>
        /// <value>The accurate image.</value>
        public bool AccurateImage { get; set; }

        /// <summary>
        /// Gets or sets the display size.
        /// </summary>
        /// <value>The display size.</value>
        public Size DisplaySize
        {
            get { return displaySize; }
            set
            {
                lock (paintLock)
                {
                    this.displaySize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the zoom factor.
        /// </summary>
        /// <value>The zoom factor.</value>
        public ZoomFactor ZoomFactor { get; set; }
        #endregion
    }
}
