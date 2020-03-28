using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelExpenses.Common.Models
{
    public class TravelRequest
    {

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string City { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public Guid UserId { get; set; }

    }
}
