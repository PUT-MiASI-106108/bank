using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Model;

namespace ConsoleApplication2.Model
{
    public class InterestCreditTypeA : InterestType
    {
        public override string InterestTypeName
        {
            get
            {
                return "Type A";
            }
        }

        public override decimal Interest
        {
            get
            {
                return base.Interest;
            }
            protected set
            {
                base.Interest = value;
            }
        }

        protected override void setInterest(decimal amount)
        {
            if (amount < 0m)
            {
                return;
            }
            if (amount < 5000m)
            {
                this.Interest = 0.5m;
                return;
            }
            else if (amount < 100000m)
            {
                this.Interest = 0.4m;
                return;
            }
            else
            {
                this.Interest = 0.3m;
            }
        }
    }
}
