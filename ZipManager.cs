using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ZipWork
{
    public class ZipManager
    {

        private string wPath;
        private string wInfo;
        private string ZipFileName;
        public int FileCount;

        public ZipManager()
        {
            wInfo = "";
        }
        public int FilesCount(string wLocalPath)
        {
            int wFileCount = Directory.GetFiles(wLocalPath, "*.zip", SearchOption.TopDirectoryOnly).Length;

            return wFileCount;
        }


        public void CheckZipFolder()
        {
            string[] ZipFolder = Directory.GetFiles(wPath, "*.zip");

            foreach (string filename in ZipFolder)
            {
                ZipFileName = filename;
                string wZip = Path.GetFileName(filename).Substring(0,3).ToUpper();
                FileCount = NumberOfFiles();
                switch (wZip)
                {
                    case "ACT":
                        Console.WriteLine($"Acturis has {FileCount} files");
                        break;
                    case "APP":
                        Console.WriteLine($"Applied has {FileCount} files");
                        break;
                    case "SSP":
                        Console.WriteLine($"SSP has {FileCount} files");
                        break;
                    case "CDL":
                        Console.WriteLine($"CDL has {FileCount} files");
                        break;
                }
                    
            }
        }

        //Count the number of files inside the zip file
        private int NumberOfFiles()
        {
            int wFileCount = 0;

            if (!File.Exists(ZipFileName))
            {
                wInfo = "Incorrect filename.";
                return 0;
            }

            try
            {
                string wfilename = Path.GetFileName(ZipFileName);
                bool wBoolean = wfilename.Contains("ACTURIS");

                using (ZipArchive csZipArchive = ZipFile.OpenRead(ZipFileName))
                {
                    foreach (var entry in csZipArchive.Entries)
                    {
                        if (!string.IsNullOrEmpty(entry.Name))
                            wFileCount += 1;
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                wInfo = "Warning: Authorization required to open that file/object.";
            }
            finally
            {
                if (wInfo.Length > 0)
                    wFileCount = 0;
            }

            return wFileCount;
        }

        public string ZipFilesPath
        {
            get { return wPath; }
            set { wPath = value; }

        }


    }
}
