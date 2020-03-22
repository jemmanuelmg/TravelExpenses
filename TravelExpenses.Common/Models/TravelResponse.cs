using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelExpenses.Common.Models
{
    public class TravelResponse
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string City { get; set; }

        public ICollection<ExpenseResponse> Expenses { get; set; }

        public UserResponse User { get; set; }

        public float TotalCost => Expenses == null ? 0 : Expenses.Sum(t => t.Value);

        public int ExpensesCount => Expenses == null ? 0 : Expenses.Count;
    }
}
