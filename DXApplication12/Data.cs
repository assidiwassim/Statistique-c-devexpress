using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

using System.IO;
namespace DXApplication12
{
    class Data
    {
        public static void GetDataFromTxtFile(out string[] Data, string FileName)
        {
            string s = System.IO.File.ReadAllText(FileName);
            char split = ',';
            Data = s.Split(split);
          
        }
        public static void GetDataFromExcelFile(out string[] Data, string FileName)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            int rCnt;
            int cCnt;
            int rw = 0;
            int cl = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            rw = range.Rows.Count;
            cl = range.Columns.Count;
            string s = "";
            for (rCnt = 1; rCnt <= rw; rCnt++)
            {
                for (cCnt = 1; cCnt <= cl; cCnt++)
                {
                    s = s + (range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString() + ",";
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            char delimiter = ',';
            Data = s.Split(delimiter);
        }
       
        public static void SaveDataInExcelFile(string FileName, object[] value)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@FileName);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            for (int i = 0; i < value.Length; i++)
                xlWorksheet.Rows[i + 1].Cells[1] = value[i];
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

        }
        public static void SaveDataInTxtFile(string[] data, string File_name)
        {
            File.WriteAllLines(File_name, data);
        }
    }
}
