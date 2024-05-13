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
        public string Customer { get; set; }
        public string Tool { get; set; }
        public string LoanDate { get; set; }
        public string DueDate { get; set; }
        public string IsReturned { get; set; }

        public Loan(int iD, string customer, string tool, string loanDate, string dueDate, string isReturned)
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
