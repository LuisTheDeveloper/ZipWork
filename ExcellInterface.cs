using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace ZipWork
{
    public class ExcellInterface
    {
        private string XlsFile;
        public void OpenXls()
        {
            var fi = new FileInfo(@"c:\temp\Exceptions.xlsm");
            using (var p = new ExcelPackage(fi))
            {
                //Get the Worksheet created in the previous codesample. 
                var ws = p.Workbook.Worksheets["27012020"];
                //Set the cell value using row and column.
                ws.Cells[2, 1].Value = "This is cell A2. It is set to bolds";
                //The style object is used to access most cells formatting and styles.
                ws.Cells[2, 1].Style.Font.Bold = true;
                ws.Cells[4, 3].Value = 99;    //Acturis NB
                    
                //Save and close the package.
                p.Save();
            }
        }

    }
}
