using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using A9N.PixelZoomDlx.Properties;
using A9N.PixelZoomDlx.Windows;

namespace A9N.PixelZoomDlx
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
            this.currentPixelBox.Text = Resources.MainWindow_Current;
            this.recentPixelBox.Text = Resources.MainWindow_Recent;
            this.distanceBox.Text = Resources.MainWindow_Distance;
        }

        private void AddVersionTitle()
        {
            try
            {
                var version = ApplicationDeployment.CurrentDeployment.CurrentVersion;

                this.Text += $" - {version}";
            }
            catch (Exception e)
            {
                // Throws exception if application is not deployed
            }
        }

        private void UpdatePixelBoxValues()
        {
            // Assing outdated current values to recent pixel box control
            recentPixelBox.Position = currentPixelBox.Position;
            recentPixelBox.PixelColor = currentPixelBox.PixelColor;

            // Update current values
            currentPixelBox.Position = _mouse.GetPosition();
            currentPixelBox.PixelColor = _mouse.GetColor();

            distanceBox.Position = GetDistance(currentPixelBox.Position, recentPixelBox.Position);
        }

        public static Point GetDistance(Point currentPosition, Point recentPosition)
        {
            int varianceX = recentPosition.X.CompareTo(currentPosition.X);
            int varianceY = recentPosition.Y.CompareTo(currentPosition.Y);
            int lengthX = recentPosition.X - currentPosition.X + varianceX;
            int lengthY = recentPosition.Y - currentPosition.Y + varianceY;

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
