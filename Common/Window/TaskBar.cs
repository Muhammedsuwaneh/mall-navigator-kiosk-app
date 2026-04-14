using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MallMapKiosk.Common.Window
{
    public static class TaskBar
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        public static void HideTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", "");
            ShowWindow(taskbar, SW_HIDE);
        }

        public static void ShowTaskbar()
        {
            var taskbar = FindWindow("Shell_TrayWnd", "");
            ShowWindow(taskbar, SW_SHOW);
        }
    }
}
