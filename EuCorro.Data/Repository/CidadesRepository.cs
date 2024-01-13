using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace EuCorro.Data.Repository
{
    public class CidadesRepository : RepositoryBase<Cidade>, ICidadesRepository
    {
        public IEnumerable<Cidade> BuscarPorEstado(int estado)
        {
            return _db.Cidade.Where(x => x.EstadoId.Equals(estado)).OrderBy(x => x.Nome);
        }

        public Cidade BuscarPorNome(string nome)
        {
            return _db.Cidade.FirstOrDefault(x => x.Nome.Equals(nome));
        }
    }
}
