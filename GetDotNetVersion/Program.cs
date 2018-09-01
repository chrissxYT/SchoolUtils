using static System.Convert;
using static System.IO.File;
using static Microsoft.Win32.RegistryKey;
using static Microsoft.Win32.RegistryHive;
using static Microsoft.Win32.RegistryView;

namespace GetDotNetVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = ToInt32(OpenBaseKey(LocalMachine, Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\").GetValue("Release"));
            WriteAllText(".net", "Version: " + (i >= 461808 ? "4.7.2 or later" : i >= 461308 ? "4.7.1 or later" : i >= 460798 ? "4.7 or later" : i >= 394802 ? "4.6.2 or later" : i >= 394254 ? "4.6.1 or later"
            : i >= 393295 ? "4.6 or later" : i >= 393273 ? "4.6 RC or later" : i >= 379893 ? "4.5.2 or later" : i >= 378675 ? "4.5.1 or later" : i >= 378389 ? "4.5 or later" : "No 4.5 or later version detected"));
        }
    }
}
