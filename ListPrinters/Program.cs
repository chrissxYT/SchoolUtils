using System;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ListPrinters
{
    static class Program
    {
        static void Main(string[] args)
        {
            hide();
            FileStream fs = new FileStream("printers", FileMode.Create);
            foreach (string printer in PrinterSettings.InstalledPrinters)
                fs.w(printer);
            fs.Close();
        }

        static void hide() => ShowWindow(GetConsoleWindow(), 0);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static void w(this FileStream fs, string s)
        {
            s += "\n";
            fs.Write(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetByteCount(s));
        }
    }
}
