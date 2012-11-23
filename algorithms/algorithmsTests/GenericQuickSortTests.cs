using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithms;

namespace algorithmsTests
{
    [TestClass]
    public class GenricQuickSortTests
    {
        [TestMethod]
        public void BasicSort()
        {
            var qSort = new GenericQuickSort<int>(12);
            var gen = new Random(15);
            int N = 4000000;
            var array1 = Enumerable.Range(0, N).Select(i => gen.Next(int.MaxValue)).ToArray();
            qSort.Sort(array1);
        }
    }
}
