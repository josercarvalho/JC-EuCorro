using EuCorro.Domain.MetaData;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(NumeroDoPeitoMetaData))]
    public class NumeroDoPeito 
    {
        public int NumeroDoPeitoId { get; set; }
        public int EventoId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public int NumeroIni { get; set; }
        public int NumeroFin { get; set; }
        public int Total { get; set; }
        public long NumeroAtual { get; set; }
        public bool TipoNumeracao { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento { get; set; }

    }
}
