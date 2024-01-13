using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.MetaData
{
    public class NumeroDoPeitoMetaData
    {
        [Key]
        public int NumeroDoPeitoId { get; set; }
        public int EventoId { get; set; }
        public int ModalidadeEventoId { get; set; }

        [Required]
        [Display(Name = "Número Inicial")]
        public int NumeroIni { get; set; }

        [Required]
        [Display(Name = "Número Final")]
        public int NumeroFin { get; set; }

        [Required]
        public int Total { get; set; }

        [Display(Name = "Número Atual")]
        public long NumeroAtual { get; set; }

        [Display(Name = "Tipo Numeração")]
        public bool TipoNumeracao { get; set; }
    }
}
