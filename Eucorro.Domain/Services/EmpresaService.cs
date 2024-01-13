using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using EuCorro.Domain.Interfaces.Repositories;

namespace EuCorro.Domain.Services
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaServ;
        public EmpresaService(IEmpresaRepository repository) : base(repository)
        {
            _empresaServ = repository;
        }
    }
}
