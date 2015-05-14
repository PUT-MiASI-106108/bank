using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class TransactionManager
    {
        private uint _id;

        private List<Transaction> _transactions;

        public TransactionManager()
        {
            this._id = 0;
            this._transactions = new List<Transaction>();
        }

        public void newIncomingTransaction(decimal amount, uint cardNo1, uint cardNo2)
        {
            _transactions.Add(new Transaction(this.ID, cardNo1, cardNo2, amount, TransactionTypes.Incoming));
        }

        public void newIncomingTransaction(decimal amount, uint cardNo1, uint cardNo2, bool completed)
        {
            _transactions.Add(new Transaction(this.ID, cardNo1, cardNo2, amount, TransactionTypes.Incoming) { Completed = true });
        }

        public void newOutgoingTransaction(decimal amount, uint cardNo1, uint cardNo2)
        {
            _transactions.Add(new Transaction(this.ID, cardNo1, cardNo2, amount, TransactionTypes.Outgoing));
        }

        public List<Transaction> getTransactions(uint cardNo)
        {
            return 
            (
                from transaction in this._transactions 
                where (uint)transaction.ClientCard == cardNo 
                select transaction
            ).ToList();
        }

        public List<Transaction> Transactions
        {
            get { return this._transactions; }
            protected set { this._transactions = value; }
        }

        public List<Transaction> UncompletedTransactions
        {
            get 
            { 
                return 
                (
                    from transaction in this._transactions 
                    where (bool)transaction.Completed == false 
                    select transaction
                ).ToList();
            }
        }

        public void CompleteTransaction(uint id)
        {
            foreach (Transaction trans in this._transactions)
            {
                if (trans.ID == id)
                {
                    trans.Completed = true;
                    return;
                }
            }
        }

        private uint ID
        {
            get
            {
                _id++;
                return this._id;
            }
        }
    }
}
