using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using static SchoolUtils.Util;
using static System.Text.Encoding;
using static System.Diagnostics.Process;

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

                foreach (string a in installed_apps)
                    if (!listBox1.Items.Contains(a))
                        listBox1.Items.Add(a);

                foreach (string a in apps_with_paths)
                    if (!listBox2.Items.Contains(a))
                        listBox2.Items.Add(a);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void cmd(object s, EventArgs ea)
        {
            try
            {
                if (!Directory.Exists("copied_cmd"))
                    Directory.CreateDirectory("copied_cmd");
                File.Copy(@"C:\Windows\System32\cmd.exe", "copied_cmd\\firefox.exe", true);
                Start("copied_cmd\\firefox.exe");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void sevenzip(object s, EventArgs ea)
        {
            try
            {
                Start(@"C:\Program Files\7-Zip\7zFM.exe");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void aces_prg_dir(object s, EventArgs ea)
        {
            try
            {
                copy_dir(source.Text, dest.Text);
                Start("explorer", $"/select,{dest.Text}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void gdrive(object s, EventArgs ea)
        {
            try
            {
                Start("chrome", "https://drive.google.com/drive/my-drive");
                SulogWrite("Started chrome with URL \"https://drive.google.com/drive/my-drive\".\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void strt_path(object s, EventArgs ea)
        {
            try
            {
                Start(listBox2.SelectedItem.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void reg_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("reg_dump.gz", FileMode.Create), CompressionLevel.Optimal, false), 8192);
                reg_save(bs);
                bs.Flush();
                bs.Close();
                SulogWrite("Wrote reg_dump() to reg_dump.gz.\n");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void uninst_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("uninstallable_apps.gz", FileMode.Create), CompressionLevel.Optimal, false), 8192);
                foreach (string a in installed_apps)
                {
                    bs.Write(Unicode.GetBytes(a), 0, a.Length * 2);
                    bs.WriteLfUnicode();
                }
                bs.Flush();
                bs.Close();
                SulogWrite("Wrote uninst_dump() to uninstallable_apps.gz.\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }

        void path_dump(object s, EventArgs ea)
        {
            try
            {
                BufferedStream bs = new BufferedStream(new GZipStream(File.Open("apps_with_paths.gz", FileMode.Create, FileAccess.Write), CompressionLevel.Optimal, false), 1024 * 16);
                foreach (string a in apps_with_paths)
                {
                    bs.Write(Unicode.GetBytes(a), 0, a.Length * 2);
                    bs.WriteLfUnicode();
                }
                bs.Flush();
                bs.Close();
                SulogWrite("Wrote path_dump() to apps_with_paths.gz.\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }
        
        void desc(object s, EventArgs ea)
        {
            try
            {
                Start("chrome", "https://chrissx.lima-city.de/su_desc.png");
                SulogWrite("Started chrome with URL \"https://chrissx.lima-city.de/su_desc.png\".\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
            try
            {
                Start("chrome", "http://79.221.55.215/cdn/su_desc.png");
                SulogWrite("Started chrome with URL \"http://79.221.55.215/cdn/su_desc.png\".\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                SulogWrite(e);
            }
        }
    }
}
