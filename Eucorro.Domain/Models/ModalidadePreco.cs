using EuCorro.Domain.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(ModalidadePrecoMetaData))]
    public class ModalidadePreco
    {
        public ModalidadePreco()
        {
            this.ModalidadeEventos = new List<ModalidadeEvento>();
        }
        public int ModalidadePrecoId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public int TipoIncricao { get; set; } // 0 - GRATUITA, 1 - PAGA
        public DateTime DtInicial { get; set; }
        public DateTime DtFinal { get; set; }
        public string HoraIni { get; set; }
        public string HoraFin { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorDesconto { get; set; }
        public int Desconto { get; set; } // 0 - SEM DESCONTO.
        //public int TipoDesconto { get; set; } // Tipo de Desconto 0 = R$ (moeda), 1 = % (percentual)
        public string CodigoDesconto { get; set; }
        public DateTime ValidadeDesconto { get; set; }
        public int? ModalidadeEvento_ModalidadeEventoId { get; set; }
        public int? ModalidadeEvento_ModalidadeEventoId1 { get; set; }

        public virtual ModalidadeEvento ModalidadeEvento { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento1 { get; set; }
        public virtual ICollection<ModalidadeEvento> ModalidadeEventos { get; set; }


    }
}
