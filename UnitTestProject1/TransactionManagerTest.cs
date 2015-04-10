using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class TransactionManagerTest
    {
        private TransactionManager Transactions;
        private uint _cardNumber;
        private uint _foreignCardNumber;

        public TransactionManagerTest()
        {
            this.Transactions = new TransactionManager();
            _cardNumber = 1;
            _foreignCardNumber = 0;
        }

        [TestMethod]
        public void newIncomingTransactionAmountTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            Assert.AreEqual((uint)500, this.Transactions.getTransactions(_cardNumber)[0].Amount);
        }

        [TestMethod]
        public void newIncomingTransactionCountTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            Assert.AreEqual(3, this.Transactions.getTransactions(_cardNumber).Count);
        }

        [TestMethod]
        public void newIncomingTransactionIDIncrementTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            uint i = 1;
            foreach (Transaction tran in this.Transactions.getTransactions(_cardNumber))
            {
                Assert.AreEqual(i, tran.ID);
                i++;
            }
        }

        [TestMethod]
        public void newIncomingTransactionCardNoTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newIncomingTransaction(500, this._cardNumber,this._foreignCardNumber);
            Transaction tran = this.Transactions.getTransactions(_cardNumber)[0];
            Assert.AreEqual(this._cardNumber, tran.ClientCard);
            Assert.AreEqual(this._foreignCardNumber, tran.ForeignCard);
        }

        [TestMethod]
        public void newIncomingTransactionTransactionTypeTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newIncomingTransaction(500, this._cardNumber, this._foreignCardNumber);
            Transaction tran = this.Transactions.getTransactions(_cardNumber)[0];
            Assert.AreEqual(TransactionTypes.Incoming, tran.TransactionType);
        }

        [TestMethod]
        public void newOutgoingTransactionTransactionTypeTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newOutgoingTransaction(500, this._cardNumber, this._foreignCardNumber);
            Transaction tran = this.Transactions.getTransactions(_cardNumber)[0];
            Assert.AreEqual(TransactionTypes.Outgoing, tran.TransactionType);
        }

        [TestMethod]
        public void getTransactionsTest()
        {
            this.Transactions = new TransactionManager();
            this.Transactions.newOutgoingTransaction(
                500, 
                this._cardNumber, 
                this._foreignCardNumber);
            Transaction tran = this.Transactions.getTransactions(_cardNumber)[0];
            Transaction expected = new Transaction(
                1, 
                this._cardNumber, 
                this._foreignCardNumber, 
                500, 
                TransactionTypes.Outgoing);
            Assert.AreEqual(expected.ID, tran.ID);
            Assert.AreEqual(expected.ClientCard, tran.ClientCard);
            Assert.AreEqual(expected.ForeignCard, tran.ForeignCard);
            Assert.AreEqual(expected.Amount, tran.Amount);
            Assert.AreEqual(expected.TransactionType, tran.TransactionType);
        }
    }
}
