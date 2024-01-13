using System.Collections.Generic;   

namespace EuCorro.Domain.Models
{
    public class EventoTipo 
    {
        public EventoTipo()
        {
            Eventos = new List<Evento>();
        }

        public int EventoTipoId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
