using System;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using A9N.PixelZoomDlx.Rendering;

namespace A9N.PixelZoomDlx.Controls
{
    internal sealed class ZoomImageBox : PictureBox
    {
        private ZoomFactor _zoomFactor;
        private readonly AccurateImageRenderer _painter;
        private readonly CancellationTokenSource _tokenSource;
        private readonly IImageRenderer _renderer;
        [Flags]
        private enum ZoomFactor
        {
            Depth4 = 4,
            Depth8 = 8,
            Depth16 = 16,
        }

        public bool CanZoomOut => _zoomFactor > ZoomFactor.Depth4;
        public bool CanZoomIn => _zoomFactor < ZoomFactor.Depth16;

        public ZoomImageBox()
        {
            _zoomFactor = ZoomFactor.Depth4;
            _painter = new AccurateImageRenderer();
            _tokenSource = new CancellationTokenSource();
            _renderer = new AccurateImageRenderer();
            //_renderer = new FastImageRenderer();
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
                    Image = _renderer.GetImage(Size, (int)_zoomFactor);
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