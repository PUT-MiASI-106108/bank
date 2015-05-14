using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Mediator
{
    public class Mediator
    {
        public List<Transaction> transactions = new List<Transaction>();
        private List<ViewModel.Bank> _banks;

        public Mediator() 
        {
            this._banks = new List<ViewModel.Bank>();
        }

        public List<ViewModel.Bank> Banks
        {
            get { return this._banks; }
            set { this._banks = value; }
        }

        private void gatherTransactions()
        {
            foreach (ViewModel.Bank bank in this._banks)
            {
                foreach (Transaction trans in bank.OutgoingTransactions())
                {
                    transactions.Add(trans);
                }
            }
        }

        public void resolveTransactions()
        {
            this.gatherTransactions();
            foreach (Transaction trans in transactions)
            {
                uint signature = trans.ForeignCard;
                while (signature > 9999) signature /= 10;
                foreach (ViewModel.Bank bank in this._banks)
                {
                    if (bank.Signature == signature)
                    {
                        bank.IncomingTransaction(trans.ForeignCard, 
                            trans.ClientCard, trans.Amount);
                    }
                }
            }
        }
    }
}
