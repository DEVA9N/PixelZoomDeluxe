using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using A9N.PixelZoomDlx.Zoom;

namespace A9N.PixelZoomDlx.Controls
{
    internal sealed class ZoomImageBox : PictureBox
    {
        private ZoomFactor _zoomFactor;
        private readonly ZoomPainter _painter;
        private readonly CancellationTokenSource _tokenSource;

        public bool CanZoomOut => _zoomFactor > ZoomFactor.Depth4;
        public bool CanZoomIn => _zoomFactor < ZoomFactor.Depth8;
        
        public ZoomImageBox()
        {
            _zoomFactor = ZoomFactor.Depth4;
            _painter = new ZoomPainter();
            _tokenSource = new CancellationTokenSource();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            StartImageProcessing(_tokenSource.Token);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _tokenSource.Cancel();
                _painter.Dispose();
            }
        }

        private async Task StartImageProcessing(CancellationToken token)
        {
            await Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Image = _painter.GetZoomedImage(Size, (int)_zoomFactor);
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void ZoomIn()
        {
            var nextFactor = (int)_zoomFactor * 2;

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                _zoomFactor = (ZoomFactor)nextFactor;
            }
        }

        public void ZoomOut()
        {
            var nextFactor = (ZoomFactor)((int)_zoomFactor / 2);

            if (Enum.IsDefined(typeof(ZoomFactor), nextFactor))
            {
                _zoomFactor = nextFactor;
            }
        }
    }
}