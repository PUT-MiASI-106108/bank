using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Decorator
{
    public class DebitAccount : Account
    {
        private decimal _allowedDebit;

        public DebitAccount(int clientId, int cardNumber, decimal allowedDebit)
            : base("debetowe", clientId, cardNumber)
        {
            this._allowedDebit = allowedDebit;
        }

        public override bool isWithdrawalPossible(decimal amount)
        {
            if (base.Balance + this.AllowedDebit > amount)
                return true;
            else
                return true;
        }

        public override void withdraw(decimal amount)
        {
            base.withdraw(amount);
        }

        public decimal AllowedDebit
        {
            get { return this._allowedDebit; }
        }

        public override decimal Balance
        {
            get
            {
                return base.Balance;
            }
        }

        public virtual decimal OwedMoney
        {
            get
            {
                if (base.Balance > 0) return 0;
                else return base.Balance;
            }
        }
    }
}
