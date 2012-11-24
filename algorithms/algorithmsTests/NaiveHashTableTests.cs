using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace algorithmsTests
{
    /// <summary>
    /// Summary description for NaiveHashTable
    /// </summary>
    [TestClass]
    public class NaiveHashTableTests
    {

        [TestMethod]
        public void Insertion()
        {
            const string mockAdress = "mock adress";
            const int mockAge = 51;
            const string mockName = "Zinedine Zidane";
            var person = new MockPerson() {Adress = mockAdress, Age = mockAge, Name = mockName};

            var hashTable = new NaiveHashTable<MockPerson>();
            var retrievedZizou = hashTable["zizou"] = person;
            Assert.AreEqual(mockName, retrievedZizou.Name,"#Z01");
            Assert.AreEqual(mockAge, retrievedZizou.Age, "#Z02");
            Assert.AreEqual(mockAdress, retrievedZizou.Adress, "#Z03");

            bool isSuccess = false;
            try
            {
                var person2 = new MockPerson();
                hashTable["zizou"] = person2;
            }
            catch (ArgumentException)
            {

                isSuccess = true;
            }
            Assert.IsTrue(isSuccess, "Exception should have been raised.");
        }
    }
}
