using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Model;

namespace ConsoleApplication2.Model
{
    class InterestCreditTypeB : InterestType
    {
        public override string InterestTypeName
        {
            get
            {
                return "Type B";
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
            if (amount < 0)
            {
                return;
            }
            this.Interest = 0.6m;
        }

    }
}
