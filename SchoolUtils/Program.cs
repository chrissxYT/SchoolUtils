using System;
using System.IO;
using System.Windows.Forms;

namespace SchoolUtils
{
    static class Program
    {
        public static Stream s;

        [STAThread]
        static void Main()
        {
            s = new BufferedStream(File.Open("..\\sulog", FileMode.Create, FileAccess.Write), 64 * 1024);
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch(Exception e)
            {
                Util.SulogWrite(e);
            }
            finally
            {
                s.Flush();
                s.Close();
            }
        }
    }
}
