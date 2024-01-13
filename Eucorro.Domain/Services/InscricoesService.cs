using EuCorro.Domain.Interfaces.Repositories;
using EuCorro.Domain.Interfaces.Services;
using EuCorro.Domain.Models;
using System.Linq;

namespace EuCorro.Domain.Services
{
    public class InscricoesService : ServiceBase<Inscricoes>, IInscricoesService
    {
        #region Global Declearation

        private readonly IInscricoesRepository _inscricoes;

        #endregion

        #region Construtor

        public InscricoesService(IInscricoesRepository inscricoes) : base(inscricoes)
        {
            _inscricoes = inscricoes;
        }

        #endregion

        #region Interface Implementation

        public int TotalInscritos()
        {
            return _inscricoes.GetAll().Where(x => x.Status.Equals(true)).Count();
        }

        #endregion
    }
}
