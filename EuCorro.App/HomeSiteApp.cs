using EuCorro.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using EuCorro.Domain.Models;
using EuCorro.Domain.Interfaces.Services;
using System.Globalization;

namespace EuCorro.App
{

    public class HomeSiteApp : IHomeSiteApp
    {
        #region Global Declearation

        private readonly IUsuarioService _userApp;
        private readonly IEventosService _eventoApp;
        private readonly IInscricoesService _inscritosApp;
        private readonly IEstadosService _estadoApp;
        private readonly ICidadesService _cidadeApp;

        #endregion

        #region Construtor

        public HomeSiteApp(IUsuarioService usuario, 
                            IEventosService evento, 
                            IInscricoesService inscritos,
                            IEstadosService estado,
                            ICidadesService cidade)
        {
            _userApp = usuario;
            _eventoApp = evento;
            _inscritosApp = inscritos;
            _estadoApp = estado;
            _cidadeApp = cidade;
        }

        #endregion

        #region Interface Implementation

        public IEnumerable<Usuario> Aniversariantes()
        {
            var culture = new CultureInfo("pt-BR");
            var formataData = culture.DateTimeFormat;
            var mes = Convert.ToInt32(DateTime.Now.Month);

            var niverMes = _userApp.GetAll().Where(p => p.PerfilUsuarioId.Equals(3)
                            && p.DataNascimento.Month.Equals(mes)).ToList();
            return niverMes;
        }

        public IEnumerable<Evento> ListarBanner()
        {
            return _eventoApp.GetAll().Where(p => p.Ativo.Equals(true)).OrderByDescending(p => p.DataEvento);
        }

        public IEnumerable<Inscricoes> Participantes()
        {
            //IEnumerable<Inscricoes> inscritos = _inscritosApp.GetAll().ToList();

            //var participantes =
            //    from p in inscritos
            //    group p by p.UserId into g
            //    select new { UserId = g.Key, inscritos = g.Sum(p=>p.InscricoesId) };

            //return participantes.OrderByDescending(p=>p.inscritos);
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> ProximosEvenetos()
        {
            return _eventoApp.ProximosEventos().OrderBy(p => p.DataEvento);
        }

        public int TotalAtletas()
        {
            return _userApp.GetAll().Where(p => p.PerfilUsuarioId.Equals(3)).Count();
        }

        public int TotalInscritos()
        {
            return _inscritosApp.GetAll().Where(p => p.Status.Equals(true)).Count();
        }

        public Estado BuscaEstado(int id)
        {
            return _estadoApp.GetById(id);
        }

        public Cidade BuscaCidade(int id)
        {
            return _cidadeApp.GetById(id);
        }

        #endregion
    }
}
