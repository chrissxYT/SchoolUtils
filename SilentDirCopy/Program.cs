using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SilentDirCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("From: ");
            string from = Console.ReadLine();
            Console.Write("To: ");
            string to = Console.ReadLine();
            ShowWindow(GetConsoleWindow(), 0);
            dir(from, to);
        }

        static void dir(string from, string to)
        {
            if (!Directory.Exists(to))
                Directory.CreateDirectory(to);
            foreach (string f in Directory.GetFiles(from))
                File.Copy(f, Path.Combine(to, Path.GetFileName(f)));
            foreach (string d in Directory.GetDirectories(from))
                dir(d, Path.Combine(to, Path.GetFileName(d)));
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }
}
