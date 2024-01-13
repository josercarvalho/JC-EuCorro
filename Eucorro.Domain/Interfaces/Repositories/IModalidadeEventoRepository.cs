using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IModalidadeEventoRepository : IRepositoryBase<ModalidadeEvento>
    {
        IEnumerable<ModalidadeEvento> ListarModalidadePorEvento(int evento);
        IEnumerable<ModalidadeEvento> ListarModalidade();
        void RemoveEvento(int evento);
    }
}
