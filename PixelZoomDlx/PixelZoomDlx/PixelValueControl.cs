using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PixelZoomDlx
{
	public partial class PixelValueControl : UserControl
	{
		public PixelValueControl() : this("foo")
		{

		}

		public PixelValueControl(String title)
		{
			InitializeComponent();

			groupBox1.Text = title;
		}

		private Point position;

		public Point Position
		{
			get { return position; }
			set 
			{
				if (value != null)
				{
					position = value;
					labelXValue.Text = position.X.ToString();
					labelYValue.Text = position.Y.ToString();
				}
			}
		}

		private Color pixelColor;

		public Color PixelColor
		{
			get { return pixelColor; }
			set 
			{
				if (value != null && value != Color.Empty)
				{
					pixelColor = value;
					String a = pixelColor.A.ToString();
					String r = pixelColor.R.ToString();
					String g = pixelColor.G.ToString();
					String b = pixelColor.B.ToString();

					labelARGBValue.Text = a + " " + " " + r + " " + g + " " + b;
				}
			}
		}


		#region Properties

		public override String Text {
			get { return base.Text; }
			set
			{
				base.Text = value;
				groupBox1.Text = value;
			} 
		}

		#endregion
	}
}
