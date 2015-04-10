using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Model
{
    public abstract class InterestType
    {
        private string _interestTypeName;

        private decimal _interest;

        virtual protected void setInterest(decimal amount)
        {
            this._interest = amount;
        }

        virtual public decimal Interest
        {
            get { return this._interest; }
            protected set
            {
                this._interest = value;
            }
        }

        virtual public string InterestTypeName
        {
            get { return this._interestTypeName; }
        }
    }
}
