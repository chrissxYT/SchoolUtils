using System;
using System.Threading;
using System.Windows.Forms;

namespace SchoolUtils
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }, 1024*1024*64).Start();
        }
    }
}
