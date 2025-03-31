using System;
using System.Runtime.InteropServices;

namespace A9N.PixelZoomDeluxe.Windows
{
    class WindowsApi
    {
        // Get mouse speed (watch the "ref")
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersGetInfo(uint uiAction, uint uiParam, ref uint pvParam, uint fWinIni);

        // Set mouse speed
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersSetInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        [DllImport("gdi32")]
        public static extern uint GetPixel(IntPtr hDC, int XPos, int YPos);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);

    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
