using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx.Zoom
{
    internal class ZoomPainter : IDisposable
    {
        private readonly Pen _cursorPen = new Pen(Color.Red);
        private readonly SolidBrush _pixelBrush;
        private readonly Task _task;
        private readonly CancellationTokenSource _tokenSource;

        internal event EventHandler<Image> NewImage;

        public Size DisplaySize { get; set; }
        public ZoomFactor ZoomFactor { get; set; }

        public ZoomPainter(Size displaySize)
        {
            ZoomFactor = ZoomFactor.Depth4;
            DisplaySize = displaySize;
            _pixelBrush = new SolidBrush(Color.Black);
            _tokenSource = new CancellationTokenSource();
            _task = StartProcessImageTask(_tokenSource.Token);
        }

        public void Dispose()
        {
            // Cancel the image processing
            _tokenSource.Cancel();

            // Wait until the task really has been finished
            _task?.Wait();

            // Now dispose image related stuff
            _cursorPen?.Dispose();
            _pixelBrush?.Dispose();
        }

        private async Task StartProcessImageTask(CancellationToken token)
        {
            await Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    ProcessImage();
                }
            }, TaskCreationOptions.LongRunning);
        }

        private void ProcessImage()
        {
            var zoomFactor = (int)ZoomFactor;

            var grabRect = ZoomRectCalculator.GetGrabRectangle(DisplaySize, zoomFactor);

            var cursorRect = ZoomRectCalculator.GetCursorRectangle(DisplaySize, zoomFactor);

            var result = GetAccurateImage(DisplaySize, grabRect, cursorRect, zoomFactor);

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

                    for (var ty = grabRect.Height - 1; ty > 0; ty--)
                    {
                        for (var tx = grabRect.Width - 1; tx > 0; tx--)
                        {
                            var resultPositionY = (ty - 1) * zoomFactor - 1;
                            var resultPositionX = (tx - 1) * zoomFactor - 1;

                            _pixelBrush.Color = sourceBitmap.GetPixel(tx, ty);

                            resultGraphics.FillRectangle(_pixelBrush, resultPositionX, resultPositionY, zoomFactor, zoomFactor);
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
    }
}
