using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Visitor
{
    class ReportAll
    {
        private List<Report> reports;

        public List<Report> Reports
        {
            get { return this.reports; }
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Report report in reports)
            {
                report.Accept(visitor);
            }
        }
    }
}
