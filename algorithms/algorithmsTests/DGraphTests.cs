using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithms;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for GraphTests
    /// </summary>
    [TestClass]
    public class DGraphTests
    {

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Add()
        {
            
            var edge0 = new[] { 1};
            var edge1 = new[] { 0};
            var graph = new DGraph(2);
            graph.Add(0, edge0);
            graph.Add(1, edge1);
        }

        [TestMethod]
        public void BFS()
        {
            var edge0 = new[]{1,2};
            var edge1 = new[] { 3};
            var edge2 = new[] { 3, 1 ,4};
            var edge3 = new[] { 0};
            var edge4 = new[] {3,1 };
            var dgraph = new DGraph(5);
            dgraph.Add(0, edge0);
            dgraph.Add(1, edge1);
            dgraph.Add(2, edge2);
            dgraph.Add(3, edge3);
            dgraph.Add(4, edge4);
            var bfs = dgraph.BFS(1);
            Assert.AreEqual(5, bfs.Count());
            var bfsArr = bfs.ToArray();
            var result = new[] {1, 3,0,2,4};
            for(int i = 0; i < bfsArr.Length; i++)
            {
                Assert.AreEqual(result[i],bfsArr[i]);
            }

        }

    }
}
