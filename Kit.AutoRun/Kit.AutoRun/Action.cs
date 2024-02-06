using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kit.AutoRun
{
    public class Action
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, int dx, int dy, long cButtons, long dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_MOVE = 0x0001;
        
        public static void DoMouseClick(int X, int Y)
        {
            //move to coordinates
            Point pt = new Point(X, Y);
            Cursor.Position = pt;

            //perform click            
            mouse_event(MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void DoMouseDoubleClick(int X, int Y)
        {
            //move to coordinates
            Point pt = new Point(X, Y);
            Cursor.Position = pt;

            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            Thread.Sleep(150);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
        }

        public static void SetRegistry(int iValue)
        {
            RegistryData.Update(RegistryData.KIT_ENABLE_RUN, iValue);
        }

        public static int GetStopKey()
        {
            return (int)RegistryData.Select(RegistryData.KIT_ENABLE_RUN, 0);
        }

        private static string GetDataValue(DataItem dataItem)
        {
            if (dataItem != null)
            {
                StringBuilder strBuilder = new StringBuilder();

                strBuilder.AppendLine(dataItem.Type.ToString());
                strBuilder.AppendLine(dataItem.Special == null ? "" : dataItem.Special);
                strBuilder.AppendLine(dataItem.Value.ToString());
                strBuilder.AppendLine(dataItem.Delay.ToString());
                strBuilder.AppendLine(dataItem.Code.ToString());
                strBuilder.AppendLine(dataItem.IsFunction ? "1" : "0");
                strBuilder.AppendLine(dataItem.Wait ? "1" : "0");
                strBuilder.AppendLine(dataItem.Num.ToString());
                
                return strBuilder.ToString();
            }
            return "";
        }

        public static string GetDataValue(BindingSource bindingSource)
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (DataItem dataItem in bindingSource)
            {
                string strValue = GetDataValue(dataItem);
                strBuilder.Append(strValue);
            }

            return strBuilder.ToString();
        }        

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
    

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();
            
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public static int GetWindows()
        {            
            return OpenWindowGetter.GetOpenWindows().Count;
        }


        public static void SetClipboardText(object objValue)
        {
            Clipboard.SetText(objValue.ToString());
        }
    }
}
