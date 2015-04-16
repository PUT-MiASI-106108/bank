﻿using System;
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

        public void deposit(decimal amount)
        {
            this._account.deposit(amount);
        }
    }
}