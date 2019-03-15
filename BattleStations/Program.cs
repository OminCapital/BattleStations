using System;
using System.Runtime.InteropServices; // For the P/Invoke signatures.


namespace BattleStations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BattleStations.PositionWindow.getWindow();
        }
    }

    public static class PositionWindow{
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]  
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        //Microsoft windowing system behavior flags
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        public static void getWindow(){

            // Find (the first-in-Z-order) Notepad window.
            IntPtr hWnd = FindWindow("Notepad", null);

            // If found, position it.
            if (hWnd != IntPtr.Zero)
            {
                // Move the window to (0,0) without changing its size or position
                // in the Z order.
                Console.WriteLine("HWND " + hWnd.ToString());
                SetWindowPos(hWnd, IntPtr.Zero, 100, 300, 240, 240, SWP_NOZORDER);
            }
        }
    }
}
