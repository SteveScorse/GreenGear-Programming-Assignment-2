using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Assignment_2
{
    public class Loan
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Tools Tool { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsReturned { get; set; }

        public Loan(int iD, Customer customer, Tools tool, DateTime loanDate, DateTime dueDate, bool isReturned)
        {
            Id = iD;
            Customer = customer;
            Tool = tool;
            LoanDate = loanDate;
            DueDate = dueDate;
            IsReturned = isReturned;
        }
    }
}
