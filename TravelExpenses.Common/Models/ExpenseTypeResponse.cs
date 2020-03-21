using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenses.Common.Models
{
    class ExpenseTypeResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<ExpenseResponse> Expenses { get; set; }
    }
}
