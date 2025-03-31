namespace A9N.PixelZoomDeluxe.Rendering;

interface IImageRenderer : IDisposable
{
    Image GetImage(Size displaySize, int zoomFactor);
}