using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IInscricaoApp : IAppServiceBase<Inscricoes>
    {
        #region Dados da Inscrição

        IEnumerable<Evento> ListarEventos();
        IEnumerable<Inscricoes> ListarPorNome(string nome);
        IEnumerable<Estado> BuscarEstados();
        IEnumerable<Cidade> BuscarPorEstado(int estado);
        IEnumerable<EventoTipo> ListarTipoEvento();

        void CadastraInscricao(Inscricoes inscricao);
        void Removeinscricao(int inscricao);
        void IncluirInscrito(Inscritos inscrito);
        void RemoveInscrito(int inscrito);
        void CadastrarPagamento(int inscricao);

        #endregion Dados da Inscrição

        #region Interface Implementation

        Usuario BuscarUsuario(string usuario);

        ModalidadeCategoria BuscarCategoria(int evento);

        ModalidadePreco BuscarPrecoPorModadlidade(int evento);

        IEnumerable<Inscritos> ListarInscritos(int inscricao);

        IEnumerable<Modalidade> ListarModalidades();

        IEnumerable<ModalidadeEvento> ListarModalidadeEvento(int evento);

        #endregion Interface Implementation

    }
}
