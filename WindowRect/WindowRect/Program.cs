using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowRect
{
     class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetClientRect(IntPtr hwnd, out RECT rect);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ClientToScreen(IntPtr hwnd, ref POINT rect);

        public static RECT rectT;
        //Make The RECT and Point
        public struct POINT
        {
            public int x;
            public int y;
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        
        static void Main(string[] args) 
        {
            RenderTest test = new RenderTest();
            test.Start();
            string windowTitle = "Untitled - Notepad";

            while (true)
            {
                IntPtr Hwnd = FindWindow(null, windowTitle);
                if (Hwnd != IntPtr.Zero)
                {
                    GetClientRect(Hwnd, out RECT rect);
                    //Use Point to get
                    POINT TopLeft = new POINT { x = rect.left, y = rect.top };
                    ClientToScreen(Hwnd, ref TopLeft);

                    rectT = new RECT { left = TopLeft.x, top = TopLeft.y, bottom = rect.bottom, right = rect.right };
                }
            }
            
        }
    }
}
