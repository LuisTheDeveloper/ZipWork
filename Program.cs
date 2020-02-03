using System;
using System.IO;

namespace ZipWork
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            // Get current date and convert to a string
            string TodaysDate = DateTime.Now.ToString("ddMMyyyy");

            SeleniumTech mySelen = new SeleniumTech();  /* Selenium */
            FileManager myFiles = new FileManager();
            ZipManager myZips = new ZipManager();

            //Selenium *    *   Begin
            Console.WriteLine("string for path: (Q to exit)");
            string v = Console.ReadLine();
            if (v.ToUpper() == "Q")
                Environment.Exit(0);
            else
            {
                mySelen.TestNewCode(v);
            }
            
            //Selenium *    *   End

            myZips.TodaysDate = TodaysDate;
            myFiles.FolderName = TodaysDate;
            myFiles.SetPaths();                     // Setting the folder to move files
            myFiles.CurrentExtension = "*.zip";     // Type of files to move
            myFiles.IsSpecific = true;                  // to deal
            myFiles.MoveFilesToPath();

            Console.WriteLine(myFiles.DestinPath);

            myZips.ZipFilesPath = myFiles.DestinPath;   // Tells to the ZIP object what is the current daily zip folder
            myZips.CheckZipFolder();
            string OriginPath = myFiles.OriginalPath;
            myZips.AssignToExcell(OriginPath);


            //myZips.MakeZipFile(myFiles.DestinPath, myFiles.DestinPath + "package");

            Console.WriteLine("Files have been recorded into Excell and are prepared to be sent.");
            Console.WriteLine("Press any key to exit");
            string s = Console.ReadLine();
        }
    }
}