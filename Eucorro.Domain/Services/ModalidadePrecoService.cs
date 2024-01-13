using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;

namespace EuCorro.Domain.Services
{
    public class ModalidadePrecoService : ServiceBase<ModalidadePreco>, IModalidadePrecoService
    {
        #region Global Declearation

        private readonly IModalidadePrecoRepository _modalidadePreco;

        #endregion

        #region Construtor

        public ModalidadePrecoService(IModalidadePrecoRepository repository) : base(repository)
        {
            _modalidadePreco = repository;
        }

        public void RemmovePrco(int modalidade)
        {
            _modalidadePreco.RemmovePrco(modalidade);
        }

        #endregion
    }
}
