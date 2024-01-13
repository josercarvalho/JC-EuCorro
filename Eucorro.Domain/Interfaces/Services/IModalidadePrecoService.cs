using EuCorro.Domain.Models;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IModalidadePrecoService : IServiceBase<ModalidadePreco>
    {
        void RemmovePrco(int modalidade);
    }
}
