using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ZipWork
{
    public class FileManager
    {
        private string myPath;
        private string wZipPath;
        private string myExtension;
        private bool DevOption;
        private bool FolderTodaysDate;

        public FileManager()
        {
            if (File.Exists("dev.txt"))
                DevOption = true;
            else
                DevOption = false;

            FolderTodaysDate = true;

        }

        // This method creates the folder for the zip files to be downloaded
        public void SetPaths()
        {
            if (DevOption)  //if dev unit testing use a temporary folder
                myPath = "C:\\temp\\";
            else
                myPath = Directory.GetCurrentDirectory() + "\\";

            Console.WriteLine($"Is this path: {myPath} correct? Y=Yes/N=No");
            string response = Console.ReadLine();
            if (response.ToUpper() == "Y")
            {
                if (FolderTodaysDate)
                    wZipPath = myPath + DateTime.Now.ToString("ddMMyyyy") + "\\";
                else
                {
                    Console.WriteLine("Please type destination folder name:");
                    wZipPath = Console.ReadLine();
                }

                // Create the ZIP folder here:
                if (!Directory.Exists(wZipPath))
                    Directory.CreateDirectory(wZipPath);
            }
        }

        // After download, the zip files should be moved 
        // from the original folder - myPath to the new folder - wZipPath
        public bool MoveFilesToPath()
        {
            string[] FilesCollect = Directory.GetFiles(myPath, myExtension);

            foreach (string filename in FilesCollect)
            {
                string wFilename = Path.GetFileName(filename);
                File.Move(filename, wZipPath + wFilename);
            }

            return true;

        }

        public string OriginalPath
        {
            get { return myPath;  }
            set { myPath = value; }
        }

        public string DestinPath
        {
            get { return wZipPath; }
        }

        public string CurrentExtension
        {
            get { return myExtension; }
            set { myExtension = value; }
        }

        public bool DevUsage {
            get { return DevOption; }
        }
    }


}
