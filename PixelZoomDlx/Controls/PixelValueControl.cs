using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A9N.PixelZoomDeluxe
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
                
                textboxARGBValue.Text = $@"{pixelColor.R} {pixelColor.G} {pixelColor.B}";
                textBoxHexValue.Text = $@"#{pixelColor.A:X2}{pixelColor.R:X2}{pixelColor.G:X2}{pixelColor.B:X2}";
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
                labelHex.Visible = value;
                textBoxHexValue.Visible = value;
            }
        }

        public override String Text
        {
            get { return groupBox1.Text; }
            set { groupBox1.Text = value; }
        }
    }
}
