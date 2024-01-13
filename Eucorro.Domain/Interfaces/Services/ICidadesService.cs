using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface ICidadesService : IServiceBase<Cidade>
    {
        IEnumerable<Cidade> BuscarPorEstado(int estado);
    }
}
