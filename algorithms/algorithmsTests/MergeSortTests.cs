using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void BasicSort()
        {
            var gen = new Random(44);
            var iSort = new MergeSort<MockComparable>();
            foreach (var N in new[] { 1, 3, 5, 10 , 100000 })
            {
                var mocks = Enumerable.Range(0, N).Select(i => new MockComparable(gen.Next(0, 10))).ToArray();
                iSort.Sort(mocks);
                Assert.IsTrue(mocks.IsSorted(), "#D" + N);
            }
        }

        [TestMethod]
        public void ParallelSort()
        {
            var gen = new Random(44);
            const int cpu = 4;
            var mergeSort = new MergeSort<MockComparable>();
            foreach (var N in new[] { 1, 3, 5, 10, 100000 })
            {
                var mocks = Enumerable.Range(0, N).Select(i => new MockComparable(gen.Next(0, 10))).ToArray();
                mergeSort.ParallelSort(mocks, cpu);
                Assert.IsTrue(mocks.IsSorted(), "#E" + N);
            }
        }

        [TestMethod]
        public void ViewSpeedUp()
        {
             var gen = new Random(15);
            int N = 4000000;
            var array1 = Enumerable.Range(0, N).Select(i => new MockComparable(gen.Next(int.MaxValue))).ToArray();
            var array2 = (MockComparable[]) array1.Clone();
            var watch = Stopwatch.StartNew();

            var mSort = new MergeSort<MockComparable>();
            mSort.ParallelSort(array1, 4);
            Console.WriteLine(@"total time elapsed in parallel merge sort " + watch.Elapsed.TotalSeconds.ToString());
            watch.Reset();
            watch.Start();
            mSort.Sort(array2);
            Console.WriteLine(@"total time elapsed in regular merge sort " + watch.Elapsed.TotalSeconds.ToString());
        }
    }
}
