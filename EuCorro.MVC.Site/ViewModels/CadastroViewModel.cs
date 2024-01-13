using EuCorro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.MVC.Site.ViewModels
{
    public class CadastroViewModel
    {
        [Key]
        public string UserId { get; set; }

        [ScaffoldColumn(false)]
        public int PerfilUsuarioId { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Display(Name ="Confirmação da Senha")]
        public string ConfirmaSenha { get; set; }

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

        [Display(Name ="Tamanho da Camiseta")]
        public Camiseta Camiseta { get; set; }

        [Required]
        [Display(Name ="Contato de emergência")]
        public string Contato { get; set; }

        [Required]
        [Display(Name ="Fone do Contato")]
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