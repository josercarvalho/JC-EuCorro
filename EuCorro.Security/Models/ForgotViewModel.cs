using System.ComponentModel.DataAnnotations;

namespace EuCorro.Security.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
