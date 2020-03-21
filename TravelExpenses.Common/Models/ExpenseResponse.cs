using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenses.Common.Models
{
    class ExpenseResponse
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CreatedDateLocal => CreatedDate.ToLocalTime();

        public string ReceiptPath { get; set; }
        
    }
}
