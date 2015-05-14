using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2.Mediator;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class MediatorTests
    {
        [TestMethod]
        public void resolveTransactionsTest()
        {
            Mediator mediator = new Mediator();
            mediator.Banks.Add(new ConsoleApplication2.ViewModel.Bank(1234));
            mediator.Banks.Add(new ConsoleApplication2.ViewModel.Bank(2345));

            mediator.Banks[0].addCustomer("Bartłomiej", "Lubiatowski");
            mediator.Banks[1].addCustomer("Gabriel", "Kudela");

            mediator.Banks[0].CustomerAccounts[0].Accounts[0].deposit(10000m, 1);
            mediator.Banks[0].CustomerAccounts[0].Accounts[0].newOutgoingTransaction(9999,
                mediator.Banks[0].CustomerAccounts[0].Accounts[0].Account.CardNumber,
                mediator.Banks[1].CustomerAccounts[0].Accounts[0].Account.CardNumber);


            mediator.resolveTransactions();

            Assert.AreEqual(9999, mediator.Banks[1].CustomerAccounts[0].Accounts[0].Account.Balance);
        }
    }
}
