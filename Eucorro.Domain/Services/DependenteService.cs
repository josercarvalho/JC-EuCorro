using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.Domain.Interfaces.Repositories;

namespace EuCorro.Domain.Services
{
    public class DependenteService : ServiceBase<Dependentes>, IDependenteService
    {
        private readonly IDependentesRepository _dependenteServ;
        public DependenteService(IDependentesRepository repository) : base(repository)
        {
            _dependenteServ = repository;
        }
    }
}
