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

        // Total number of files inside each zip file
        private int TotalNumFiles;

        public int FileCount;

        public int ActurisNB;
        public int ActurisMTA;
        public int ActurisRNC;

        public int AppliedNB;
        public int AppliedMTA;
        public int AppliedRNC;

        public int CDLNB;
        public int CDLMTA;
        public int CDLRNC;

        public int SSPNB;
        public int SSPMTA;
        public int SSPRNC;

        public ZipManager()
        {
            wInfo = "";
        }
        public int FilesCount(string wLocalPath)
        {
            int wFileCount = Directory.GetFiles(wLocalPath, "*.zip", SearchOption.TopDirectoryOnly).Length;

            return wFileCount;
        }

        // Read each zip file from the current daily folder here:
        public bool CheckZipFolder()
        {
            string[] ZipFolder = Directory.GetFiles(wPath, "*.zip");

            TotalNumFiles = 0;
            // Looping through all zip files in the daily zip folder:
            Console.WriteLine("Counting number of files inside each zip file...");
            foreach (string filename in ZipFolder)
            {
                ZipFileName = filename; // Get the zip filename
                FileCount = NumberOfItems();
                TotalNumFiles += FileCount;
                Console.WriteLine($"filename {ZipFileName} has {FileCount} files inside.");
                if (!(CheckProvider(ZipFileName, FileCount)))
                {
                    Console.WriteLine($"File:{ZipFileName} is Wrong");
                }
            }
            Console.WriteLine($"Total number of files to be processed: {TotalNumFiles}.");
            return true;
        }

        //Count the number of files inside the zip file
        private int NumberOfItems()
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
                using ZipArchive csZipArchive = ZipFile.OpenRead(ZipFileName);
                    foreach (var entry in csZipArchive.Entries)
                    {
                        if (!string.IsNullOrEmpty(entry.Name))
                        {
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
                {
                    wFileCount = 0;
                }
            }

            return wFileCount;
        }

        private bool CheckProvider(string wZipFileName, int FilesCount)
        {
            // Acturis Processing
            if (wZipFileName.ToUpper().Contains("ACTURIS") && wZipFileName.ToUpper().Contains("NB"))
            {
                ActurisNB = FilesCount;
                return true;
            }
            if (wZipFileName.ToUpper().Contains("ACTURIS") && wZipFileName.ToUpper().Contains("MTA"))
            {
                ActurisMTA = FilesCount;
                return true;
            }   
            if (wZipFileName.ToUpper().Contains("ACTURIS") && wZipFileName.ToUpper().Contains("RNL"))
            {
                ActurisRNC = FilesCount;
                return true;
            }

            // Applied Processing
            if (wZipFileName.ToUpper().Contains("APPLIED") && wZipFileName.ToUpper().Contains("NB"))
            {
                AppliedNB = FilesCount;
                return true;
            }
            if (wZipFileName.ToUpper().Contains("APPLIED") && wZipFileName.ToUpper().Contains("MTA"))
            {
                AppliedMTA = FilesCount;
                return true;
            }
            if (wZipFileName.ToUpper().Contains("APPLIED") && wZipFileName.ToUpper().Contains("RNL"))
            {
                AppliedRNC = FilesCount;
                return true;
            }
                
            // CDL Processing
            if (wZipFileName.ToUpper().Contains("CDL") && wZipFileName.ToUpper().Contains("NB"))
            {
                CDLNB = FilesCount;
                return true;
            }
            if (wZipFileName.ToUpper().Contains("CDL") && wZipFileName.ToUpper().Contains("MTA"))
            {
                CDLMTA = FilesCount;
                return true;
            }
            if (wZipFileName.ToUpper().Contains("CDL") && wZipFileName.ToUpper().Contains("RNL"))
            {
                CDLRNC = FilesCount;
                return true;
            }
                
            // SSP Processing
            if (wZipFileName.ToUpper().Contains("SSP") && wZipFileName.ToUpper().Contains("NB"))
            {
                SSPNB = FilesCount;
                return true;
            }
                
            if (wZipFileName.ToUpper().Contains("SSP") && wZipFileName.ToUpper().Contains("MTA"))
            {
                SSPMTA = FilesCount;
                return true;
            }
                
            if (wZipFileName.ToUpper().Contains("SSP") && wZipFileName.ToUpper().Contains("RNL"))
            {
                SSPRNC = FilesCount;
                return true;
            }
                
            return false;
        }

        public void AssignToExcell(string ExcellPath)
        {
            ExcellInterface myXls = new ExcellInterface();

            myXls.ActurisNB = this.ActurisNB;
            myXls.ActurisMTA = this.ActurisMTA;
            myXls.ActurisRNC = this.ActurisRNC;

            myXls.AppliedNB = this.AppliedNB;
            myXls.AppliedMTA = this.AppliedMTA;
            myXls.AppliedRNC = this.AppliedRNC;

            myXls.CDLNB = this.CDLNB;
            myXls.CDLMTA = this.CDLMTA;
            myXls.CDLRNC = this.CDLRNC;

            myXls.SSPNB = this.SSPNB;
            myXls.SSPMTA = this.SSPMTA;
            myXls.SSPRNC = this.SSPRNC;

            myXls.SheetName = TodaysDate;
            myXls.OpenXls(ExcellPath);  // Open Xls files here and do all the check
        }
        public bool MakeZipFile(string ZipFolder, string FileZipName)
        {
            Console.WriteLine($"Zipping all zip files from {ZipFolder} into {FileZipName}...");
            

            ZipFile.CreateFromDirectory(ZipFolder, FileZipName);
            return true;
        }

        public string ZipFilesPath
        {
            get { return wPath; }
            set { wPath = value; }

        }

        public string TodaysDate { get; set; }
    }
}
