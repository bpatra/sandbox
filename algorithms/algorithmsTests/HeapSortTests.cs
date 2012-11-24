using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for HeapSort
    /// </summary>
    [TestClass]
    public class HeapSortTests
    {
        [TestMethod]
        public void BasicSort()
        {
            var gen = new Random(15);
            foreach (var N in new[] { 1, 3, 4, 5 })
            {
                var heapSort = new HeapSort<int>();
                var array1 = Enumerable.Range(0, N).Select(i => gen.Next(int.MaxValue)).ToArray();
                heapSort.Sort(array1);
                Assert.IsTrue(array1.IsSorted(), "#B01 " + N);
            }
        }
    }
}
