//scans for open internal "legacy ip" (IPv4) devices
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using static System.Text.Encoding;

namespace IPScanner
{
    class Program
    {
        static bs o = new bs("open_ips");
        static bs c = new bs("closed_ips");
        static volatile int i = 0;
        static object lck = new object();

        static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 0);
            int j = 0;
            for(short byte3 = 0; byte3 < 256; byte3++)
                for (short byte4 = 0; byte4 < 256; byte4++)
                {
                    s(new byte[] { 192, 168, (byte)byte3, (byte)byte4 });
                    if (j > 500)
                    {
                        j = 0;
                        GC.Collect();
                    }
                    else
                        j++;
                    //while (i > 1000)
                    //    ;
                }
            while (i > 0)
                ;
            o.f();
            o.c();
            c.f();
            c.c();
        }

        static async void s(byte[] ip)
        {
            lock(lck)
            {
                i++;
            }
            try
            {
                PingReply pr = await new Ping().SendPingAsync(new IPAddress(ip));
                (pr.Status == IPStatus.Success ? o : c).q(UTF8.GetBytes($"{pr.Address} {(int)pr.Status} {pr.Status}\n"));
            }
            catch (Exception e)
            {
                c.q(UTF8.GetBytes(e.ToString() + "\n"));
            }
            lock(lck)
            {
                i--;
            }
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }

    class bs
    {
        Stream s;
        List<byte[]> b;
        object lck = new object();

        public bs(string f)
        {
            lock(lck)
            {
                s = File.Open(f, FileMode.Create, FileAccess.Write);
                b = new List<byte[]>();
            }
        }

        public void q(byte[] c)
        {
            lock (lck)
            {
                b.Add(c);
            }
        }

        public void f()
        {
            lock (lck)
            {
                foreach (byte[] b in b)
                    s.Write(b, 0, b.Length);
            }
        }

        public void c()
        {
            lock (lck)
            {
                f();
                s.Close();
            }
        }
    }
}
