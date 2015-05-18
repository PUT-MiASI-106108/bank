using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Factories;

namespace ConsoleApplication2.ViewModel
{
    public class CustomerAccounts
    {
        private Customer _customer;
        private List<AccountControler> _accounts;

        public CustomerAccounts(ICustomerFactory cust, IAccountFactory acc)
        {
            this._customer = cust.CreateCustomer();
            this._accounts = new List<AccountControler>();
            this._accounts.Add(new AccountControler(acc));
        }

        public List<AccountControler> Accounts
        {
            get { return this._accounts; }
            set { this._accounts = value; }
        }

        public Customer Customer
        {
            get { return this._customer; }
        }

        public void addAccount(string type)
        {
            if (type.Equals(AccountTypes.Kredytowe) || type.Equals(AccountTypes.Oszczednosciowe))
                this._accounts.Add(new AccountControler(new AccountFactory(type, this._customer.ID, 1234)));
            else
                throw new Exception();
        }

        public bool isAccountOwner(uint accNumber)
        {
            foreach (AccountControler acc in this._accounts)
            {
                if (acc.Account.CardNumber == accNumber)
                {
                    return true;
                }
            }
            return false;
        }

        //chain of responsibility
        public List<Transaction> OutgoingTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (AccountControler accCont in this._accounts)
            {
                foreach (Transaction trans in accCont.OutgoingTransactions())
                {
                    if (!this.isAccountOwner(trans.ForeignCard))
                    {
                        transactions.Add(trans);
                        trans.Completed = true;
                    }
                    else
                    {
                        if (trans.Amount > 20000)
                        {
                            throw new UnauthorizedAccessException("over 20000 transfer");
                        }
                        else
                        {
                            foreach (AccountControler accContr in this._accounts)
                            {
                                if (accContr.Account.CardNumber == trans.ForeignCard)
                                {
                                    accContr.deposit(trans.Amount, trans.ClientCard);
                                }
                            }
                        }
                    }
                }
            }
            return transactions;
        }
    }
}
