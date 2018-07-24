using System;
using System.IO;
using System.Management;
using System.Text;

namespace RamStatus
{
    static class Program
    {
        static string[] ram_attrs = new string[]
        {
            "Attributes",
            "BankLabel",
            "Capacity",
            "Caption",
            "ConfiguredClockSpeed",
            "ConfiguredVoltage",
            "CreationClassName",
            "DataWidth",
            "Description",
            "DeviceLocator",
            "FormFactor",
            "HotSwappable",
            "InstallDate",
            "InterleaveDataDepth",
            "InterleavePosition",
            "Manufacturer",
            "MaxVoltage",
            "MemoryType",
            "MinVoltage",
            "Model",
            "Name",
            "OtherIdentifyingInfo",
            "PartNumber",
            "PositionInRow",
            "PoweredOn",
            "Removable",
            "Replaceable",
            "SerialNumber",
            "SKU",
            "SMBIOSMemoryType",
            "Speed",
            "Status",
            "Tag",
            "TotalWidth",
            "TypeDetail",
            "Version"
        };

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("ram_info", FileMode.Create);
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                foreach (ManagementObject mo in mos.Get())
                {
                    foreach (string a in ram_attrs)
                    {
                        try
                        {
                            fs.w($"{a}: {mo[a]}");
                        }
                        catch (Exception e)
                        {
                            fs.w("Error in 0");
                            fs.w(e.ToString());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                fs.w("Error in 1");
                fs.w(e.ToString());
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
