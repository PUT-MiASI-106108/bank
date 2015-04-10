using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2;
using ConsoleApplication2.Model;

namespace ConsoleApplication2
{
    public class Account
    {
        private string _accountType;
        private int _cardNumber;
        private int _clientId;
        private decimal _balance;
        private InterestType InterestType;

        public Account(string accountType, int clientId, int cardNumber)
        {
            this._balance = 0m;
            this._clientId = clientId;
            this._cardNumber = cardNumber;
            if (accountType.Equals(AccountTypes.Oszczednosciowe) || accountType.Equals(AccountTypes.Kredytowe))
                this._accountType = accountType;
            else 
                throw new ArgumentException(accountType+" is not a valid account type","AccountType");
        }

        public bool isWithdrawalPossible(decimal amount)
        {
            if (this._balance > amount)
                return true;
            else if (this._accountType.Equals(AccountTypes.Kredytowe))
                return true;
            else return false;
        }

        public void withdraw(decimal amount)
        {
            if (this.isWithdrawalPossible(amount))
                this._balance -= amount;
            else
                throw new ArgumentOutOfRangeException("Balance",amount+" is more than you have");
        }

        public void deposit(decimal amount)
        {
            this._balance += amount;
        }

        public string AccountType
        {
            get { return this._accountType; }
        }

        public int CardNumber
        {
            get { return this._cardNumber; }
        }

        public decimal Balance
        {
            get { return this._balance; }
        }

        public int ClientId
        {
            get { return this._clientId; }
        }

        
    }
}
