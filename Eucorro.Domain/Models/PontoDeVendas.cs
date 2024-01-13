using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class PontoDeVendas
    {
        public PontoDeVendas()
        {
            Eventos = new List<Evento>();
            Usuarios = new List<Usuario>();
        }

        public int PontoDeVendasId { get; set; }
        public int EventoId { get; set; }
        public string UserId { get; set; }
        public string Local { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

    }
}
