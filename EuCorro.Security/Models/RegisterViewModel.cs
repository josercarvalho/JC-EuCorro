using EuCorro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Security.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {0} deve ter no mínimo dois caracteres {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        public string Foto { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        [Required]
        //[System.Web.Mvc.Remote("ValidarCPF","Cadastro")]
        public string CPF { get; set; }

        [Required]
        public Brasileiro Brasileiro { get; set; }

        public Sexo Sexo { get; set; }

        [Display(Name = "Tamanho da Camiseta")]
        public Camiseta Camiseta { get; set; }

        [Required]
        [Display(Name = "Contato de emergência")]
        public string Contato { get; set; }

        [Required]
        [Display(Name = "Fone do Contato")]
        public string FoneContato { get; set; }


        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string CEP { get; set; }

        [Display(Name = "País")]
        public int PaisId { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Celular { get; set; }

        public string WhatsApp { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
    }
}
