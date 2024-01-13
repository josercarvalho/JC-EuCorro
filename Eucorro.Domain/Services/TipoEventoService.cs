using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;

namespace EuCorro.Domain.Services
{
    public class TipoEventoService : ServiceBase<EventoTipo>, ITipoEventoService
    {
        private readonly ITipoEventoRepository _tipoServ;
        public TipoEventoService(ITipoEventoRepository repository) : base(repository)
        {
            _tipoServ = repository;
        }
    }                     
}
