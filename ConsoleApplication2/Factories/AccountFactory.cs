using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Factories
{
    public class AccountFactory : IAccountFactory
    {
        string accType;
        int clientId;
        int cardNo;

        public AccountFactory(string accType, int clientId, int cardNo)
        {
            this.accType = accType;
            this.clientId = clientId;
            this.cardNo = cardNo;
        }

        public Account CreateAccount()
        {
            return new Account(accType, clientId, cardNo);
        }
    }
}
