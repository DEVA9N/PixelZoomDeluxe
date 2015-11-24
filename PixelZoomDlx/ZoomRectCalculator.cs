using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace A9N.PixelZoomDlx
{
    static class ZoomRectCalculator
    {
        internal static Rectangle GetGrabRectangle(Size displaySize, int zoomFactor)
        {
            // Grab rectangle settings
            int grabWidth = (int)displaySize.Width / zoomFactor;
            int grabHeight = (int)displaySize.Height / zoomFactor;

            return new Rectangle
            {
                Height = grabHeight,
                Width = grabWidth,
            };
        }

        internal static Rectangle GetCursorRectangle(Size displaySize, int zoomFactor)
        {
            // Cross-hair settings
            int curserPosX = ((int)displaySize.Width / 2) - zoomFactor - 2;
            int curserPosY = ((int)displaySize.Height / 2) - zoomFactor - 2;
            int cursorWidth = zoomFactor + 1;
            int curserHeight = zoomFactor + 1;

            return new Rectangle
            {
                X = curserPosX,
                Y = curserPosY,
                Height = curserHeight,
                Width = cursorWidth,
            };
        }

      
    }
}