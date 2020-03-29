using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelExpenses.Web.Data.Entities
{
    public class ExpenseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int Value { get; set; }

        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime CreatedDate { get; set; }

        public DateTime CreatedDateLocal => CreatedDate.ToLocalTime();

        public string ReceiptPath { get; set; }

        public TravelEntity Travel { get; set; }

        public ExpenseTypeEntity ExpenseType { get; set; }

    }
}
