using System.ComponentModel.DataAnnotations;

namespace EuCorro.Security.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Telefone")]
        public string Number { get; set; }
    }
}
