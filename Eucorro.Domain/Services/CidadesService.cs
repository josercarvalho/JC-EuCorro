using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Services
{
    public class CidadesService : ServiceBase<Cidade>, ICidadesService
    {
        private readonly ICidadesRepository _cidadeRepository;

        public CidadesService(ICidadesRepository cidadeRepository)
            : base(cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public IEnumerable<Cidade> BuscarPorEstado(int estado)
        {
            return _cidadeRepository.BuscarPorEstado(estado);
        }
    }
}
