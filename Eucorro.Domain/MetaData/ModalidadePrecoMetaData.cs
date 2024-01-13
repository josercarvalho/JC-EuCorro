using System;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class ModalidadePrecoMetaData
    {
        [Key]
        public int ModalidadePrecoId { get; set; }

        public int ModalidadeEventoId { get; set; }

        //[Required]
        [Display(Name = "Tipo de inscrição")]
        public int TipoIncricao { get; set; } // 0 - GRATUITA, 1 - PAGA

        [Required]
        [Display(Name = "Data inicial")]
        public DateTime DtInicial { get; set; }

        [Required]
        [Display(Name = "Data final")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DtFinal { get; set; }

        [Required]
        [Display(Name = "Hora inícial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string HoraIni { get; set; }

        [Required]
        [Display(Name = "Encerramento")]
        public string HoraFin { get; set; }

        public decimal Valor { get; set; }
        

        [Display(Name = "Valor desconto em %")] // 0 - SEM DESCONTO.
        public int Desconto { get; set; } // Tipo de Desconto 0 = R$ (moeda), 1 = % (percentual)

        [Display(Name = "*Código do desconto")]
        public string CodigoDesconto { get; set; }

        [Display(Name = "Válido até")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ValidadeDesconto { get; set; }

        [Display(Name = "Valor desconto")]
        public decimal ValorDesconto { get; set; }
    }
}
