using System;
using System.Runtime.InteropServices;
using System.IO;

namespace SwapMouse
{
    /// <summary>
    /// Program to quickly change mouse buttons
    /// </summary>
    class Program
    {
        [DllImport("user32.dll")]
        public static extern Int32 SwapMouseButton(Int32 bSwap);
        [DllImport("user32.dll")]
        public static extern Int32 GetSystemMetrics(Int32 Value);
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);
        [DllImport("user32.dll")]
        public static extern bool SetSystemCursor(IntPtr hCursor, CursorType cursor);

        public enum CursorType : uint
        {
            IDC_ARROW = 32512U,         //Arrow箭头
            IDC_IBEAM = 32513U,         //Text Select工字钢
            IDC_WAIT = 32514U,          //Busy等待
            IDC_CROSS = 32515U,         //交叉
            IDC_UPARROW = 32516U,       //Alternate Select向上光标
            IDC_SIZE = 32640U,          //
            IDC_ICON = 32641U,          //
            IDC_SIZENWSE = 32642U,      //Diagonal Resize 1反斜线
            IDC_SIZENESW = 32643U,      //Diagonal Resize 2斜线
            IDC_SIZEWE = 32644U,        //Horizontal Resize水平调整
            IDC_SIZENS = 32645U,        //Vertical Resize垂直调整
            IDC_SIZEALL = 32646U,       //Move十字移动光标
            IDC_NO = 32648U,            //Unavailable不
            IDC_HAND = 32649U,          //Link手
            IDC_APPSTARTING = 32650U,   //Starting程序启动后台运行
            IDC_HELP = 32651U           //Help帮助
        }
        static public IntPtr lcur;
        static public bool GetCursorFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                lcur=LoadCursorFromFile(fileName);
                return true;
            }
            else return false;
        }
        static public void SetMouseCursor(string spath)
        {

            if (GetCursorFile(spath+"Arrow.cur"))   SetSystemCursor(lcur, CursorType.IDC_ARROW);

            if (GetCursorFile(spath+"Busy.ani"))      SetSystemCursor(lcur, CursorType.IDC_WAIT);

            if (GetCursorFile(spath+"Help.cur"))      SetSystemCursor(lcur, CursorType.IDC_HAND);

            if (GetCursorFile(spath+"Starting.ani"))  SetSystemCursor(lcur, CursorType.IDC_APPSTARTING);

            if (GetCursorFile(spath+"Link.cur"))      SetSystemCursor(lcur, CursorType.IDC_HAND);
        }

        static void Main(string[] args)
        {
            try
            {
                bool swapped = GetSystemMetrics(23) != 0;
            
                if (swapped)
                {
                    SwapMouseButton(0);
                    SetMouseCursor(".\\right\\");
                    //Console.WriteLine("MouseButtons swapped to right");
                    //Console.WriteLine("Press any key to exit...");
                    //Console.ReadLine();
                }
                else
                {
                    SwapMouseButton(1);
                    SetMouseCursor(".\\left\\");
                    //Console.WriteLine("MouseButtons swapped to left");
                    //Console.WriteLine("Press any key to exit...");
                    //Console.ReadLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error swapping mousebuttons");
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
            }


        }
    }
}
