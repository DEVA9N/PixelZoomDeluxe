using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace A9N.PixelZoomDeluxe.Controls;

public partial class PixelValueControl : UserControl
{
    private Point _position;
    private Color _pixelColor;

    public PixelValueControl()
    {
        InitializeComponent();
    }

    [DefaultValue(null)]
    public Color PixelColor
    {
        get => _pixelColor;
        set
        {
            _pixelColor = value;
                
            textboxARGBValue.Text = $@"{_pixelColor.R} {_pixelColor.G} {_pixelColor.B}";
            textBoxHexValue.Text = $@"#{_pixelColor.A:X2}{_pixelColor.R:X2}{_pixelColor.G:X2}{_pixelColor.B:X2}";
        }
    }

    [DefaultValue(null)]
    public Point Position
    {
        get => _position;
        set
        {
            _position = value;
                
            textboxXValue.Text = _position.X.ToString();
            textboxYValue.Text = _position.Y.ToString();
        }
    }

    [DefaultValue(false)]
    public bool ShowColor
    {
        get => labelARGB.Visible;
        set
        {
            labelARGB.Visible = value;
            textboxARGBValue.Visible = value;
            labelHex.Visible = value;
            textBoxHexValue.Visible = value;
        }
    }

    [DefaultValue(null)]
    public override String Text
    {
        get => groupBox1.Text;
        [param: AllowNull] set => groupBox1.Text = value;
    }
}