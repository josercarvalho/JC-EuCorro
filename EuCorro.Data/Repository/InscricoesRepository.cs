using System;
using System.Collections.Generic;
using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Models;

namespace EuCorro.Data.Repository
{
    public class InscricoesRepository : RepositoryBase<Inscricoes>, IInscricoesRepository
    {
        public IEnumerable<Inscricoes> BuscarPorNome(string nome)
        {
            throw new NotImplementedException();
        }
    }
}
