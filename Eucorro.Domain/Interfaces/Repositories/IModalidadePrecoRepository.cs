using EuCorro.Domain.Models;

namespace EuCorro.Domain.Interfaces.Repositories
{
    public interface IModalidadePrecoRepository : IRepositoryBase<ModalidadePreco>
    {
        void RemmovePrco(int modalidade);
    }
}
