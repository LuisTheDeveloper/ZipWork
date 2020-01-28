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

            FileManager myFiles = new FileManager();
            ZipManager myZips = new ZipManager();
            ExcellInterface myXls = new ExcellInterface();
           // if (myFiles.DevUsage == false)
            //{

                myFiles.SetPaths();         // Setting the folder to move files
                myFiles.CurrentExtension = "*.zip";     // Type of files to move

                // if (myFiles.DevUsage == false)  
                myFiles.MoveFilesToPath();

                Console.WriteLine(myFiles.DestinPath);

                myZips.ZipFilesPath = myFiles.DestinPath;   // Tells to the ZIP object what is the current daily zip folder
                myZips.CheckZipFolder();

                Console.WriteLine(myZips.ActurisNB);
                Console.WriteLine(myZips.SSPMTA);
            //}
            myXls.ActurisNB = myZips.ActurisNB;
            myXls.ActurisMTA = myZips.ActurisMTA;
            myXls.ActurisRNC = myZips.ActurisRNC;

            myXls.AppliedNB = myZips.AppliedNB;
            myXls.AppliedMTA = myZips.AppliedMTA;
            myXls.AppliedRNC = myZips.AppliedRNC;

            myXls.CDLNB = myZips.CDLNB;
            myXls.CDLMTA = myZips.CDLMTA;
            myXls.CDLRNC = myZips.CDLRNC;

            myXls.SSPNB = myZips.SSPNB;
            myXls.SSPMTA = myZips.SSPMTA;
            myXls.SSPRNC = myZips.SSPRNC;

            myXls.SheetName = TodaysDate;
            myXls.OpenXls();  // Open Xls files here and do all the check

            Console.WriteLine("ok");



        }
    }
}