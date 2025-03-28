using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using A9N.PixelZoomDlx.Extensions;

namespace A9N.PixelZoomDlx.Rendering
{
    public sealed class FastImageRenderer : IImageRenderer, IDisposable
    {
        private readonly Pen _cursorPen;

        public FastImageRenderer()
        {
            _cursorPen = new Pen(Color.DeepSkyBlue);
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

        /// <summary>
        /// This is an try for a fast image display. The quality is very poor due to
        /// much aliasing or something similar. 
        /// </summary>
        public Image GetImage(Size displaySize, Rectangle grabRect, Rectangle cursorRect, int zoomFactor)
        {
            using (var screenGrabBitmap = new Bitmap(grabRect.Width, grabRect.Height))
            {
                using (var screenGrabGraphics = Graphics.FromImage(screenGrabBitmap))
                {
                    screenGrabGraphics.CopyFromScreen(Cursor.Position.X - grabRect.Width / 2, Cursor.Position.Y - grabRect.Height / 2, 0, 0, grabRect.Size);

                    // Create output
                    using (var displayBitmap = new Bitmap(displaySize.Width, displaySize.Height))
                    {
                        using (var displayGraphics = Graphics.FromImage(displayBitmap))
                        {
                            displayGraphics.Clear(Color.Black);
                            displayGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                            displayGraphics.DrawImage(screenGrabBitmap,
                                new Rectangle(0, 0, displaySize.Width, displaySize.Height),
                                new Rectangle(0, 0, grabRect.Width, grabRect.Height),
                                GraphicsUnit.Pixel);

                            // Draw cursor
                            displayGraphics.DrawRectangle(_cursorPen, cursorRect);

                            return (Image)displayBitmap.Clone();
                        }
                    }
                }
            }
        }
    }
}
