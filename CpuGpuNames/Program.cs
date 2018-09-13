using System;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using static System.Text.Encoding;

namespace CpuGpuNames
{
    static class Program
    {
        static string[] cpu_attrs = new string[]
        {
            "AddressWidth",
            "Architecture",
            "AssetTag",
            "Availability",
            "Caption",
            "Characteristics",
            "ConfigManagerErrorCode",
            "ConfigManagerUserConfig",
            "CpuStatus",
            "CreationClassName",
            "CurrentClockSpeed",
            "CurrentVoltage",
            "DataWidth",
            "Description",
            "DeviceID",
            "ErrorCleared",
            "ErrorDescription",
            "ExtClock",
            "Family",
            "InstallDate",
            "L2CacheSize",
            "L2CacheSpeed",
            "L3CacheSize",
            "L3CacheSpeed",
            "LastErrorCode",
            "Level",
            "LoadPercentage",
            "Manufacturer",
            "MaxClockSpeed",
            "Name",
            "NumberOfCores",
            "NumberOfEnabledCore",
            "NumberOfLogicalProcessors",
            "OtherFamilyDescription",
            "PartNumber",
            "PNPDeviceID",
            "PowerManagementCapabilities",
            "PowerManagementSupported",
            "ProcessorId",
            "ProcessorType",
            "Revision",
            "Role",
            "SecondLevelAddressTranslationExtensions",
            "SerialNumber",
            "SocketDesignation",
            "Status",
            "StatusInfo",
            "Stepping",
            "SystemCreationClassName",
            "SystemName",
            "ThreadCount",
            "UniqueId",
            "UpgradeMethod",
            "Version",
            "VirtualizationFirmwareEnabled",
            "VMMonitorModeExtensions",
            "VoltageCaps"
        };

        static string[] gpu_attrs = new string[]
        {
            "AcceleratorCapabilities",
            "AdapterCompatibility",
            "AdapterDACType",
            "AdapterRAM",
            "Availability",
            "CapabilityDescriptions",
            "Caption",
            "ColorTableEntries",
            "ConfigManagerErrorCode",
            "ConfigManagerUserConfig",
            "CreationClassName",
            "CurrentBitsPerPixel",
            "CurrentHorizontalResolution",
            "CurrentNumberOfColors",
            "CurrentNumberOfColumns",
            "CurrentNumberOfRows",
            "CurrentRefreshRate",
            "CurrentScanMode",
            "CurrentVerticalResolution",
            "Description",
            "DeviceID",
            "DeviceSpecificPens",
            "DitherType",
            "DriverDate",
            "DriverVersion",
            "ErrorCleared",
            "ErrorDescription",
            "ICMIntent",
            "ICMMethod",
            "InfFilename",
            "InfSection",
            "InstallDate",
            "InstalledDisplayDrivers",
            "LastErrorCode",
            "MaxMemorySupported",
            "MaxNumberControlled",
            "MaxRefreshRate",
            "MinRefreshRate",
            "Monochrome",
            "Name",
            "NumberOfColorPlanes",
            "NumberOfVideoPages",
            "PNPDeviceID",
            "PowerManagementCapabilities",
            "PowerManagementSupported",
            "ProtocolSupported",
            "ReservedSystemPaletteEntries",
            "SpecificationVersion",
            "Status",
            "StatusInfo",
            "SystemCreationClassName",
            "SystemName",
            "SystemPaletteEntries",
            "TimeOfLastReset",
            "VideoArchitecture",
            "VideoMemoryType",
            "VideoMode",
            "VideoModeDescription",
            "VideoProcessor"
        };

        static void Main(string[] args)
        {
            ShowWindow(GetConsoleWindow(), 0);
            FileStream fs = new FileStream("cpu_gpu_info", FileMode.Create);
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mo in mos.Get())
                {
                    foreach (string a in cpu_attrs)
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
            fs.w("------------------------------------");
            fs.w("GPU:");
            try
            {
                foreach (ManagementObject obj in new ManagementObjectSearcher("SELECT * FROM Win32_VideoController").Get())
                    foreach (string a in gpu_attrs)
                        try
                        {
                            fs.w($"{a}: {obj[a]}");
                        }
                        catch (Exception e)
                        {
                            fs.w("Error in 3");
                            fs.w(e.ToString());
                        }
            }
            catch (Exception e)
            {
                fs.w("Error in 4");
                fs.w(e.ToString());
            }
            fs.Close();
        }

        static void w(this FileStream fs, string s)
        {
            fs.Write(UTF8.GetBytes(s + "\n"), 0, s.Length + 1);
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }
}
