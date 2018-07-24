using System;
using System.IO;
using System.Management;
using System.Text;

namespace GetIP
{
    static class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream("your_ips", FileMode.Create);

            foreach (ManagementObject mo in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration").Get())
            {
                try
                {
                    fs.w("Caption: " + mo["Caption"]);
                    fs.w("Description: " + mo["Description"]);
                    fs.w("ServiceName: " + mo["ServiceName"]);
                    foreach (string i in (String[])mo["IPAddress"])
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
            s += "\r\n";
            fs.Write(Encoding.UTF8.GetBytes(s), 0, Encoding.UTF8.GetByteCount(s));
        }
    }
}
