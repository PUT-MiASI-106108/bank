using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Decorator
{
    public class DebitAccountWithInterest : DebitAccount
    {
        private decimal _interestRate;

        public DebitAccountWithInterest(int clientId, int cardNumber, 
            decimal allowedDebit, decimal interestRate) 
            : base(clientId, cardNumber, interestRate)
        {
            this._interestRate = interestRate;
        }

        public override decimal OwedMoney
        {
            get
            {
                if (base.OwedMoney < 0)
                    return OwedMoney * this._interestRate;
                else 
                    return 0;
            }
        }

        public decimal InterestRate
        {
            get { return this._interestRate; }
        }
    }
}
