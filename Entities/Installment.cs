using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe_Fixacao_Interfaces.Entities
{
    class Installment
    {
        public DateOnly DueDate { get; set; }

        public double Amount { get; set; }

        public Installment(DateOnly dueDate, double amount)
        {
            DueDate = dueDate;
            Amount = amount;
        }
    }
}
