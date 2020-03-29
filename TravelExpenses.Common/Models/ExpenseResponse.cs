using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenses.Common.Models
{
    public class ExpenseResponse
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CreatedDateLocal => CreatedDate.ToLocalTime();

        public string ReceiptPath { get; set; }

        public ExpenseTypeResponse ExpenseType { get; set; }

    }
}
