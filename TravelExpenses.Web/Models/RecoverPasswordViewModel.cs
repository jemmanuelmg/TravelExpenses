using System.ComponentModel.DataAnnotations;

namespace TravelExpenses.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
