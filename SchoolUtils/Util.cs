using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using static System.Text.Encoding;
using static Microsoft.Win32.Registry;
using static System.IO.Path;
using System;

namespace SchoolUtils
{
    static class Util
    {
        public static void reg_save(Stream s)
        {
            RegistryKey[] roots = new RegistryKey[]
            {
                ClassesRoot,
                CurrentConfig,
                CurrentUser,
                DynData,
                LocalMachine,
                PerformanceData,
                Users
            };

            try
            {
                foreach(RegistryKey rk in roots)
                    try
                    {
                        string t = $"\"{xml_esc(rk.Name)}\"";
                        s.Write(Unicode.GetBytes(t), 0, t.Length * 2);
                        foreach (string val in rk.GetValueNames())
                            try
                            {
                                t = $" \"{xml_esc(val)}\"=\"{xml_esc(rk.GetValue(val).ToString())}\"";
                                s.Write(Unicode.GetBytes(t), 0, t.Length * 2);
                            }
                            catch (Exception e)
                            {
                                SulogWrite(e);
                            }
                        s.Write(Unicode.GetBytes("\n"), 0, 2);
                        foreach(string skname in rk.GetSubKeyNames())
                            try
                            {
                                append_key(rk.OpenSubKey(skname, false), s);
                            }
                            catch (Exception e)
                            {
                                SulogWrite(e);
                            }
                        rk.Close();
                    }
                    catch (Exception e)
                    {
                        SulogWrite(e);
                    }
            }
            catch (Exception e)
            {
                SulogWrite(e);
            }
        }

        static void append_key(RegistryKey rk, Stream s)
        {
            string t = $"\"{rk.Name}\"";
            s.Write(Unicode.GetBytes(t), 0, t.Length * 2);
            foreach (string val in rk.GetValueNames())
                try
                {
                    t = $" \"{xml_esc(val)}\"=\"{xml_esc(rk.GetValue(val).ToString())}\"";
                    s.Write(Unicode.GetBytes(t), 0, t.Length * 2);
                }
                catch (Exception e)
                {
                    SulogWrite(e);
                }
            s.WriteLfUnicode();
            foreach (string skname in rk.GetSubKeyNames())
                try
                {
                    append_key(rk.OpenSubKey(skname, false), s);
                }
                catch (Exception e)
                {
                    SulogWrite(e);
                }
            rk.Dispose();
        }

        static byte[] lf_unicode = Unicode.GetBytes("\n");

        public static void WriteLfUnicode(this Stream s)
        {
            s.Write(lf_unicode, 0, 2);
        }

        public static void SulogWrite(string s)
        {
            Program.s.Write(UTF8.GetBytes(s), 0, s.Length);
        }

        public static void SulogWrite(Exception e)
        {
            string s = e.ToString();
            Program.s.Write(UTF8.GetBytes(s), 0, s.Length);
        }

        public static List<string> installed_apps
        {
            get
            {
                List<string> l = new List<string>();
                RegistryKey rk = LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (string skName in rk.GetSubKeyNames())
                    try
                    {
                        l.Add(rk.OpenSubKey(skName).GetValue("DisplayName").ToString());
                    }
                    catch (Exception e)
                    {
                        SulogWrite(e);
                    }
                l.Sort();
                return l;
            }
        }

        public static List<string> apps_with_paths
        {
            get
            {
                List<string> l = new List<string>();
                RegistryKey rk = LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths");
                foreach (string skn in rk.GetSubKeyNames())
                    try
                    {
                        l.Add(rk.OpenSubKey(skn, false).GetValue(null).ToString());
                    }
                    catch (Exception e)
                    {
                        SulogWrite(e);
                    }
                l.Sort();
                return l;
            }
        }

        public static void copy_dir(string src, string dest)
        {
            if(!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            foreach (string s in Directory.GetFiles(src))
                File.Copy(s, Combine(dest, GetFileName(s)));

            foreach (string s in Directory.GetDirectories(src))
                copy_dir(s, Combine(dest, GetDirectoryName(s)));
        }

        public static T last<T>(this T[] array)
        {
            return array[array.Length - 1];
        }

        static string xml_esc(string s)
        {
            return s.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("'", "&apos;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}
