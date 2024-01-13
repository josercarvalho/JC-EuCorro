using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IEstadosService : IServiceBase<Estado>
    {
        IEnumerable<Estado> BuscaEstados();
    }
}
