using EuCorro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class DependentesMetaData
    {
        [Key]
        public int DependenteId { get; set; }
        public int UserId { get; set; }

        [Required]
        [Display(Name = "*Nome Completo")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "*Data nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "*Nome do Contato")]
        public string Contato { get; set; }

        [Required]
        [Display(Name = "*Telefone do Contato")]
        public string FoneContato { get; set; }
    }
}
