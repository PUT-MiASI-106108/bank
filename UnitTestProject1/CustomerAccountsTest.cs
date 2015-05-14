using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;
using ConsoleApplication2.ViewModel;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerAccountsTest
    {
        public CustomerAccountsTest()
        {
        }

        [TestMethod]
        public void addAccountTest()
        {
            Customer cust = new Customer(1, "Kudela", "Gabriel");
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            CustomerAccounts Accounts = new CustomerAccounts(cust, account);
            int before = Accounts.Accounts.Count;
            Accounts.addAccount(AccountTypes.Kredytowe);
            Assert.AreEqual(before + 1, Accounts.Accounts.Count);
        }

        [TestMethod]
        public void outgoingTransactionsTest()
        {
            Customer cust = new Customer(1, "Kudela", "Gabriel");
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            CustomerAccounts Accounts = new CustomerAccounts(cust, account);
            Accounts.Accounts[0].deposit(50000m, 1);
            Accounts.Accounts[0].newOutgoingTransaction(500m, 1, 2);

            List<Transaction> transactions = Accounts.OutgoingTransactions();
            Assert.AreEqual(1, transactions.Count);
            Assert.AreEqual(500m, transactions[0].Amount);
            Assert.AreEqual((uint)1, transactions[0].ClientCard);
            Assert.AreEqual((uint)2, transactions[0].ForeignCard);

            Accounts.Accounts[0].newOutgoingTransaction(20001m, 1, 1);

            try
            {
                transactions = Accounts.OutgoingTransactions();
                Assert.Fail("no exception thrown");
            }
            catch (UnauthorizedAccessException e)
            {
                Assert.AreEqual("over 20000 transfer", e.Message);
            }
        }
    }
}
