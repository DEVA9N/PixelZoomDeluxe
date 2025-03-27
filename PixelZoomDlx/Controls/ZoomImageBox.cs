using System;
using System.Drawing;
using System.Windows.Forms;
using A9N.PixelZoomDlx.Zoom;

namespace A9N.PixelZoomDlx.Controls
{
    internal sealed class ZoomImageBox : PictureBox
    {
        private readonly ZoomPainter _painter;
        private bool _isDisplayingImage;

        public ZoomImageBox()
        {
            _painter = new ZoomPainter(Size);
            _painter.NewImage += Painter_NewImage;
        }

        public bool CanZoomOut => _painter.ZoomFactor > ZoomFactor.Depth4;

        public bool CanZoomIn => _painter.ZoomFactor < ZoomFactor.Depth8;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _painter.Dispose();
            }
        }

        internal void DisplayImageAsync(Image image)
        {
            Action displayImage = () => { DisplayImage(image); };

            if (InvokeRequired)
            {
                BeginInvoke(displayImage);
            }
            else
            {
                displayImage();
            }
        }

        private void DisplayImage(Image image)
        {
            if (_isDisplayingImage)
            {
                return;
            }

            _isDisplayingImage = true;

            Image = image;

            _isDisplayingImage = false;
        }

        public void ZoomIn()
        {
            var nextFactor = (int)_painter.ZoomFactor * 2;

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                _painter.ZoomFactor = (ZoomFactor)nextFactor;
            }
        }

        public void ZoomOut()
        {
            var nextFactor = (ZoomFactor)((int)_painter.ZoomFactor / 2);

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                _painter.ZoomFactor = nextFactor;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            _painter.DisplaySize = Size;
        }

        private void Painter_NewImage(object sender, Image e)
        {
            DisplayImageAsync(e);
        }
    }
}