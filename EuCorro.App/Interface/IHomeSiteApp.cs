using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IHomeSiteApp
    {
        int TotalInscritos();
        int TotalAtletas();
        IEnumerable<Evento> ListarBanner();
        IEnumerable<Evento> ProximosEvenetos();
        IEnumerable<Usuario> Aniversariantes();
        IEnumerable<Inscricoes> Participantes();
        Estado BuscaEstado(int id);
        Cidade BuscaCidade(int id);
    }
}
