﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2.Factories
{
    public interface ICustomerFactory
    {
        Customer CreateCustomer();
    }
}
