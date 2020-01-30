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
        private bool PlumZipFiles;

        public string FolderName;

        public FileManager()
        {
            if (File.Exists("dev.txt"))
                DevOption = true;
            else
                DevOption = false;
        }

        // This method creates the folder for the zip files to be downloaded
        public void SetPaths()
        {
            if (DevOption)  //if dev unit testing use a temporary folder
                myPath = "C:\\temp\\";
            else
                myPath = Directory.GetCurrentDirectory() + "\\";

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
                if (this.PlumZipFiles)
                    MovePlumFilesToPath(filename, wFilename);
                else
                {
                    File.Move(filename, wZipPath + wFilename);
                    Console.WriteLine($"File {filename} moved to {wZipPath + wFilename}");
                }
            }
            return true;
        }
        
        private void MovePlumFilesToPath(string wPlumFullPath, string wPlumFilename)
        {
            string FullPath = wZipPath + wPlumFilename;

            if(wPlumFilename.Contains("EDI messages") && wPlumFilename.Length > 27)
            {
                if(wPlumFilename.Contains("NB") || wPlumFilename.Contains("MTA") || wPlumFilename.Contains("RNL"))
                {
                    File.Move(wPlumFullPath, FullPath);
                    Console.WriteLine($"File {wPlumFilename} moved to {wZipPath + wPlumFilename}");
                }
            }
            Console.WriteLine($"File {wPlumFilename} is not a valid Plum file!");
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

        public bool IsPlum {
            get { return PlumZipFiles ; }
            set { PlumZipFiles = value ; }
        }
    }


}
