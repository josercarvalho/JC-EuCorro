using System.Collections.Generic;

namespace EuCorro.Domain.Models
{
    public class EventoForm
    {
        public Evento Evento { get; set; }
        public List<EventoKit> lstEventoKit { get; set; }
        public List<EventoTipo> lstEventoTipo { get; set; }
        public List<Estado> lstEstado { get; set; }
        public List<Modalidade> lstModalidade { get; set; }

    }
}
