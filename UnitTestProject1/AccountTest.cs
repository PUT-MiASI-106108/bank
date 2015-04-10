using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountTest
    {
        Account account;

        [TestMethod]
        public void isWithdrawalPossibleKredytowe()
        {
            this.account = new Account(AccountTypes.Kredytowe, 0, 0);
            Assert.IsTrue(account.isWithdrawalPossible(10m));
        }

        [TestMethod]
        public void isWithdrawalPossibleOszczednoscioweTooMuch()
        {
            this.account = new Account(AccountTypes.Oszczednosciowe, 0, 0);
            Assert.IsFalse(account.isWithdrawalPossible(10m));
        }

        [TestMethod]
        public void isWithdrawalPossibleOszczednoscioweEnough()
        {
            this.account = new Account(AccountTypes.Oszczednosciowe, 0, 0);
            this.account.deposit(10.0000001m);
            Assert.IsTrue(account.isWithdrawalPossible(10m));
        }

        [TestMethod]
        public void withdrawOszczednoscioweTest()
        {
            this.account = new Account(AccountTypes.Oszczednosciowe, 0, 0);
            this.account.deposit(100m);
            this.account.withdraw(99.99m);
            Assert.AreEqual(0.01m, this.account.Balance);
        }

        [TestMethod]
        public void depositTest()
        {
            this.account = new Account(AccountTypes.Oszczednosciowe, 0, 0);
            this.account.deposit(10m);
            Assert.AreEqual(10m, this.account.Balance);
        }

        [TestMethod]
        public void withdrawOverBalanceSavingsTest()
        {
            this.account = new Account(AccountTypes.Oszczednosciowe, 0, 0);
            try
            {
                this.account.withdraw(10m);
                Assert.Fail("no exception thrown");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("Balance", e.ParamName);
                Assert.IsTrue(e.Message.Contains("10 is more than you have"));
            }
        }

        [TestMethod]
        public void withdrawOverBalanceCreditTest()
        {
            this.account = new Account(AccountTypes.Kredytowe, 0, 0);
            try
            {
                this.account.withdraw(10m);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail("unexpected exception");
            }
        }

        [TestMethod]
        public void wrongAccountType()
        {
            try
            {
                this.account = new Account("asd", 0, 0);
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("AccountType", e.ParamName);
                Assert.IsTrue(e.Message.Contains("asd is not a valid account type"));
            }
        }
    }
}
