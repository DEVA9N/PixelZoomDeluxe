using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9N.PixelZoomDlx
{
    /// <summary>
    /// Delegate ImageEventHandler
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="ImageEventArgs"/> instance containing the event data.</param>
    public delegate void ImageEventHandler(object sender, ImageEventArgs e);

    /// <summary>
    /// Class ImageEventArgs.
    /// </summary>
    public class ImageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageEventArgs"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        public ImageEventArgs(Image image)
        {
            this.Image = image;
        }

        ~ImageEventArgs()
        {
            this.Image?.Dispose();
        }
    }
}
