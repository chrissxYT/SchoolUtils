using static System.Console;
using static System.IO.File;

namespace EmergencyTextPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(ReadAllText(args[0]));
            ReadLine();
        }
    }
}
