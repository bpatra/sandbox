using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for PrintPerf
    /// </summary>
    [TestClass]
    public class PrintPerfTests
    {
        [TestMethod]
        public void PrintPerf()
        {   
            var gen = new Random(15);
            int N = 4000000;
            var array1 = Enumerable.Range(0, N).Select(i => gen.Next(int.MaxValue)).ToArray();
            var array2 = (int[])array1.Clone();
            var watch = Stopwatch.StartNew();
            ParallelInMergeSort.ParallelSort(array1, 0, array1.Length - 1);
            Console.WriteLine("total time elapsed in parallel merge sort " + watch.Elapsed.TotalSeconds.ToString());
            watch.Reset();
            watch.Start();
            HeapSort.Sort(array2);
            Console.WriteLine("total time elapsed in regular merge sort " + watch.Elapsed.TotalSeconds.ToString());
        }

    }
}
