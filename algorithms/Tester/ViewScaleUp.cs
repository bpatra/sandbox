using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using algorithms;
using System.Diagnostics;

namespace Tester
{
    public class ViewScaleUp
    {
        public static void Start()
        {
            bool first = true;
            while ( first || Console.ReadLine() != "y")
            {
                first = false;
                var generator = new Random(1998);
                const int N = 10000;
                var items = Enumerable.Range(0, N).Select(i => generator.Next(0, int.MaxValue - 1)).ToArray();
                var pMergeSort = new MergeSort<int>();
                Console.WriteLine(@"Change processor affinity in task manager and set the max number of thread...");
                var str = Console.ReadLine();
                int maxThread = int.Parse(str);

                var watch = Stopwatch.StartNew();
                pMergeSort.ParallelSort(items, maxThread);
                Console.WriteLine(@"time elapsed in s.{0}", watch.Elapsed.TotalSeconds);
                Console.WriteLine(@"Press q key to exit");
            }

        }
    }
}
