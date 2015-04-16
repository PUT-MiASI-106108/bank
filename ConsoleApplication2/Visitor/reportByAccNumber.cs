using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Visitor
{
    public class ReportByAccNumber : Report
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
