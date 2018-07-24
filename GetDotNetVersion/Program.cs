using Microsoft.Win32;
using System;

namespace GetDotNetVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            int rk = Convert.ToInt32(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\").GetValue("Release"));
            Console.WriteLine("Version: " + (rk >= 461808 ? "4.7.2 or later" : rk >= 461308 ? "4.7.1 or later" : rk >= 460798 ? "4.7 or later" : rk >= 394802 ? "4.6.2 or later" : rk >= 394254 ? "4.6.1 or later"
            : rk >= 393295 ? "4.6 or later" : rk >= 393273 ? "4.6 RC or later" : rk >= 379893 ? "4.5.2 or later" : rk >= 378675 ? "4.5.1 or later" : rk >= 378389 ? "4.5 or later" : "No 4.5 or later version detected"));
        }
    }
}
