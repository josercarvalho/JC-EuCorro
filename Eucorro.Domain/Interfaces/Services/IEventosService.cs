using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IEventosService : IServiceBase<Evento>
    {
        int EventosRealizados();
        IEnumerable<Evento> GetByName(string nome);
        IEnumerable<Evento> ListarInativos();
        IEnumerable<Evento> ListarAtivos();
        IEnumerable<Evento> ProximosEventos();
        void RemoveEvento(int evento);
    }
}
