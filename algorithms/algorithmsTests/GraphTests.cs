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
    public class GraphTests
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
            var graph = new Graph(2);
            graph.Add(0, edge0);
            graph.Add(1, edge1);
        }
    }
}
