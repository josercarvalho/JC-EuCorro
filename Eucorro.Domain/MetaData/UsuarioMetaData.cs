using EuCorro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class UsuarioMetaData
    {
        [Key]
        public string Id { get; set; }

        [ScaffoldColumn(false)]
        public int PerfilUsuarioId { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string UserName { get; set; }

        [Display(Name = "Foto do Atleta")]
        public string Foto { get; set; }

        [Required]
        [Display(Name = "Data Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public Brasileiro Brasileiro { get; set; }

        public Sexo Sexo { get; set; }

        public Camiseta Camiseta { get; set; }

        [Display(Name = "Contato emergência")]
        public string Contato { get; set; }

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

        public string Celular { get; set; }

        public string WhatsApp { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]    
        public DateTime DataCadastro { get; set; }

        //public virtual int? PontoDeVenda_PontoDeVendasId { get; set; }

        //public virtual int? Inscricoes_InscricoesId { get; set; }
    }
}
