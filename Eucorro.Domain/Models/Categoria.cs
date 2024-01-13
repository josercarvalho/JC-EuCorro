using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Eventos = new List<Evento>();
            ModalidadeEventos = new List<ModalidadeEvento>();
        }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TipoDesconto { get; set; } // 0 = REAL | 1 = PERCENTUAL
        public decimal Desconto { get; set; } // 0 PARA SEM DESCONTO

        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<ModalidadeEvento> ModalidadeEventos { get; set; }
    }
}
