using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace EuCorro.Domain.Services
{
    public class EstadosService : ServiceBase<Estado>, IEstadosService
    {
        private readonly IEstadosRepository _estado;
        public EstadosService(IEstadosRepository repository) : base(repository)
        {
            _estado = repository;
        }

        public IEnumerable<Estado> BuscaEstados()
        {
            return _estado.GetAll().OrderBy(x => x.Nome);
        }
    }
}
