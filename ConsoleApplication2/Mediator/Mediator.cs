using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Mediator
{
    public class Mediator
    {
        private List<ViewModel.Bank> _banks;

        public Mediator() { }

        public void ResolveTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (ViewModel.Bank bank in this._banks)
            {
                transactions.Concat(bank.OutgoingTransactions());
            }
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
