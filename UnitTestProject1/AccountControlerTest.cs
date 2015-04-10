using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;
using ConsoleApplication2.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountControlerTest
    {
        AccountControler accountControler;

        public AccountControlerTest()
        {
            Account account = new Account(AccountTypes.Oszczednosciowe, 1, 1);
            this.accountControler = new AccountControler(account);
        }

        [TestMethod]
        public void withdrawalTest()
        {
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
            decimal before = accountControler.Account.Balance;
            decimal amount = 1234.1234m;
            accountControler.deposit(amount);
            Assert.AreEqual((before + amount), accountControler.Account.Balance);
        }
    }
}
