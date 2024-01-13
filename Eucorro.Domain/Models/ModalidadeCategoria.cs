using EuCorro.Domain.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EuCorro.Domain.Models
{
    [MetadataType(typeof(ModalidadeCategoriaMetaData))]
    public class ModalidadeCategoria
    {
        public ModalidadeCategoria()
        {
            Inscricoes = new List<Inscricoes>();
            Inscritos = new List<Inscritos>();
        }
        public int ModalidadeCategoriaId { get; set; }
        public int ModalidadeEventoId { get; set; }
        public string Descricao { get; set; }
        public int Desconto { get; set; }

        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
        public virtual ICollection<Inscritos> Inscritos { get; set; }
        public virtual ModalidadeEvento ModalidadeEvento { get; set; }

    }
}
