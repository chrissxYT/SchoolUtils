using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Text;

namespace SchoolUtils
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
                listBox1.Items.Clear();

                foreach (string a in Util.installed_apps)
                    if (!listBox1.Items.Contains(a))
                        listBox1.Items.Add(a);

                foreach (string a in Util.apps_with_paths)
                    if (!listBox2.Items.Contains(a))
                        listBox2.Items.Add(a);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void cmd(object s, EventArgs ea)
        {
            try
            {
                if (!Directory.Exists("copied_cmd"))
                    Directory.CreateDirectory("copied_cmd");
                File.Copy(@"C:\Windows\System32\cmd.exe", "copied_cmd\\firefox.exe", true);
                Process.Start("copied_cmd\\firefox.exe");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void sevenzip(object s, EventArgs ea)
        {
            try
            {
                Process.Start(@"C:\Program Files\7-Zip\7zFM.exe");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void aces_prg_dir(object s, EventArgs ea)
        {
            try
            {
                Util.copy_dir(source.Text, dest.Text);
                Process.Start("explorer", $"/select,{dest.Text}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void gdrive(object s, EventArgs ea)
        {
            try
            {
                Process.Start("chrome", "https://drive.google.com/drive/my-drive");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void strt_path(object s, EventArgs ea)
        {
            try
            {
                Process.Start(listBox2.SelectedItem.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void reg_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("reg_dump.xml.gz", FileMode.Create), CompressionLevel.Optimal, false), 8192);
                Util.reg_save(bs);
                bs.Flush();
                bs.Close();
                MessageBox.Show("Wrote registry to reg_dump.gz.");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void uninst_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("uninstallable_apps.gz", FileMode.Create), CompressionLevel.Optimal, false), 8192);
                foreach (string a in Util.installed_apps)
                    bs.Write(a + "\r\n", Encoding.UTF8);
                bs.Flush();
                bs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void path_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("apps_with_paths.gz", FileMode.Create), CompressionLevel.Optimal, false), 8192);
                foreach (string a in Util.apps_with_paths)
                    bs.Write(a + "\r\n", Encoding.UTF8);
                bs.Flush();
                bs.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        void desc(object s, EventArgs ea)
        {
            try
            {
                Process.Start("chrome", "https://chrissx.lima-city.de/su_desc.png");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
