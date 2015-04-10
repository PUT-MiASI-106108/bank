using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    public class Customer
    {
        private int _id;
        private string _surname;
        private string _name;

        public Customer(int id, string surname, string name)
        {
            this._id = id;
            this._surname = surname;
            this._name = name;
        }

        public int ID
        {
            get { return this._id; }
        }

        public string Surname
        {
            get { return this._surname; }
            set { this._surname = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}
