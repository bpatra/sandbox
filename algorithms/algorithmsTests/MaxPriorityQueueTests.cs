using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for MaxPriorityQueueTests
    /// </summary>
    [TestClass]
    public class MaxPriorityQueueTests
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
        public void Maximum()
        {
            var job = new MockJob{Name = "cooking"};
            var priorityQueue = new MaxPriorityQueue<MockJob>(new[]{new KeyValuePair<double, MockJob>(2.0, job) });
            Assert.AreEqual(job.Name, priorityQueue.Maximum().Name,"#E1");

            var job2 = new MockJob{Name = "homework"};
            var job3 = new MockJob{Name = "hoover"};
            priorityQueue = new MaxPriorityQueue<MockJob>(new[] { new KeyValuePair<double, MockJob>(2.0, job), new KeyValuePair<double, MockJob>(1.1, job2), new KeyValuePair<double, MockJob>(2.5, job3)});
            Assert.AreEqual("hoover", priorityQueue.Maximum().Name,"#E2");
        }

        [TestMethod]
        public void ExtractMax()
        {
            var job = new MockJob { Name = "cooking" };
            var priorityQueue = new MaxPriorityQueue<MockJob>(new[] { new KeyValuePair<double, MockJob>(2.0, job) });
            Assert.AreEqual(job.Name, priorityQueue.ExtractMax().Name, "#E2");
            Assert.AreEqual(0, priorityQueue.Count, "#E3");

            var job2 = new MockJob { Name = "homework" };
            var job3 = new MockJob { Name = "hoover" };
            priorityQueue = new MaxPriorityQueue<MockJob>(new[] { new KeyValuePair<double, MockJob>(2.0, job), new KeyValuePair<double, MockJob>(1.1, job2), new KeyValuePair<double, MockJob>(2.5, job3) });
            Assert.AreEqual("hoover", priorityQueue.ExtractMax().Name, "#E4");
            Assert.AreEqual(2, priorityQueue.Count,"#E5");
            Assert.AreEqual("cooking",priorityQueue.ExtractMax().Name,"#E6");
            Assert.AreEqual(1, priorityQueue.Count, "#E7");
        }

        [TestMethod]
        public void IncreaseKey()
        {
            var job = new MockJob { Name = "cooking" };
            var job2 = new MockJob { Name = "homework" };
            var job3 = new MockJob { Name = "hoover" };
            var priorityQueue = new MaxPriorityQueue<MockJob>(new[] { new KeyValuePair<double, MockJob>(2.0, job), new KeyValuePair<double, MockJob>(1.1, job2), new KeyValuePair<double, MockJob>(2.5, job3) });
            priorityQueue.IncreaseKey(1, 3.0);
            Assert.AreEqual("homework", priorityQueue.Maximum().Name,"#E8");
        }
    }
}
