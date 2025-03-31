using System.Drawing;

namespace A9N.PixelZoomDeluxe.Extensions
{
    internal static class SizeExtension
    {
        internal static Rectangle ToGrabRectangle(this Size displaySize, int zoomFactor)
        {
            // Grab rectangle settings
            var grabWidth = displaySize.Width / zoomFactor;
            var grabHeight = displaySize.Height / zoomFactor;

            return new Rectangle(0, 0, grabWidth, grabHeight);
        }

        internal static Rectangle ToCursorRectangle(this Size displaySize, int zoomFactor)
        {
            // Cross-hair settings
            var positionX = displaySize.Width / 2 - zoomFactor - 2;
            var positionY = displaySize.Height / 2 - zoomFactor - 2;
            var size = zoomFactor + 1;

            return new Rectangle(positionX, positionY, size, size);
        }
    }
}