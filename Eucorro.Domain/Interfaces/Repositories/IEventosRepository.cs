using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IEventosRepository : IRepositoryBase<Evento>
    {
        void RemoveEvento(int evento);
        IEnumerable<Evento> ProximosEventos();
    }
}
