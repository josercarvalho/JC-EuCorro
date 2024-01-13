using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class ClientesMetaData
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Apelido")]
        public string NomeFantasia { get; set; }

        [Required]
        public string Email { get; set; }

        public string CPF { get; set; }

        [Required]
        public string Contato { get; set; }

        [Required]
        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public int CidadeId { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int EstadoId { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public bool? Ativo { get; set; }

        public string Imagem { get; set; }
    }
}
