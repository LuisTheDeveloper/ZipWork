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
        private bool SpecZipFiles;

        public string FolderName;


        public FileManager()
        {
            if (File.Exists("dev.txt"))
            {
                DevOption = true;
            }
            else
            {
                DevOption = false;
            }
        }

        // This method creates the folder for the zip files to be downloaded
        public void SetPaths()
        {
            if (DevOption)  //if dev unit testing use a temporary folder 
            {
                myPath = "C:\\users\\lmagalhaes\\downloads\\";
            }
            else
            {
                myPath = Directory.GetCurrentDirectory() + "\\";
            }

            wZipPath = myPath + FolderName + "\\";
            Console.WriteLine($"Is this path: {wZipPath} correct? Y=Yes/N=No");
            string response = Console.ReadLine();
            if (response.ToUpper() == "N")
            {
                Console.WriteLine("Please type destination folder name:");
                wZipPath = Console.ReadLine();
            }

            // Create the ZIP folder here:
            if (!Directory.Exists(wZipPath))
            {
                Directory.CreateDirectory(wZipPath);
                Console.WriteLine($"Directory created:{wZipPath}");
            }
                    
        }

        // After download, the zip files should be moved 
        // from the original folder - myPath to the new folder - wZipPath
        public bool MoveFilesToPath()
        {
            string[] FilesCollect = Directory.GetFiles(myPath, myExtension);

            Console.WriteLine("Moving Files...");
            foreach (string filename in FilesCollect)
            {
                string wFilename = Path.GetFileName(filename);
                if (this.SpecZipFiles)
                {
                    MoveSpecFilesToPath(filename, wFilename);
                } 
                else
                {
                    File.Move(filename, wZipPath + wFilename);
                    Console.WriteLine($"File {filename} moved to {wZipPath + wFilename}");
                }
            }
            return true;
        }
        
        private bool MoveSpecFilesToPath(string wSpecFullPath, string wSpecFilename)
        {
            string FullPath = wZipPath + wSpecFilename;

            if((wSpecFilename.Contains("EDI messages") || wSpecFilename.Contains("EDI mesages")) && wSpecFilename.Length > 27)
            {
                if(wSpecFilename.Contains("NB") || wSpecFilename.Contains("MTA") || wSpecFilename.Contains("RNL"))
                {
                    //check if the destinantion file already exists
                    if (File.Exists(FullPath))
                    {
                        File.Delete(FullPath);
                    }
                    File.Move(wSpecFullPath, FullPath);
                    Console.WriteLine($"File {wSpecFilename} moved to {wZipPath + wSpecFilename}");
                    return true;
                }
            }
            Console.WriteLine($"File {wSpecFilename} is not a valid Spec file!");
            return false;
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

        public bool IsSpecific {
            get { return SpecZipFiles ; }
            set { SpecZipFiles = value ; }
        }
    }


}
