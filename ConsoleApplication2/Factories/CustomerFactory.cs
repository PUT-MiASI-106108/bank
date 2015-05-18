using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication2.Factories;

namespace ConsoleApplication2.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        int id;
        string surname;
        string name;
        public CustomerFactory(int id, string surname, string name)
        {
            this.id = id;
            this.surname = surname;
            this.name = name;
        }

        Customer ICustomerFactory.CreateCustomer()
        {
            return new Customer(id, surname, name);
        }
    }
}
