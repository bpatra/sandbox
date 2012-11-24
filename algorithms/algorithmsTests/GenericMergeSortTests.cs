using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    [TestClass]
    public class GenericMergeSortTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var gen = new Random(44);
            var iSort = new GenericMergeSort<Mock>();
            foreach (var N in new[] { 1, 3, 5, 10 , 100000 })
            {
                var mocks = Enumerable.Range(0, N).Select(i => new Mock(gen.Next(0, 10))).ToArray();
                iSort.Sort(mocks);
                Assert.IsTrue(mocks.IsSorted(), "#D" + N);
            }
        }
    }
}
