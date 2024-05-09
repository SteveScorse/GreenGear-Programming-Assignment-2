using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_2
{
    internal class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PaymentType { get; set; }
        public int HowManyToolsOnLoan { get; set; }

        public Customer(int iD, string firstName, string lastName, string paymentType, int howManyToolsOnLoan)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            PaymentType = paymentType;
            HowManyToolsOnLoan = howManyToolsOnLoan;
                
        }

    }
}
