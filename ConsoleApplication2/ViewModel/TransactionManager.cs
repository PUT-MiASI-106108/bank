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

        private List<Transaction> Transactions;

        public TransactionManager()
        {
            this._id = 0;
            this.Transactions = new List<Transaction>();
        }

        public void newIncomingTransaction(uint amount, uint cardNo1, uint cardNo2)
        {
            Transactions.Add(new Transaction(this.ID, cardNo1, cardNo2, amount, TransactionTypes.Incoming));
        }

        public void newOutgoingTransaction(uint amount, uint cardNo1, uint cardNo2)
        {
            Transactions.Add(new Transaction(this.ID, cardNo1, cardNo2, amount, TransactionTypes.Outgoing));
        }

        public List<Transaction> getTransactions(uint cardNo)
        {
            return (from transaction in this.Transactions where (uint)transaction.ClientCard == cardNo select transaction).ToList();
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
