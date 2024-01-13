using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Models;

namespace EuCorro.Domain.Services
{
    public class ModalidadeCategoriaService : ServiceBase<ModalidadeCategoria>, IModalidadeCategoriaService
    {
        #region Global Declearation
        private readonly IModalidadeCategoriaRepository _modalidadeCategoria;
        #endregion

        #region Construtor
        public ModalidadeCategoriaService(IModalidadeCategoriaRepository repository) : base(repository)
        {
            _modalidadeCategoria = repository;
        }
        #endregion
    }
}
