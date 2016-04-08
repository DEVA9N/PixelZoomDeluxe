using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx.Controls
{
    internal sealed class ZoomImageBox : PictureBox
    {
        private bool _isDisplayingImage;
        private readonly ZoomPainter _painter;

        public bool CanZoomOut
        {
            get { return _painter.ZoomFactor > ZoomFactor.Depth4; }
        }

        public bool CanZoomIn
        {
            get { return _painter.ZoomFactor < ZoomFactor.Depth8; }
        }

        public ZoomImageBox()
        {
            this._painter = new ZoomPainter(this.Size);
            this._painter.NewImage += Painter_NewImage;
        }

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
            Action displayImage = () =>
            {
                DisplayImage(image);
            };

            if (this.InvokeRequired)
            {
                this.BeginInvoke(displayImage);
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

            this.Image = image;

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

            _painter.SetDisplaySize(this.Size);
        }

        private void Painter_NewImage(object sender, ImageEventArgs e)
        {
            DisplayImageAsync(e.Image);
        }
    }
}
