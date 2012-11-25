using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for QuickSortLikeSelectorTests
    /// </summary>
    [TestClass]
    public class QuickSortLikeSelectorTests
    {
    
        [TestMethod]
        public void Select()
        {
            var selector = new QuickSortLikeSelector<MockComparable>();
            var result = selector.Select(new[] {new MockComparable(3)} , 1);
            Assert.AreEqual(3, result.Value, "#H1");

            var selector2 = new QuickSortLikeSelector<int>();
            var array = new int[] {4, 5, 1, 2, 2, 8, 10, 3, 1};
            var result2 = selector2.Select( array , 3);
            Assert.AreEqual(2, result2,"#H2");
            var max = selector2.Select(array, array.Length);
            Assert.AreEqual(10, max, "#H3");
        }
    }
}
