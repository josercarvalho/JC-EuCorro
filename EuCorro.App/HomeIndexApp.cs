using EuCorro.Domain.Interfaces.Services;
using EuCorro.App.Interface;
using System;
using System.Linq;

namespace EuCorro.App
{
    public class HomeIndexApp : IHomeIndexApp
    {
        #region Global Declearation

        private readonly IUsuarioService _userApp;
        private readonly IEventosService _eventoApp;
        private readonly IInscricoesService _inscritosApp;

        #endregion

        #region Construtor

        public HomeIndexApp(IUsuarioService usuario, IEventosService evento, IInscricoesService inscritos)
        {
            _userApp = usuario;
            _eventoApp = evento;
            _inscritosApp = inscritos;
        }

        #endregion

        #region Interface Implementation

        public int EventosRealizados()
        {
            return _eventoApp.GetAll().Where(x => x.DataEvento < DateTime.Now && x.Status.Equals(2)).Count();
        }

        public int InscricoesAbertas()
        {
            return _eventoApp.GetAll().Where(x => x.DataEvento > DateTime.Now && x.Ativo.Equals(true)).Count();
        }

        public int TotalAtletas()
        {
            return _userApp.GetAll().Count();
        }

        public int TotalInscritos()
        {
            return _inscritosApp.GetAll().Where(x => x.Status.Equals(true)).Count();
        }

        #endregion
    }
}
