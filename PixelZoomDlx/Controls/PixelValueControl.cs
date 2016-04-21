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
                textboxARGBValue.Text = String.Format("{0} {1} {2}", pixelColor.R, pixelColor.G, pixelColor.B);
            }
        }

        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                
                textboxXValue.Text = position.X.ToString();
                textboxYValue.Text = position.Y.ToString();
            }
        }

        public bool ShowColor
        {
            get { return labelARGB.Visible; }
            set
            {
                labelARGB.Visible = value;
                textboxARGBValue.Visible = value;
            }
        }

        public override String Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }
    }
}
