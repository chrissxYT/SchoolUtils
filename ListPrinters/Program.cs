using System;
using System.IO;
using System.Runtime.InteropServices;
using static System.Text.Encoding;
using static System.Drawing.Printing.PrinterSettings;
using static System.IO.File;
using static System.IO.FileAccess;

namespace ListPrinters
{
    static class Program
    {
        static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 0);
            Stream fs = Open("printers", FileMode.Create, Write);
            foreach (string printer in InstalledPrinters)
                fs.w(printer);
            fs.Close();
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        static byte[] lf = UTF8.GetBytes("\n");

        static void w(this Stream fs, string s)
        {
            fs.Write(UTF8.GetBytes(s), 0, UTF8.GetByteCount(s));
            fs.Write(lf, 0, 1);
        }
    }
}
