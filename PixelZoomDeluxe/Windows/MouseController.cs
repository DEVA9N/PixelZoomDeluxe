using System;
using System.Drawing;
using System.Windows.Forms;

namespace A9N.PixelZoomDeluxe.Windows
{
    internal sealed class MouseController
    {
        private readonly UInt32 _defaultMouseSpeed;
        private const UInt32 SlowMouseSpeed = 2;
        private const UInt32 SpiGetMouseSpeed = 0x0070;
        private const UInt32 SpiSetMouseSpeed = 0x0071;

        public MouseController()
        {
            _defaultMouseSpeed = GetMouseSpeed();
        }

        private UInt32 GetMouseSpeed()
        {
            UInt32 currentSpeed = 0;
            WindowsApi.SystemParametersGetInfo(SpiGetMouseSpeed, 0, ref currentSpeed, 0);
            return currentSpeed;
        }

        private void SetMouseSpeed(UInt32 value)
        {
            WindowsApi.SystemParametersSetInfo(SpiSetMouseSpeed, 0, value, 0);
        }

        public void ReduceSpeed()
        {
            SetMouseSpeed(SlowMouseSpeed);
        }

        public void ResetSpeed()
        {
            SetMouseSpeed(_defaultMouseSpeed);
        }

        public Color GetColor()
        {
            var desktopWindow = WindowsApi.GetDesktopWindow();
            var deviceContext = WindowsApi.GetWindowDC(desktopWindow);

            POINT cursor;
            WindowsApi.GetCursorPos(out cursor);

            var pixel = WindowsApi.GetPixel(deviceContext, cursor.X, cursor.Y);

            WindowsApi.ReleaseDC(desktopWindow, deviceContext);

            var color = Color.FromArgb((int)(pixel & 0x000000FF),
                                (int)(pixel & 0x0000FF00) >> 8,
                                (int)(pixel & 0x00FF0000) >> 16);

            return color;
        }

        public void ToggleMouseSpeed()
        {
            var current = GetMouseSpeed();

            if (current == SlowMouseSpeed)
            {
                SetMouseSpeed(_defaultMouseSpeed);
            }
            else
            {
                SetMouseSpeed(SlowMouseSpeed);
            }
        }

        public Point GetPosition()
        {
            // Top left pixel start with 1, 1
            return new Point(Cursor.Position.X + 1, Cursor.Position.Y + 1);
        }
    }
}
