using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface ICidadesRepository : IRepositoryBase<Cidade>
    {
        IEnumerable<Cidade> BuscarPorEstado(int estado);
        Cidade BuscarPorNome(string nome);
    }
}
