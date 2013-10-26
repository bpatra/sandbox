using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace InteropTest
{
    public static class SelectLines
    {
        public static void SelectAllLines(int count)
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var file = File.CreateText(@"C:\result.csv"))
            {
                Range range = null;
                for (int i = 1; i < count; i++)
                {
                    range = Union(i, range, file, watch);
                }
            }
        }

        private static Range Union(int i, Range range, StreamWriter file, Stopwatch watch)
        {
            var currentLine = ExcelAddIn.ActiveSheet.Range["A" + i + ":" + "J" + i];
            if (range == null)
            {
                range = currentLine;
            }
            else
            {
                range = ExcelAddIn.Excel.Union(range, currentLine);
                file.WriteLine("{0};{1}", i, watch.Elapsed.TotalMilliseconds);
                Log.Trace("{0};{1}", i, watch.Elapsed.TotalMilliseconds);
            }
            return range;
        }

        public static void SelectEvenLines(int count)
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var file = File.CreateText(@"C:\resultEvenLines.csv"))
            {
                Range range = null;
                for (int i = 1; i < 2*count; i+=2)
                {
                    range = Union(i, range, file, watch);
                }
            }
        }


        public static void SelectEvenLinesDivideAndConquer(int count)
        {
            
        }
    }
}
