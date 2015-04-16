using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Visitor
{
    public interface IVisitor
    {
        void Visit(ReportByAccNumber report);
        void Visit(ReportByMonth report);
    }
}
