using System;
using System.IO;

namespace ZipWork
{
    class Program
    {
        static void Main(string[] args)
        {

            
            FileManager myFiles = new FileManager();
            ZipManager myZips = new ZipManager();
            ExcellInterface myXls = new ExcellInterface();

            myXls.OpenXls();

            myFiles.SetPaths();
            myFiles.CurrentExtension = "*.zip";

            if (myFiles.DevUsage == false)
                myFiles.MoveFilesToPath();

            Console.WriteLine(myFiles.DestinPath);

            myZips.ZipFilesPath = myFiles.DestinPath;
            myZips.CheckZipFolder();
            Console.WriteLine("ok");
            /*ZipFileCS myZip = new ZipFileCS();
            Console.WriteLine(myZip.FilesNumber(devPath));

            myZip.ZipFilePath = ZipPath;
            int wFileCount = myZip.ZipNumberOfFiles();

            if (wFileCount == 0)
                Console.WriteLine($"{myZip.MoreInfo}");
            else
                Console.WriteLine($"The zip file:{myZip.ZipFilePath} has {wFileCount} files inside.");*/

        }
    }
}