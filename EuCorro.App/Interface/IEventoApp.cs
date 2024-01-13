using EuCorro.Domain.Models;
using System.Collections.Generic;

namespace EuCorro.App.Interface
{
    public interface IEventoApp : IAppServiceBase<Evento>
    {
        #region Dados do Evento

        IEnumerable<Evento> BuscarPorNome(string nome);
        IEnumerable<Estado> BuscarEstados();
        IEnumerable<Cidade> BuscarPorEstado(int estado);
        IEnumerable<EventoTipo> ListarTipoEvento();
        IEnumerable<Evento> ProximosEventos();

        void CadastraEvento(Evento evento);
        void RemoveEvento(int evento);          

        #endregion

        #region Modalidade

        ModalidadeEvento BuscarModalidade(int id);
        ModalidadePreco BuscarPrecoPorModadlidade(int id);

        IEnumerable<Modalidade> ListarModalidades();

        IEnumerable<ModalidadeEvento> ListarModalidadeEvento(int evento);

        void IncluirModalidade(ModalidadeEvento modalidade);

        void IncluirPrecoModalidade(ModalidadePreco preco);
        void IncluirCategoriaModalidade(ModalidadeCategoria categoria);

        void RemoveModalidade(ModalidadeEvento modalidade);

        #endregion
    }
}
