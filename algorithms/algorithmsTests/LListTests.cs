using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    [TestClass]
    public class LListTests
    {
        [TestMethod]
        public void Add()
        {
            var list = new LList<int>();

            list.Add(new Node<int>(6));
            Assert.AreEqual(6, list.HeadContent);

            list.Add(new Node<int>(5));

            Assert.AreEqual(5, list.HeadContent);

            list.Add(new Node<int>(15));
            Assert.AreEqual(15, list.HeadContent);

        }

        [TestMethod]
        public void Delete()
        {
            var list = new LList<int>();

            var node = new Node<int>(6);
            list.Add(node);

            list.Add(24);
            Assert.AreEqual(24, list.HeadContent);
        }

        [TestMethod]
        public void Search()
        {
            var list = new LList<int>();

            var node = new Node<int>(6);
            list.Add(node);

            list.Add(24);
            Assert.AreEqual(node, list.Search(6));
        }
    }
}
