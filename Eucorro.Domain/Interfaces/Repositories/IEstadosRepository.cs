using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IEstadosRepository : IRepositoryBase<Estado>
    {
        IEnumerable<Estado> BuscarPorPais(int pais);
    }
}
