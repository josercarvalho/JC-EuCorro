using EuCorro.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class InscricoesMetaData
    {
        [Key]
        public int InscricoesId { get; set; }
        public int EventoId { get; set; }
        public string UserId { get; set; }
        public int ModalidadeEventoId { get; set; }

        //[Required]
        //public Camiseta Camiseta { get; set; }

        [Required]
        public decimal Valor { get; set; }

        //[Display(Name = "Desconto Idoso")]
        //public bool DescontoIdoso { get; set; }

        [Display(Name = "Valor Boleto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorBoleto { get; set; }


        [Display(Name = "Valor Total")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorTotal { get; set; }

        //[Display(Name = "Número")]
        //public int Numero { get; set; }
        public bool Status { get; set; }

        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DataCadastro { get; set; }
    }
}
