using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace A9N.PixelZoomDlx
{
    public partial class MainWindow : Form
    {
        #region Fields
        private readonly ZoomPainter zoom;
        private readonly MouseController mouse;
        private bool isDisplayingImage;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            AddVersionTitle();

            this.recentPixelBox1.Text = "Recent 1";
            this.recentPixelBox2.Text = "Recent 2";
            this.distanceBox.Text = "Distance R1 / R2";

            mouse = new MouseController();

            // Create render class
            zoom = new ZoomPainter(pictureBox.Size);
            zoom.NewImage += zoom_NewImage;
        }

        private void AddVersionTitle()
        {
            try
            {
                // Add version string to title text
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    String version = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();

                    if (!String.IsNullOrWhiteSpace(version))
                    {
                        Text += " - " + version;
                    }
                }
            }
            catch (Exception e)
            {
                // Don't care
            }
        }
        #endregion

        /// <summary>
        /// Final steps when the programm is closed. Kills render thread and resets 
        /// mouse speed to original settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            mouse.ResetSpeed();
        }

        /// <summary>
        /// Keypress will update group boxes. It adds the current mouse position
        /// to the group boxes.
        /// Exception: Pressing "m" will toggle mouse speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyPress(object sender, KeyPressEventArgs e)
        {



            recentPixelBox2.Position = recentPixelBox1.Position;
            recentPixelBox2.PixelColor = recentPixelBox1.PixelColor;

            // Top left pixel should start with 1, 1
            recentPixelBox1.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
            recentPixelBox1.PixelColor = mouse.GetColor();

            int varianceX = recentPixelBox2.Position.X.CompareTo(recentPixelBox1.Position.X);
            int varianceY = recentPixelBox2.Position.Y.CompareTo(recentPixelBox1.Position.Y);
            int lengthX = recentPixelBox2.Position.X - recentPixelBox1.Position.X + varianceX;
            int lengthY = recentPixelBox2.Position.Y - recentPixelBox1.Position.Y + varianceY;

            distanceBox.Position = new Point(lengthX, lengthY);
        }

        /// <summary>
        /// Recalculate display data on resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Resize(object sender, EventArgs e)
        {
            zoom.DisplaySize = pictureBox.Size;
        }

        /// <summary>
        /// Handles the Click event of the buttonZoomOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonZoomOut_Click(object sender, EventArgs e)
        {
            zoom.ZoomOut();

            buttonZoomIn.Enabled = zoom.CanZoomIn;
            buttonZoomOut.Enabled = zoom.CanZoomOut;
        }

        /// <summary>
        /// Handles the Click event of the buttonZoomIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void buttonZoomIn_Click(object sender, EventArgs e)
        {
            zoom.ZoomIn();

            buttonZoomIn.Enabled = zoom.CanZoomIn;
            buttonZoomOut.Enabled = zoom.CanZoomOut;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBoxMouseSpeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxMouseSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMouseSpeed.Checked)
            {
                mouse.ReduceSpeed();
            }
            else
            {
                mouse.ResetSpeed();
            }
        }

        /// <summary>
        /// Handles the NewImage event of the zoom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ImageEventArgs"/> instance containing the event data.</param>
        private void zoom_NewImage(object sender, ImageEventArgs e)
        {
            if (isDisplayingImage)
            {
                return;
            }

            Action displayImage = () =>
            {
                isDisplayingImage = true;

                pictureBox.Image = e.Image;

                isDisplayingImage = false;
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

    }
}
