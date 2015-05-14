using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;
using ConsoleApplication2.ViewModel;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountControlerTest
    {

        public AccountControlerTest()
        {
        }

        [TestMethod]
        public void withdrawalTest()
        {
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            AccountControler accountControler;
            accountControler = new AccountControler(account);
            try
            {
                accountControler.withraw(123.123m);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e, e);
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void depositTest()
        {
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            AccountControler accountControler;
            accountControler = new AccountControler(account);
            decimal before = accountControler.Account.Balance;
            decimal amount = 1234.1234m;
            accountControler.deposit(amount, 123);
            Assert.AreEqual((before + amount), accountControler.Account.Balance);
        }

        [TestMethod]
        public void outgoingTransactionTest()
        {
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            AccountControler accountControler;
            accountControler = new AccountControler(account);
            accountControler.deposit(501m, 1);
            accountControler.newOutgoingTransaction(500m, 1, 2);
            List<Transaction> transactions = accountControler.OutgoingTransactions();
            Assert.AreEqual(1, transactions.Count,"count");
            Assert.AreEqual(true, transactions[0].Completed);
            Assert.AreEqual((uint)1, transactions[0].ClientCard);
            Assert.AreEqual((uint)2, transactions[0].ForeignCard);
            Assert.AreEqual(500m, transactions[0].Amount);
            Assert.AreEqual(1m, accountControler.Account.Balance);
        }
    }
}
