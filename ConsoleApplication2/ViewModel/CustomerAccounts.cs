using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.ViewModel
{
    public class CustomerAccounts
    {
        private Customer _customer;
        private List<AccountControler> _accounts;



        public CustomerAccounts(Customer cust, Account acc)
        {
            this._customer = cust;
            this._accounts = new List<AccountControler>();
            this._accounts.Add(new AccountControler(acc));
        }

        public List<AccountControler> Accounts
        {
            get { return this._accounts; }
        }

        public Customer Customer
        {
            get { return this._customer; }
        }

        public void addAccount(string type)
        {
            if (type.Equals(AccountTypes.Kredytowe) || type.Equals(AccountTypes.Oszczednosciowe))
                this._accounts.Add(new AccountControler(new Account(type, this._customer.ID, 1234)));
            else
                throw new Exception();
        }
    }
}
