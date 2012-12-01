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
            var node = new TNode<MockComparable>(mock);
            tree.Insert(node);

            Assert.IsNull(node.Parent, "#A01");

            var mock2 = new MockComparable(7);
            var node2 = new TNode<MockComparable>(mock2);
            tree.Insert(node2);
            Assert.AreEqual(node2, node.RightChild, "#A02");
            Assert.AreEqual(node, node2.Parent, "#A02bis");
        }

        [TestMethod]
        public void MaximumMinimum()
        {
            var tree = new BinarySearchTree<MockComparable>();
            var mock = new MockComparable(3);
            var node = new TNode<MockComparable>(mock);
            tree.Insert(node);

            Assert.AreEqual(3, tree.Maximum().Content.Value, "#AA01");
            Assert.AreEqual(3, tree.Minimum().Content.Value, "#AA01bis");

            var mock2 = new MockComparable(7);
            var node2 = new TNode<MockComparable>(mock2);
            tree.Insert(node2);
            Assert.AreEqual(7, tree.Maximum().Content.Value, "#AA02");
            Assert.AreEqual(3, tree.Minimum().Content.Value, "#AA02bis");
        }

        [TestMethod]
        public void InOrder()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(new TNode<int>( 8));
            tree.Insert(new TNode<int>( 15 ));
            tree.Insert(new TNode<int> (  5));
            tree.Insert(new TNode<int> ( 17 ));
            tree.Insert(new TNode<int> ( 14 ));

            var content = new int[] {5, 8, 14, 15, 17};
            var result = tree.CollectInOrder().ToArray();
            Assert.AreEqual(content.Length, result.Length, "#B01");
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(content[i], result[i], "#B"+i);
            }
        }

        [TestMethod]
        public void TestSuccessor()
        {
            var tree = new BinarySearchTree<int>();
            var firstNode = new TNode<int> (7);
            tree.Insert(firstNode);
            Assert.IsNull(tree.Sucessor(firstNode), "#C01");

            var secondNode = new TNode<int>( 4 );
            tree.Insert(secondNode);
            Assert.AreEqual(firstNode, tree.Sucessor(secondNode), "#C02");

            var thirdNode = new TNode<int> (5) ;
            tree.Insert(thirdNode);
            Assert.AreEqual(thirdNode, tree.Sucessor(secondNode), "#C03");
            Assert.IsNull(tree.Sucessor(firstNode), "#C04");

            var fourthNode = new TNode<int>(9);
            tree.Insert(fourthNode);
            Assert.IsNull(tree.Sucessor(fourthNode), "#C05");
        }

        [TestMethod]
        public void Search()
        {
            var tree = new BinarySearchTree<int>();
            var firstNode = new TNode<int>(7);
            tree.Insert(firstNode);
            var secondNode = new TNode<int>(4);
            tree.Insert(secondNode);
            var thirdNode = new TNode<int>(5);
            tree.Insert(thirdNode);
            var fourthNode = new TNode<int>(9);
            tree.Insert(fourthNode);

            Assert.AreEqual(secondNode, tree.Search(4),"#D01");
            Assert.AreEqual(fourthNode, tree.Search(9), "#D02");
        }

        [TestMethod]
        public void Delete()
        {
            var tree = new BinarySearchTree<int>();
            var firstNode = new TNode<int>(17);
            tree.Insert(firstNode);
            var secondNode = new TNode<int>(7);
            tree.Insert(secondNode);
            var thirdNode = new TNode<int>(4);
            tree.Insert(thirdNode);
            var fourthNode = new TNode<int>(15);
            tree.Insert(fourthNode);
            tree.Insert(new TNode<int>(10));
            tree.Insert(new TNode<int>(16));
            tree.Insert(new TNode<int>(8));
            tree.Insert(new TNode<int>(12));

            tree.Delete(secondNode);
            var result = tree.CollectInOrder().ToArray();
            var expected = new int[] {4,8,10,12,15,16,17};
            for(int i=0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i], "#E"+i);
            }

            tree.Delete(thirdNode);
            result = tree.CollectInOrder().ToArray();
            expected = new int[] {8, 10, 12, 15, 16, 17 };
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i], "#EE" + i);
            }

            tree.Delete(firstNode);
            result = tree.CollectInOrder().ToArray();
            expected = new int[] { 8, 10, 12, 15, 16};
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i], "#EEE" + i);
            }

        }
    }
}
