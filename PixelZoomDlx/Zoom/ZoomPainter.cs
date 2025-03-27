using System;
using System.Drawing;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx.Zoom
{
    internal sealed class ZoomPainter : IDisposable
    {
        private readonly Pen _cursorPen;
        private readonly SolidBrush _pixelBrush;

        public ZoomPainter()
        {
            _cursorPen = new Pen(Color.Red);
            _pixelBrush = new SolidBrush(Color.Black);
        }

        public void Dispose()
        {
            _cursorPen?.Dispose();
            _pixelBrush?.Dispose();
        }

        public Image GetZoomedImage(Size displaySize, int zoomFactor)
        {
            var grabRect = ZoomRectCalculator.GetGrabRectangle(displaySize, zoomFactor);
            var cursorRect = ZoomRectCalculator.GetCursorRectangle(displaySize, zoomFactor);
            var result = GetAccurateImage(displaySize, grabRect, cursorRect, zoomFactor);

            return result;
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
    }
}
