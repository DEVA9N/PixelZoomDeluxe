using System;
using System.Drawing;

namespace A9N.PixelZoomDlx.Rendering
{
    interface IImageRenderer : IDisposable
    {
        Image GetImage(Size displaySize, int zoomFactor);
    }
}
