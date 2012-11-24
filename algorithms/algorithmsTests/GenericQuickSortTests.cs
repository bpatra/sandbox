using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithms;

namespace algorithmsTests
{
    [TestClass]
    public class QuickSortTests
    {
        [TestMethod]
        public void BasicSort()
        {
            var qSort = new QuickSort<int>(12);
            var gen = new Random(15);
            foreach(var N in new[]{1, 3 , 4,5})
            {
                var array1 = Enumerable.Range(0, N).Select(i => gen.Next(int.MaxValue)).ToArray();
                qSort.Sort(array1);
                Assert.IsTrue(array1.IsSorted(),"#A01 " + N);
            }
        }

        [TestMethod]
        public void EmptySort()
        {
            //Test empty array
            var qSort = new QuickSort<Mock>(3);
            qSort.Sort(new Mock[]{});

            bool isSuccess = false;
            try
            {
                qSort.Sort(null);
            }
            catch(ArgumentNullException)
            {
                isSuccess = true;
            }
            Assert.IsTrue(isSuccess, "#Argument null exception should be thrown");
        }
    }
}
