using EuCorro.App.Interface;
using EuCorro.MVC.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Controllers
{

    public class EventoController : Controller
    {
        #region Global declaration

        private readonly IEventoApp _evento;
        private readonly IHomeSiteApp _homeApp;

        #endregion Global declaration

        #region Constructor
        public EventoController(IEventoApp evento, IHomeSiteApp home)
        {
            _evento = evento;
            _homeApp = home;
        }
        #endregion

        #region Views Evento

        // GET: Evento
        public ActionResult Index()
        {
            var eventos = _evento.GetAll();
            var HomeModel = new HomeViewModel();

            ListaBannerViewModel banner; // = new ListaBannerViewModel();
            List<ListaBannerViewModel> lstBanner = new List<ListaBannerViewModel>();
            var retorno = _evento.GetAll().OrderBy(p => p.DataEvento);
            string dataAtual = DateTime.Now.ToShortDateString();
            foreach (var item in retorno)
            {
                banner = new ListaBannerViewModel();
                banner.EventoId = item.EventoId;
                banner.Banner = item.BannerEvento;
                banner.Nome = item.Nome;
                banner.Cidade = _homeApp.BuscaCidade(item.CidadeId).Nome;
                banner.Estado = _homeApp.BuscaEstado(item.EstadoId).Nome;
                banner.DataEvento = item.DataEvento;
                TimeSpan date = Convert.ToDateTime(item.DataEvento) - Convert.ToDateTime(dataAtual);
                banner.Previsao = date;
                banner.URL = item.URL;
                lstBanner.Add(banner);
            }

            HomeModel.ListaBanner = lstBanner;
            return View(HomeModel);
        }

        // GET: Evento/Details/5
        public ActionResult Details(int id)
        {
            var evento = new EventoViewModel();
            evento.Evento = _evento.GetById(id);
            evento.Dia = evento.Evento.DataEvento.Day.ToString();
            evento.Mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(evento.Evento.DataEvento.Month).ToLower();
            evento.Ano = evento.Evento.DataEvento.Year.ToString();

            var km = " km";
            var retorno = _evento.ListarModalidadeEvento(id);
            EventoViewModel.ListaModalidade lista;
            List<EventoViewModel.ListaModalidade> lstmodalidade = new List<EventoViewModel.ListaModalidade>();
            foreach (var item in retorno)
            {
                lista = new EventoViewModel.ListaModalidade();
                lista.Id = item.EventoId;
                lista.Nome = item.Modalidade.Nome;
                lista.Distancia = item.Modalidade.Distancia.ToString() + km;
                
                lista.Valor = _evento.BuscarPrecoPorModadlidade(item.ModalidadeEventoId).Valor;
                lstmodalidade.Add(lista);
            }

            evento.Modalidades = lstmodalidade;

            return View(evento);
        }

        // GET: Evento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Evento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evento/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion
    }
}
