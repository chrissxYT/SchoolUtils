using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using static System.Text.Encoding;

namespace GetIP
{
    static class Program
    {
        static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 0);
            FileStream fs = new FileStream("your_ips", FileMode.Create);

            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration").Get())
            {
                try
                {
                    fs.w("Caption: " + mo["Caption"]);
                    fs.w("Description: " + mo["Description"]);
                    fs.w("ServiceName: " + mo["ServiceName"]);
                    foreach (string i in (string[])mo["IPAddress"])
                        fs.w("Address: " + i);
                }
                catch(Exception e)
                {
                    fs.w(e.ToString());
                }
                fs.w("-----------------------------");
            }

            fs.Close();
        }

        static void w(this FileStream fs, string s)
        {
            fs.Write(UTF8.GetBytes(s + "\n"), 0, UTF8.GetByteCount(s) + 1);
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }
}
