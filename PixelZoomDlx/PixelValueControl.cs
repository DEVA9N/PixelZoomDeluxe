using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A9N.PixelZoomDlx
{
    public partial class PixelValueControl : UserControl
    {
        private Point position;
        private Color pixelColor;

        public PixelValueControl()
        {
            InitializeComponent();
        }

        public Color PixelColor
        {
            get { return pixelColor; }
            set
            {
                pixelColor = value;
                labelARGBValue.Text = String.Format("{0} {1} {2} {3}", pixelColor.A, pixelColor.R, pixelColor.G, pixelColor.B);
            }
        }

        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                
                labelXValue.Text = position.X.ToString();
                labelYValue.Text = position.Y.ToString();
            }
        }

        public bool ShowColor
        {
            get { return labelARGB.Visible; }
            set
            {
                labelARGB.Visible = value;
                labelARGBValue.Visible = value;
            }
        }

        public override String Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }
    }
}
