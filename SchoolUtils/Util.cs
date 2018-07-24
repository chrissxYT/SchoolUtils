using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SchoolUtils
{
    static class Util
    {
        public static void reg_save(Stream s)
        {
            RegistryKey[] roots = new RegistryKey[]
            {
                Registry.ClassesRoot,
                Registry.CurrentConfig,
                Registry.CurrentUser,
                Registry.DynData,
                Registry.LocalMachine,
                Registry.PerformanceData,
                Registry.Users
            };

            s.Write("<registry>\r\n", Encoding.Unicode);

            try
            {
                foreach(RegistryKey rk in roots)
                    try
                    {
                        s.Write($"<key name=\"{xml_esc(rk.Name)}\"", Encoding.Unicode);
                        foreach (string val in rk.GetValueNames())
                            try
                            {
                                s.Write($" {xml_esc(val)}=\"{xml_esc(rk.GetValue(val).ToString())}\"", Encoding.Unicode);
                            }
                            catch { }
                        s.Write(" />\r\n", Encoding.Unicode);
                        foreach(string skname in rk.GetSubKeyNames())
                            try
                            {
                                append_key(rk.OpenSubKey(skname, false), s);
                            }
                            catch { }
                        rk.Close();
                    }
                    catch { }
            }
            catch { }

            s.Write("</registry>", Encoding.Unicode);
        }

        public static void Write(this Stream s, string ss, Encoding e) => s.Write(e.GetBytes(ss), 0, e.GetByteCount(ss));

        static void append_key(RegistryKey rk, Stream s)
        {
            s.Write($"<key name=\"{rk.Name}\"", Encoding.Unicode);
            foreach (string val in rk.GetValueNames())
                try
                {
                    s.Write($" {xml_esc(val)}=\"{xml_esc(rk.GetValue(val).ToString())}\"", Encoding.Unicode);
                }
                catch { }
            s.Write(" />", Encoding.Unicode);
            foreach (string skname in rk.GetSubKeyNames())
                try
                {
                    append_key(rk.OpenSubKey(skname, false), s);
                }
                catch { }
            rk.Dispose();
        }

        public static List<string> installed_apps
        {
            get
            {
                List<string> l = new List<string>();
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (string skName in rk.GetSubKeyNames())
                    try
                    {
                        l.Add(rk.OpenSubKey(skName).GetValue("DisplayName").ToString());
                    }
                    catch { }
                l.Sort();
                return l;
            }
        }

        public static List<string> apps_with_paths
        {
            get
            {
                List<string> l = new List<string>();
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths");
                foreach (string skn in rk.GetSubKeyNames())
                    try
                    {
                        l.Add(rk.OpenSubKey(skn, false).GetValue(null).ToString());
                    }
                    catch { }
                return l;
            }
        }

        public static void copy_dir(string src, string dest)
        {
            Directory.CreateDirectory(dest);

            foreach (string s in Directory.GetFiles(src))
                File.Copy(s, dest + "\\" + s.Split('\\').last());

            foreach (string s in Directory.GetDirectories(src))
                copy_dir(s, dest + "\\" + s.Split('\\').last());
        }

        public static T last<T>(this T[] array) => array[array.Length - 1];

        public static T last<T>(this List<T> list) => list[list.Count - 1];

        static string xml_esc(string s) => s.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
    }
}
