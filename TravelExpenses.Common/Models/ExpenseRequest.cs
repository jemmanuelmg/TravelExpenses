using System;
using System.Collections.Generic;
using System.Text;

namespace TravelExpenses.Common.Models
{
    public class ExpenseRequest
    {
        public int TravelId { get; set; }

        public int Value { get; set; }

        public string Comment { get; set; }

        public byte[] PictureArray { get; set; }

        public int ExpenseTypeId { get; set; }

    }
}
