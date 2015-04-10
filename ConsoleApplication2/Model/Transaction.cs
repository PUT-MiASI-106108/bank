using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Transaction
    {
        private uint _id;
        private uint _amount;
        private uint _clientCard;
        private uint _foreignCard;
        private string _transactionType;
        private DateTime _date;

        public Transaction(uint id, uint clientCard, uint foreignCard, uint amount, string transactionType)
        {
            this._id =  id;
            this._clientCard = clientCard;
            this._foreignCard = foreignCard;
            this._amount = amount;
            this._date = DateTime.Now;
            if (transactionType.Equals(TransactionTypes.Incoming) || transactionType.Equals(TransactionTypes.Outgoing))
                this._transactionType = transactionType;
            else
                throw new ArgumentException(transactionType+" is not a valid transaction type","TransactionType");
        }

        public uint ID
        {
            get { return this._id; }
        }

        public uint Amount
        {
            get { return this._amount; }
        }

        public uint ClientCard
        {
            get { return this._clientCard; }
        }

        public uint ForeignCard
        {
            get { return this._foreignCard; }
        }

        public string TransactionType
        {
            get { return this._transactionType; }
        }

        public DateTime Date
        {
            get { return this._date; }
        }
    }
}
