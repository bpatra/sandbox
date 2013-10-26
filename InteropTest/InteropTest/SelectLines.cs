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

        public static void SelectEvenLines(int count)
        {
            var watch = new Stopwatch();
            watch.Start();
            using (var file = File.CreateText(@"C:\resultEvenLines.csv"))
            {
                Range range = null;
                for (int i = 1; i < 2 * count; i += 2)
                {
                    range = Union(i, range, file, watch);
                }
            }
        }

        private static Range Union(int i, Range range, StreamWriter file, Stopwatch watch)
        {
            var currentLine = GetRange(i);
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


        public static void SelectEvenLinesFast(int count)
        {
            
            using (var file = File.CreateText(@"C:\resultEvenLinesFast.csv"))
            {
                for (int i = 1; i < count; i += 10)
                {
                    int[] rows = Enumerable.Range(1, i).Where(k => k%2 == 1).ToArray();
                    var watch = Stopwatch.StartNew();
                    UnionDivideAndConquer(rows, 0, rows.Length - 1);

                    file.WriteLine("{0};{1}", rows.Length, watch.Elapsed.TotalMilliseconds);
                    Log.Trace("{0};{1}", rows.Length, watch.Elapsed.TotalMilliseconds);
                }
            }
        }

        public static Range GetRange(int i)
        {
            return ExcelAddIn.ActiveSheet.Range["A" + i + ":" + "J" + i];
        }

      

        private static Range UnionDivideAndConquer(int[] excelRows, int start, int end)
        {
            if (excelRows.Length == 0) return null;
            if (start == end)
            {
                return GetRange(excelRows[start]);
            }
            int middle = (start + end) / 2;
            Range fastRangeLeft = UnionDivideAndConquer(excelRows, start, middle);
            Range fastRangeRight = UnionDivideAndConquer(excelRows, middle + 1, end);

            return ExcelAddIn.Excel.Union(fastRangeLeft, fastRangeRight);
        }
    }
}
