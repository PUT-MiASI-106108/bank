using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.ViewModel
{
    public class AccountControler : TransactionManager
    {
        private Account _account;

        public AccountControler(Account acc)
        {
            this._account = acc;
        }

        public Account Account
        {
            get { return this._account; }
        }

        public void withraw(decimal amount)
        {
            if (this._account.isWithdrawalPossible(amount))
                this._account.withdraw(amount);
            else
                throw new Exception();
        }

        public void deposit(decimal amount, uint sourceId)
        {
            this._account.deposit(amount);
            base.newIncomingTransaction(amount, (uint)this.Account.CardNumber, sourceId, true);
        }

        //chain of responsibility
        public List<Transaction> OutgoingTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (Transaction trans in base.Transactions)
            {
                if (!trans.Completed && trans.TransactionType.Equals(TransactionTypes.Outgoing))
                {
                    try
                    {
                        this.withraw(trans.Amount);
                        transactions.Add(trans);
                        trans.Completed = true;
                    }
                    catch { }
                }
            }
            return transactions;
        }
    }
}
