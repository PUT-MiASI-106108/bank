using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Model;

namespace ConsoleApplication2.Visitor
{
    public abstract class Report
    {
        public Account ClientAccount { get; private set; }
        public abstract void Accept(IVisitor visitor);
    }
}
