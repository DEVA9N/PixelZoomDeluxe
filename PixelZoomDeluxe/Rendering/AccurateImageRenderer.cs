using A9N.PixelZoomDeluxe.Extensions;

namespace A9N.PixelZoomDeluxe.Rendering
{
    internal sealed class AccurateImageRenderer : IImageRenderer
    {
        private readonly Pen _cursorPen = new(Color.Red);

        public void Dispose()
        {
            _cursorPen.Dispose();
        }

        public Image GetImage(Size displaySize, int zoomFactor)
        {
            var grabRect = displaySize.ToGrabRectangle(zoomFactor);
            var cursorRect = displaySize.ToCursorRectangle(zoomFactor);
            var result = GetImage(displaySize, grabRect, cursorRect, zoomFactor);

            return result;
        }

        private Image GetImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
        {
            var resultBitmap = new Bitmap(displaySize.Width, displaySize.Height);

            using (var sourceBitmap = new Bitmap(grabRect.Width, grabRect.Height))
            {
                // Copy screen to bitmap
                using (var screenGraphics = Graphics.FromImage(sourceBitmap))
                {
                    var sourceX = Cursor.Position.X - grabRect.Width / 2;
                    var sourceY = Cursor.Position.Y - grabRect.Height / 2;

                    screenGraphics.CopyFromScreen(sourceX, sourceY, 0, 0, grabRect.Size);
                }

                // Draw zoomed image
                using (var resultGraphics = Graphics.FromImage(resultBitmap))
                {
                    resultGraphics.Clear(Color.Black);

                    for (var ty = grabRect.Height - 1; ty > 0; ty--)
                    {
                        for (var tx = grabRect.Width - 1; tx > 0; tx--)
                        {
                            var resultPositionY = ((ty - 1) * zoomFactor) - 1;
                            var resultPositionX = ((tx - 1) * zoomFactor) - 1;

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
