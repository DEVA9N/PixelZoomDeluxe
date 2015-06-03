using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PixelZoomDlx
{
	public partial class MainWindow : Form
	{
		private Thread displayThread;
		private ZoomPainter zoom;

		// Mouse thingies
		private UInt32 originalMouseSpeed;
		private UInt32 slowMouseSpeed = 2;
		private const UInt32 SPI_GETMOUSESPEED = 0x0070;
		private const UInt32 SPI_SETMOUSESPEED = 0x0071;

		// Get mouse speed (watch the "ref")
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		public static extern bool SystemParametersGetInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

		// Set mouse speed
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		public static extern bool SystemParametersSetInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);


		public MainWindow()
		{
			InitializeComponent();

			// Add version string to title text
			if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
			{
				String version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
				Text += " - " + version;
			}

            currentPixelBox.Text = "Current Pixel";
            recentPixelBox.Text = "Recent Pixel";
            lengthBox.Text = "Length";

            // Create render class
			zoom = new ZoomPainter(this);

            buttonToggleZoom.Text = "Zoom x " + zoom.ZoomFactor.ToString();
			
            // Start renderer in new thread
            displayThread = new Thread(new ParameterizedThreadStart(zoom.Start));
			displayThread.Start();

			// Get current mouse speed
			originalMouseSpeed = MouseSpeed;
		}

        /// <summary>
        /// Show mouse position in status bar (thread-safe)
        /// 
        /// Note this tiny trick which the self call via delegate.
        /// </summary>
        public void DisplayMousePosition()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(DisplayMousePosition), null);
            }
            else
            {
                statusXPos.Text = (Cursor.Position.X + 1).ToString();
                statusYPos.Text = (Cursor.Position.Y + 1).ToString();
            }
        }

        /// <summary>
        /// Show image in main windows' picture box (thread-safe)
        /// </summary>
        /// <param name="image"></param>
		private delegate void DisplayImageDelegate(Bitmap image);

		public void DisplayImage(Bitmap image)
		{
			if (this.InvokeRequired)
			{
				Object[] args = { image };

				this.BeginInvoke(new DisplayImageDelegate(DisplayImage), args);

				return;
			}

			pictureBox1.Image = image;
		}

        /// <summary>
        /// Get color from the pixel beneath the mouse pointer
        /// </summary>
        /// <returns></returns>
		private Color GetCursorColor()
		{
			Bitmap b = new Bitmap(1, 1);
			Graphics g = Graphics.FromImage(b);
			g.CopyFromScreen(Cursor.Position.X, Cursor.Position.Y, 0, 0, b.Size);
			g.Dispose();

			return b.GetPixel(0, 0);
		}

        /// <summary>
        /// Do moose stuff
        /// </summary>
		private void UpdateGroupBoxes()
		{
			recentPixelBox.Position = currentPixelBox.Position;
			recentPixelBox.PixelColor = currentPixelBox.PixelColor;

			currentPixelBox.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
			currentPixelBox.PixelColor = GetCursorColor();

			int varianceX = currentPixelBox.Position.X.CompareTo(recentPixelBox.Position.X);
			int varianceY = currentPixelBox.Position.Y.CompareTo(recentPixelBox.Position.Y);
			int lengthX = currentPixelBox.Position.X - recentPixelBox.Position.X + varianceX;
			int lengthY = currentPixelBox.Position.Y - recentPixelBox.Position.Y + varianceY;

			lengthBox.Position = new Point(lengthX, lengthY);
		}

		#region Events

        /// <summary>
        /// Final steps when the programm is closed. Kills render thread and resets 
        /// mouse speed to original settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			displayThread.Abort();

			// Reset mouse speed
			MouseSpeed = originalMouseSpeed;
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
			if (e.KeyChar == 'm')
			{
				// Toggle mouse speed
				MouseSpeed = MouseSpeed == originalMouseSpeed ? slowMouseSpeed : originalMouseSpeed;
			}

			UpdateGroupBoxes();
		}

        /// <summary>
        /// Recalculate display data on resize
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void pictureBox1_Resize(object sender, EventArgs e)
		{
			zoom.UpdateDisplaySetup();
		}

		#endregion

		#region Buttons

        /// <summary>
        /// Toggle zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void buttonToggleZoom_Click(object sender, EventArgs e)
		{
			zoom.ZoomFactor = zoom.ZoomFactor == 4 ? 8 : 4;

			buttonToggleZoom.Text = "Zoom x " + zoom.ZoomFactor.ToString();
		}

        /// <summary>
        /// Toggle accuracy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void buttonAccuracy_Click(object sender, EventArgs e)
		{
			if (zoom.IsAccurate == true)
			{
				zoom.IsAccurate = false;
				buttonAccuracy.Text = "Low Accuracy";
			}
			else
			{
				zoom.IsAccurate = true;
				buttonAccuracy.Text = "High Accuracy";
			}
		}

		#endregion

		#region Properties

		public PictureBox Display
		{
			get { return pictureBox1; }
		}

		private UInt32 MouseSpeed {
			get
			{
				UInt32 currentSpeed = 0;
				SystemParametersGetInfo(SPI_GETMOUSESPEED, 0, ref currentSpeed, 0);
				return currentSpeed;
			}
			set
			{
				SystemParametersSetInfo(SPI_SETMOUSESPEED, 0, value, 0);
			}
		}

		#endregion

	}
}
