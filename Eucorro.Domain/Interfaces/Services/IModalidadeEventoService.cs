using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IModalidadeEventoService : IServiceBase<ModalidadeEvento>
    {
        IEnumerable<ModalidadeEvento> ListarModalidadePorEvento(int evento);
        IEnumerable<ModalidadeEvento> ListarModalidade();
        void RemoveEvento(int evento);
    }
}
