using A9N.PixelZoomDlx.Zoom;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx.Rendering
{
    internal sealed class AccurateImageRenderer : IImageRenderer, IDisposable
    {
        private readonly Pen _cursorPen;

        public AccurateImageRenderer()
        {
            _cursorPen = new Pen(Color.Red);
        }

        public void Dispose()
        {
            _cursorPen?.Dispose();
        }

        public Image GetImage(Size displaySize, int zoomFactor)
        {
            var grabRect = displaySize.ToGrabRectangle(zoomFactor);
            var cursorRect = displaySize.ToCursorRectangle(zoomFactor);
            var result = GetImage(displaySize, grabRect, cursorRect, zoomFactor);

            return result;
        }

        public Image GetImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
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

                            using (var pixelBrush = new SolidBrush(sourceBitmap.GetPixel(tx, ty)))
                            {
                                resultGraphics.FillRectangle(pixelBrush, resultPositionX, resultPositionY, zoomFactor, zoomFactor);
                            }
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
