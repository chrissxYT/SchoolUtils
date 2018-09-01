//scans for open internal "legacy ip" (IPv4) devices
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Threading;
using static System.Text.Encoding;
using static System.Console;

namespace IPScanner
{
    class Program
    {
        static volatile bs o = new bs("open_ips.gz");
        static volatile bs c = new bs("closed_ips.gz");
        static volatile List<Thread> t = new List<Thread>();

        static void Main(string[] args)
        {
            byte byte3 = byte.Parse(ReadLine());
            ShowWindow(GetConsoleWindow(), 0);
            for (ushort byte4 = 0; byte4 < 256; byte4++)
                s(new byte[] { 192, 168, byte3, (byte)byte4 });
            foreach (Thread t in t)
                while (t.ThreadState == ThreadState.Running)
                    Thread.Sleep(1);
            o.f();
            o.c();
            c.f();
            c.c();
        }

        static void s(byte[] ip)
        {
            Thread u = new Thread(() =>
            {
                try
                {
                    PingReply pr = new Ping().Send(new IPAddress(ip));
                    w(pr.Status == IPStatus.Success ? o : c, $"{pr.Address} {(int)pr.Status} {pr.Status.ToString().ToUpper()}");
                }
                catch (Exception e)
                {
                    w(c, e.ToString());
                }
            });
            u.Start();
            t.Add(u);
        }

        static void w(bs bs, string s)
        {
            s += "\n";
            bs.q(UTF8.GetBytes(s));
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }

    class bs
    {
        BufferedStream s;
        List<byte[]> b;

        public bs(string f)
        {
            s = new BufferedStream(new GZipStream(new FileStream(f, FileMode.Create), CompressionLevel.Optimal, false), 32767);
            b = new List<byte[]>();
        }

        public void q(byte[] c)
        {
            b.Add(c);
        }

        public void f()
        {
            foreach(byte[] b in b)
                s.Write(b, 0, b.Length);
            s.Flush();
        }

        public void c()
        {
            s.Close();
        }
    }
}
