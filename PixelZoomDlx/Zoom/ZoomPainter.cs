using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx.Zoom
{
    class ZoomPainter : IDisposable
    {
        private Size _displaySize;
        private Pen _cursorPen = new Pen(Color.Red);
        private SolidBrush _pixelBrush;
        private readonly Object _paintLock = new Object();
        private Task _task;
        private CancellationTokenSource _tokenSource;

        internal event EventHandler<Image> NewImage;

        public ZoomFactor ZoomFactor { get; set; }

        public ZoomPainter(Size displaySize)
        {
            this.ZoomFactor = ZoomFactor.Depth4;
            _displaySize = displaySize;
            _pixelBrush = new SolidBrush(Color.Black);

            StartProcessImageTask();
        }

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

        private void StartProcessImageTask()
        {
            _tokenSource = new CancellationTokenSource();
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

        private void ProcessImage()
        {
            var zoomFactor = (int)this.ZoomFactor;

            var grabRect = ZoomRectCalculator.GetGrabRectangle(_displaySize, zoomFactor);

            var cursorRect = ZoomRectCalculator.GetCursorRectangle(_displaySize, zoomFactor);

            var result = GetAccurateImage(_displaySize, grabRect, cursorRect, zoomFactor);

            NotifyNewImage(result);
        }

        private Image GetAccurateImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
        {
            var resultBitmap = new Bitmap(displaySize.Width, displaySize.Height);

            using (var sourceBitmap = new Bitmap(grabRect.Width, grabRect.Height))
            {
                using (var screenGraphics = Graphics.FromImage(sourceBitmap))
                {
                    var sourceX = Cursor.Position.X - grabRect.Width / 2;
                    var sourceY = Cursor.Position.Y - grabRect.Height / 2;

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

        private void NotifyNewImage(Image image)
        {
            NewImage?.Invoke(this, image);
        }

        public void SetDisplaySize(Size size)
        {
            lock (_paintLock)
            {
                _displaySize = size;
            }
        }


    }
}
