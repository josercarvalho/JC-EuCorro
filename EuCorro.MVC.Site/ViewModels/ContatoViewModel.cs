using System.ComponentModel.DataAnnotations;

namespace EuCorro.MVC.Site.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public int ContatoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }

    }
}