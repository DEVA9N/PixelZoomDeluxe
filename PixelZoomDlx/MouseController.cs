using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace A9N.PixelZoomDlx
{
    /// <summary>
    /// Class MouseController controls the mouse movement speed.
    /// </summary>
    class MouseController
    {
        // Mouse thingies
        private readonly UInt32 originalMouseSpeed;
        private const UInt32 slowMouseSpeed = 2;
        private const UInt32 SPI_GETMOUSESPEED = 0x0070;
        private const UInt32 SPI_SETMOUSESPEED = 0x0071;

        public MouseController()
        {
            // Get current mouse speed
            originalMouseSpeed = this.MouseSpeed;
        }

        /// <summary> 
        /// Gets the System.Drawing.Color from under the mouse cursor. 
        /// </summary> 
        /// <returns>The color value.</returns> 
        public Color GetColor()
        {
            var desktopWindow = WindowsApi.GetDesktopWindow();
            var deviceContext = WindowsApi.GetWindowDC(desktopWindow);

            POINT cursor;
            WindowsApi.GetCursorPos(out cursor);

            var color = WindowsApi.GetPixel(deviceContext, cursor.X, cursor.Y);

            WindowsApi. ReleaseDC(desktopWindow, deviceContext);

            return Color.FromArgb((int)color);
        }

        internal void ReduceSpeed()
        {
            this.MouseSpeed = slowMouseSpeed;
        }

        /// <summary>
        /// Resets the mouse speed.
        /// </summary>
        internal void ResetSpeed()
        {
            // Reset mouse speed
            this.MouseSpeed = originalMouseSpeed;
        }

        /// <summary>
        /// Gets or sets the mouse speed.
        /// </summary>
        /// <value>The mouse speed.</value>
        private UInt32 MouseSpeed
        {
            get
            {
                UInt32 currentSpeed = 0;
                WindowsApi.SystemParametersGetInfo(SPI_GETMOUSESPEED, 0, ref currentSpeed, 0);
                return currentSpeed;
            }
            set
            {
                WindowsApi.SystemParametersSetInfo(SPI_SETMOUSESPEED, 0, value, 0);
            }
        }
    }
}
