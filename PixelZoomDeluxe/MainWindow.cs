using System.Reflection;
using A9N.PixelZoomDeluxe.Properties;
using A9N.PixelZoomDeluxe.Windows;

namespace A9N.PixelZoomDeluxe
{
    public partial class MainWindow : Form
    {
        private readonly MouseController _mouse;

        public MainWindow()
        {
            InitializeComponent();

            InitializePixelValueBoxes();

            AddVersionTitle();

            _mouse = new MouseController();

            UpdateZoomButtonsEnabled();
        }

        private void InitializePixelValueBoxes()
        {
            currentPixelBox.Text = Resources.MainWindow_Current;
            recentPixelBox.Text = Resources.MainWindow_Recent;
            distanceBox.Text = Resources.MainWindow_Distance;
        }

        private void AddVersionTitle()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;

            Text += $" - {version}";
        }

        private void UpdatePixelBoxValues()
        {
            // Assign outdated current values to recent pixel box control
            recentPixelBox.Position = currentPixelBox.Position;
            recentPixelBox.PixelColor = currentPixelBox.PixelColor;

            // Update current values
            currentPixelBox.Position = _mouse.GetPosition();
            currentPixelBox.PixelColor = _mouse.GetColor();

            distanceBox.Position = GetDistance(currentPixelBox.Position, recentPixelBox.Position);
        }

        public static Point GetDistance(Point currentPosition, Point recentPosition)
        {
            var varianceX = recentPosition.X.CompareTo(currentPosition.X);
            var varianceY = recentPosition.Y.CompareTo(currentPosition.Y);
            var lengthX = recentPosition.X - currentPosition.X + varianceX;
            var lengthY = recentPosition.Y - currentPosition.Y + varianceY;

            return new Point(lengthX, lengthY);
        }

        private void UpdateZoomButtonsEnabled()
        {
            buttonZoomIn.Enabled = pictureBox.CanZoomIn;
            buttonZoomOut.Enabled = pictureBox.CanZoomOut;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            _mouse.ResetSpeed();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Modifiers != Keys.None)
            {
                // Don't use shortcuts to update the pixel values 
                // Shortcuts are reserved for copying values from the textboxes
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.M:
                    _mouse.ToggleMouseSpeed();
                    break;
                default:
                    UpdatePixelBoxValues();
                    break;
            }
        }

        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            pictureBox.ZoomOut();

            UpdateZoomButtonsEnabled();
        }

        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            pictureBox.ZoomIn();

            UpdateZoomButtonsEnabled();
        }

        private void checkBoxMouseSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMouseSpeed.Checked)
            {
                _mouse.ReduceSpeed();
            }
            else
            {
                _mouse.ResetSpeed();
            }
        }
    }
}
