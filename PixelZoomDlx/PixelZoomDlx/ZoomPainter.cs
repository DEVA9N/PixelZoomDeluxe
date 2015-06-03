using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelZoomDlx
{
	class ZoomPainter
	{
		#region Fields

		private const int defaultZoomFactor = 4;
		private Rectangle grabRect;
		private Rectangle cursorRect;
		private Pen cursorPen = new Pen(Color.Red);
		private Object thisLock = new Object();
		private MainWindow mainWindow;

		#endregion

		#region Constructors

		public ZoomPainter(MainWindow window)
		{
			this.mainWindow = window;
            this.IsAccurate = true;

			UpdateDisplaySetup();
		}

		#endregion

		#region Public methods
		
        /// <summary>
        /// Start thread
        /// </summary>
        /// <param name="taskID"></param>
		public void Start(Object taskID)
		{
			while (true)
			{
				ShowImage();

				mainWindow.DisplayMousePosition();
			}
		}

		#endregion

		#region Private methods

        /// <summary>
        /// Show image regarding the chosen quality
        /// </summary>
		private void ShowImage()
		{
			lock (thisLock)
			{
				if (IsAccurate)
				{
					SlowShowImage();
				}
				else
				{
					FastShowImage();
				}
			}
		}

        /// <summary>
        /// Display image. This routine is slow and very little optimized. But it's accurate and
        /// fast enough for normal computers.
        /// </summary>
		private void SlowShowImage()
		{
			// Create screen grab and write to bitmap
			Bitmap screenGrabBitmap = new Bitmap(grabRect.Width, grabRect.Height);
			Graphics screenGrabGraphics = Graphics.FromImage(screenGrabBitmap);
			screenGrabGraphics.CopyFromScreen(Cursor.Position.X - grabRect.Width / 2, Cursor.Position.Y - grabRect.Height / 2, 0, 0, grabRect.Size);
			screenGrabGraphics.Dispose();

			// Create ouput
			Bitmap displayBitmap = new Bitmap(mainWindow.Display.Width, mainWindow.Display.Height);
			Graphics displayGraphics = Graphics.FromImage(displayBitmap);
			displayGraphics.Clear(Color.Black);

			for (int ty = grabRect.Height - 1; ty > 0; ty--)
			{
				for (int tx = grabRect.Width - 1; tx > 0; tx--)
				{
					int resultPositionY = (ty - 1) * zoomFactor - 1;
					int resultPositionX = (tx - 1) * zoomFactor - 1;

					SolidBrush pixelBrush = new SolidBrush(screenGrabBitmap.GetPixel(tx, ty));
					displayGraphics.FillRectangle(pixelBrush, resultPositionX, resultPositionY, zoomFactor, zoomFactor);
					pixelBrush.Dispose();
				}
			}

			// Draw cursor
			displayGraphics.DrawRectangle(cursorPen, cursorRect);
			displayGraphics.Dispose();

			mainWindow.DisplayImage(displayBitmap);
		}

        /// <summary>
        /// This is an try for a fast image display. The quality is very poor due to
        /// much aliasing or something similiar. 
        /// </summary>
		private void FastShowImage()
		{
			Bitmap screenGrabBitmap = new Bitmap(grabRect.Width, grabRect.Height);
			Graphics screenGrabGraphics = Graphics.FromImage(screenGrabBitmap);
			screenGrabGraphics.CopyFromScreen(Cursor.Position.X - grabRect.Width / 2, Cursor.Position.Y - grabRect.Height / 2, 0, 0, grabRect.Size);
			screenGrabGraphics.Dispose();

			// Create ouput
			Bitmap displayBitmap = new Bitmap(mainWindow.Display.Width, mainWindow.Display.Height);
			Graphics displayGraphics = Graphics.FromImage(displayBitmap);

			displayGraphics.Clear(Color.Black);
			displayGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

			displayGraphics.DrawImage(screenGrabBitmap,
				new Rectangle(0, 0, mainWindow.Display.Width, mainWindow.Display.Height),
				new Rectangle(0, 0, grabRect.Width, grabRect.Height),
				GraphicsUnit.Pixel);

			// Draw cursor
			displayGraphics.DrawRectangle(cursorPen, cursorRect);
			displayGraphics.Dispose();

			mainWindow.DisplayImage(displayBitmap);
		}

        /// <summary>
        /// Updates the display data. Will fetch the current size settings from
        /// mainWindow and recalculate some regions.
        /// </summary>
		public void UpdateDisplaySetup()
		{
			lock (thisLock)
			{
				// Grab rectangle settings
				int grabWidth = mainWindow.Display.Width / zoomFactor;
				int grabHeight = mainWindow.Display.Height / zoomFactor;
				grabRect = new Rectangle(0, 0, grabWidth, grabHeight);

				// Cross-hair settings
				int curserPosX = mainWindow.Display.Width / 2 - zoomFactor - 2;
				int curserPosY = mainWindow.Display.Height / 2 - zoomFactor - 2;
				int cursorWidth = zoomFactor + 1;
				int curserHeight = zoomFactor + 1;
				cursorRect = new Rectangle(curserPosX, curserPosY, cursorWidth, curserHeight);
			}
		}

		#endregion

		#region Properties

		private int zoomFactor = defaultZoomFactor;

		public int ZoomFactor
		{
			get { return zoomFactor; }
			set
			{
				// Wait until the ShowImage has finished
				lock (thisLock)
				{
					bool isValidZoomFactor = value == 2 || value == 4 || value == 8;
					this.zoomFactor = isValidZoomFactor ? value : defaultZoomFactor;

					// After the zoomfactor has changed some values will have to be updated
					UpdateDisplaySetup();
				}
			}
		}

		public bool IsAccurate { get; set; }

		#endregion

	}
}
