using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class TransactionTest
    {
        private Transaction Transaction;

        public TransactionTest()
        {
        }

        [TestMethod]
        public void dateTest()
        {
            Assert.AreEqual(
                DateTime.Now,
                new Transaction(0, 0, 0, 0, TransactionTypes.Outgoing).Date);
        }

        [TestMethod]
        public void wrongTransactionTypeTest()
        {
            try
            {
                this.Transaction = new Transaction(0, 0, 0, 0, "abcd");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("TransactionType", e.ParamName);
                Assert.IsTrue(e.Message.Contains("abcd is not a valid transaction type"));
            }
        }
    }
}
