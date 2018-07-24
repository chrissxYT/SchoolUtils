using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace IPScanner
{
    class Program
    {
        static volatile bs o = new bs("open_ips.gz", 32767);
        static volatile bs c = new bs("closed_ips.gz", 32767);

        static void Main(string[] args)
        {
            byte byte3 = byte.Parse(Console.ReadLine());
            for (ushort byte4 = 0; byte4 < 256; byte4++)
            {
                s(new byte[] { 192, 168, byte3, (byte)byte4 });
            }
            o.f();
            o.c();
            c.f();
            c.c();
        }

        static void s(byte[] ip)
        {
            new Thread(() =>
            {
                try
                {
                    PingReply pr = new Ping().Send(new IPAddress(ip));
                    w(pr.Status == IPStatus.Success ? o : c, $"{pr.Address} {(int)pr.Status}");
                }
                catch (Exception e)
                {
                    w(c, e.ToString());
                }
            }).Start();
        }

        static void w(bs bs, string s)
        {
            s += "\r\n";
            bs.q(Encoding.UTF8.GetBytes(s));
        }
    }

    class bs
    {
        BufferedStream s;
        List<byte[]> b;

        public bs(string f, int ibs)
        {
            s = new BufferedStream(new GZipStream(new FileStream(f, FileMode.Create), CompressionLevel.Optimal, false), ibs);
            b = new List<byte[]>();
        }

        public void q(byte[] b)
        {
            this.b.Add(b);
        }

        public void f()
        {
            foreach(byte[] b in b)
            {
                s.Write(b, 0, b.Length);
            }
            s.Flush();
        }

        public void c()
        {
            s.Close();
        }
    }
}
