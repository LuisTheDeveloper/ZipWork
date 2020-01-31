using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace ZipWork
{
    public class ExcellInterface
    {
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

        public string SheetName;

        public void OpenXls(string ExcellPath)
        {
            string ExcellFilePath = ExcellPath + "Exceptions.xlsx";
            var fi = new FileInfo(@ExcellFilePath);
            using (var p = new ExcelPackage(fi))
            {
                Console.WriteLine($"Opening Excel File {fi.Name} to save zipfile count...");
                //Get the Worksheet created in the previous codesample. 
                FillUpExcel(p);                 
                //Save and close the package.
                p.Save();
                p.Dispose();
            }
        }

        private void FillUpExcel(ExcelPackage p)
        {
            Console.WriteLine($"Adding data to worksheet {SheetName}");
            p.Workbook.Worksheets.Copy("Template", SheetName);
            var ws = p.Workbook.Worksheets[SheetName];
            //Set the cell value using row and column.
            ws.Cells["C4"].Value = this.ActurisNB;
            ws.Cells["E4"].Value = this.ActurisMTA;
            ws.Cells["G4"].Value = this.ActurisRNC;

            ws.Cells["C5"].Value = this.AppliedNB;
            ws.Cells["E5"].Value = this.AppliedMTA;
            ws.Cells["G5"].Value = this.AppliedRNC;

            ws.Cells["C6"].Value = this.CDLNB;
            ws.Cells["E6"].Value = this.CDLMTA;
            ws.Cells["G6"].Value = this.CDLRNC;

            ws.Cells["C7"].Value = this.SSPNB;
            ws.Cells["E7"].Value = this.SSPMTA;
            ws.Cells["G7"].Value = this.SSPRNC;
        }
    }
}
