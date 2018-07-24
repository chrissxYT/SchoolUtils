using System.Drawing.Printing;
using static System.Console;

namespace ListPrinters
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
                WriteLine(printer);
            ReadLine();
        }
    }
}
