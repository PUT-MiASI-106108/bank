using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2.ViewModel;
using ConsoleApplication2;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void outgoingTransactionTest()
        {
            ConsoleApplication2.ViewModel.Bank bank = new ConsoleApplication2.ViewModel.Bank(1234);
            bank.addCustomer("Bartłomiej", "Lubiatowski");
            bank.addCustomer("Kudela", "Gabriel");
            bank.CustomerAccounts[0].Accounts[0].deposit(50000m, 1);
            bank.CustomerAccounts[0].Accounts[0].newOutgoingTransaction(10000m,
                bank.CustomerAccounts[0].Accounts[0].Account.CardNumber,
                bank.CustomerAccounts[1].Accounts[0].Account.CardNumber);
            try
            {
                List<Transaction> transactions = bank.OutgoingTransactions();
                Assert.AreEqual(10000m,
                    bank.CustomerAccounts[1].Accounts[0].Account.Balance);
            }
            catch (UnauthorizedAccessException ex)
            {
                Assert.Fail("exception thrown");
            }
        }

        [TestMethod]
        public void outgoingTransactionFraudTest()
        {
            ConsoleApplication2.ViewModel.Bank bank = new ConsoleApplication2.ViewModel.Bank(1234);
            bank.addCustomer("Bartłomiej", "Lubiatowski");
            bank.addCustomer("Kudela", "Gabriel");
            bank.CustomerAccounts[0].Accounts[0].deposit(50000m, 1);
            bank.CustomerAccounts[0].Accounts[0].newOutgoingTransaction(10001m,
                bank.CustomerAccounts[0].Accounts[0].Account.CardNumber,
                bank.CustomerAccounts[1].Accounts[0].Account.CardNumber);
            try
            {
                List<Transaction> transactions = bank.OutgoingTransactions();
                Assert.Fail("no exception thrown");
            }
            catch(UnauthorizedAccessException ex)
            {
                Assert.AreEqual("over 10000 tranfer", ex.Message);
            }
        }
    }
}
