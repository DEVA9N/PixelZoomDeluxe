using System.Drawing;

namespace A9N.PixelZoomDlx.Zoom
{
    internal static class ZoomRectCalculator
    {
        internal static Rectangle GetGrabRectangle(Size displaySize, int zoomFactor)
        {
            // Grab rectangle settings
            var grabWidth = displaySize.Width / zoomFactor;
            var grabHeight = displaySize.Height / zoomFactor;

            return new Rectangle
            {
                Height = grabHeight,
                Width = grabWidth
            };
        }

        internal static Rectangle GetCursorRectangle(Size displaySize, int zoomFactor)
        {
            // Cross-hair settings
            var positionX = displaySize.Width / 2 - zoomFactor - 2;
            var positionY = displaySize.Height / 2 - zoomFactor - 2;
            var width = zoomFactor + 1;
            var height = zoomFactor + 1;

            return new Rectangle
            {
                X = positionX,
                Y = positionY,
                Height = height,
                Width = width
            };
        }
    }
}