using System.ComponentModel.DataAnnotations;

namespace EuCorro.Security.Models
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Número do Telefone")]
        public string PhoneNumber { get; set; }
    }
}
