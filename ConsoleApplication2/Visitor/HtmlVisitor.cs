using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Visitor
{
    public class HtmlVisitor : IVisitor
    {
        public string Output
        {
            get { return this.m_output; }
        }
        private string m_output = "";

        public void Visit(ReportByAccNumber report)
        {
            //TODO add html markers to the m_output string
            this.m_output += report.ClientAccount.CardNumber;
        }

        public void Visit(ReportByMonth report)
        {
            //TODO add html markers to the m_output string
            this.m_output += report.ClientAccount.Balance;
        }
    }
}
