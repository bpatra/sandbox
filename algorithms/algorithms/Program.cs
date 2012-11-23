using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace algorithms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //static void Main()
        //{
        //    var gen = new Random(15);
        //    int N = 4000000;
        //    var array1 = Enumerable.Range(0, N).Select(i => gen.Next(int.MaxValue)).ToArray();
        //    var array2 = (int[]) array1.Clone();
        //    var watch = Stopwatch.StartNew();
        //    ParallelInMergeSort.ParallelSort2(array1, 0, array1.Length-1);
        //    Console.WriteLine("total time elapsed in parallel " + watch.Elapsed.TotalSeconds.ToString());
        //    watch.Reset();
        //    watch.Start();
        //    HeapSort.Sort(array2);
        //    Console.WriteLine("total time elapsed in regular " + watch.Elapsed.TotalSeconds.ToString());

        //    Console.ReadLine();
           
        //}

        static void Main()
        {
         

        }

        public static void View(int[] array)
        {
            for(int i=0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
