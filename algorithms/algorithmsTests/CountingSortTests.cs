using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for CountingSortTests
    /// </summary>
    [TestClass]
    public class CountingSortTests
    {
        [TestMethod]
        public void BasicSort()
        {
            var items = new[] {1};
            var countingSort = new CountingSort(2);
            //countingSort.Sort(new int[]{});
            //countingSort.Sort(items);
            //Assert.AreEqual(1, items[0], "#Z01");

            countingSort = new CountingSort(7);
            items = new[] {5, 6, 6, 3, 2, 1, 3, 4};
            countingSort.Sort(items);
            Assert.IsTrue(items.IsSorted(), "#Z02");
        }
    }
}
