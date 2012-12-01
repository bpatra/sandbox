using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for BinarySearchTreeTests
    /// </summary>
    [TestClass]
    public class BinarySearchTreeTests
    {

        [TestMethod]
        public void Insert()
        {
            var tree = new BinarySearchTree<MockComparable>();
            var mock = new MockComparable(3);
            var node = new TNode<MockComparable> { Content = mock };
            tree.Insert(node);

            Assert.AreEqual(3, tree.Maximum().Content.Value, "#A01");
            Assert.AreEqual(3, tree.Minimum().Content.Value, "#A01bis");

            var mock2 = new MockComparable(7);
            var node2 = new TNode<MockComparable> { Content = mock2 };
            tree.Insert(node2);
            Assert.AreEqual(7, tree.Maximum().Content.Value, "#A02");
            Assert.AreEqual(3, tree.Minimum().Content.Value, "#A02bis");
        }

        [TestMethod]
        public void InOrder()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(new TNode<int>{Content = 8});
            tree.Insert(new TNode<int>{ Content = 15 });
            tree.Insert(new TNode<int> { Content = 5});
            tree.Insert(new TNode<int> { Content = 17 });
            tree.Insert(new TNode<int> { Content = 14 });

            var content = new int[] {5, 8, 14, 15, 17};
            var result = tree.CollectInOrder().ToArray();
            Assert.AreEqual(content.Length, result.Length, "#B01");
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(content[i], result[i], "#B"+i);
            }

        }
    }
}
