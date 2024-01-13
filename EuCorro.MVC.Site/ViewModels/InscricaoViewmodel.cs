using EuCorro.Domain.Enum;
using EuCorro.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.MVC.Site.ViewModels
{
    public class InscricaoViewmodel
    {
        [Key]
        public string UserId { get; set; }
        
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        [Display(Name = "Confirmação da Senha")]
        public string ConfirmaSenha { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        public Sexo Sexo { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

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
        [Display(Name = "Contato de emergência")]
        public string Contato { get; set; }

        [Required]
        [Display(Name = "Fone do Contato")]
        public string FoneContato { get; set; }

        public bool ConfirmaRegulamento { get; set; }

        public virtual Evento Evento { get; set; }

        public virtual ModalidadeEvento Modalidades { get; set; }

        public class ListaInscricoes
        {
            public int Id { get; set; }
            public string UserId { get; set; }
            public int EventoId { get; set; }
            public string Nome { get; set; }
            public ModalidadeEvento Modalidades { get; set; }
            public ModalidadeCategoria Categorias { get; set; }

            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
            public decimal Valor { get; set; }
        }

    }
}