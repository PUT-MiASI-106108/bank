using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;
using ConsoleApplication2.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomerAccountsTest
    {
        private CustomerAccounts Accounts;

        public CustomerAccountsTest()
        {
            Customer cust = new Customer(1,"Kudela", "Gabriel");
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            this.Accounts = new CustomerAccounts(cust, account);
        }

        [TestMethod]
        public void addAccountTest()
        {
            int before = Accounts.Accounts.Count;
            Accounts.addAccount(AccountTypes.Kredytowe);
            Assert.AreEqual(before + 1, Accounts.Accounts.Count);
        }
    }
}
