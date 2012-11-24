using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for GenericInsertionSortTests
    /// </summary>
    [TestClass]
    public class GenericInsertionSortTests
    {

        [TestMethod]
        public void BasicSort()
        {
            var gen = new Random(44);
            var iSort = new GenericInsertionSort<Mock>();
            foreach(var N in new[]{1,3, 5,10})
            {
                var mocks = Enumerable.Range(0, N).Select(i => new Mock(gen.Next( 0, 10))).ToArray();
                iSort.Sort(mocks);
                Assert.IsTrue(mocks.IsSorted() , "#C" + N);
            }
        }
    }
}
