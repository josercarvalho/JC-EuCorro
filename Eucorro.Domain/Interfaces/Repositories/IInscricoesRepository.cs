using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IInscricoesRepository : IRepositoryBase<Inscricoes>
    {
        IEnumerable<Inscricoes> BuscarPorNome(string nome);
    }
}
