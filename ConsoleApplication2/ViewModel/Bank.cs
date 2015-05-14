using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.ViewModel
{
    public class Bank
    {
        private int _signature;
        private int _id = 0;
        private int _custId = 0;
        private string _name;

        private List<CustomerAccounts> _customerAccounts;

        public Bank(int signature)
        {
            this._signature = signature;
            this._customerAccounts = new List<CustomerAccounts>();
        }

        public void addCustomer(string name, string surname)
        {
            Customer customer = new Customer(this.CustId, name, surname);
            Account acc = new Account(AccountTypes.Oszczednosciowe,customer.ID,
                this.Signature*1000+this.ID);
            this._customerAccounts.Add(new CustomerAccounts(customer, acc));
        }

        public void IncomingTransaction(uint custId, uint sourceId, decimal amount)
        {
            foreach (CustomerAccounts customer in this._customerAccounts)
            {
                if (customer.isAccountOwner(custId))
                {
                    foreach (AccountControler accCont in customer.Accounts)
                    {
                        if (accCont.Account.CardNumber == custId)
                        {
                            accCont.deposit(amount, sourceId);
                        }
                    }
                }
            }
        }

        //chain of responsibility
        public List<Transaction> OutgoingTransactions()
        {
            List<Transaction> unresolvedTransactions = new List<Transaction>();
            foreach(CustomerAccounts custAcc in this._customerAccounts)
            {
                foreach (Transaction trans in custAcc.OutgoingTransactions())
                {
                    if (!(trans.ForeignCard % (this.Signature * 1000) == 
                        (trans.ForeignCard - 1000 * this.Signature)))
                    {
                        unresolvedTransactions.Add(trans);
                    }
                    else
                    {
                        if (trans.Amount > 10000)
                        {
                            throw new UnauthorizedAccessException("over 10000 tranfer");
                        }
                        else
                        {
                            this.IncomingTransaction(trans.ForeignCard, trans.ClientCard, trans.Amount);
                        }
                    }
                }
            }
            return new List<Transaction>();
        }

        private int ID
        {
            get 
            { 
                this._id++;
                return this._id;
            }
        }

        private int CustId
        {
            get
            {
                this._custId++;
                return this._custId;
            }
        }

        public int Signature
        {
            get { return this._signature; }
            private set { this._signature = value; }
        }
    }
}
