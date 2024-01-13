using System;
using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class Modalidade 
    {
        public Modalidade()
        {
            Eventos = new List<Evento>();
            ModalidadeEventos = new List<ModalidadeEvento>();
        }

        public int ModalidadeId { get; set; }
        public string Nome { get; set; }
        public int Distancia { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<ModalidadeEvento> ModalidadeEventos { get; set; }
    }
}
