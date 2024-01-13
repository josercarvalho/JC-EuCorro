using EuCorro.Domain.Models;

namespace EuCorro.Domain.Interfaces.Services
{
    public interface IInscricoesService : IServiceBase<Inscricoes>
    {
        int TotalInscritos();
    }
}
