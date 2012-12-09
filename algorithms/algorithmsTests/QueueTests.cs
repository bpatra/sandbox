using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorithms;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for QueueTests
    /// </summary>
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void DeQueueEmpty()
        {
            bool isSuccess = false;
            try
            {
                var queue = new algorithms.Queue<string>();
                queue.DeQueue();

            }
            catch (InvalidOperationException)
            {
                isSuccess = true;
            }
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void DeQueueSingle()
        {
            string content = "toto";
            var queue = new algorithms.Queue<string>();
            queue.EnQueue(content);
            Assert.AreEqual(content, queue.DeQueue());
            Assert.AreEqual(0, queue.Count());
        }

        [TestMethod]
        public void DeQueueDouble()
        {
            string content = "toto";
            var queue = new algorithms.Queue<string>();
            queue.EnQueue(content);
            queue.EnQueue("tata");
            Assert.AreEqual(content, queue.DeQueue());
            Assert.AreEqual(1, queue.Count());
        }

        [TestMethod]
        public void SubtleCount()
        {
            var queue = new algorithms.Queue<string>(5);
            queue.EnQueue("toto");
            queue.EnQueue("tata");
            queue.DeQueue();
            queue.DeQueue();
            Assert.AreEqual(0, queue.Count());
            queue.EnQueue("titi");
            queue.EnQueue("tutu");
            queue.EnQueue("tyty");
            queue.EnQueue("rara");
            Assert.AreEqual(4, queue.Count());

        }


        //[TestMethod]
        //public void OverFlow()
        //{
        //    var queue = new algorithms.Queue<string>(4);
        //    queue.EnQueue("toto");
        //    queue.EnQueue("toto");
        //    queue.EnQueue("toto");
        //    queue.EnQueue("toto");
        //    bool isSuccess = false;
        //    try
        //    {
        //        queue.EnQueue("toto");
        //    }
        //    catch (OverflowException)
        //    {
        //        isSuccess = true;
        //    }
        //    Assert.IsTrue(isSuccess);
        //}
    }
}
