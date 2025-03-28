using System.Drawing;

namespace A9N.PixelZoomDlx.Rendering
{
    interface IImageRenderer
    {
        Image GetImage(Size displaySize, int zoomFactor);
    }
}
