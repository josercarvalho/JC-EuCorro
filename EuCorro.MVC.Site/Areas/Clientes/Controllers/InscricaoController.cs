using EuCorro.App.Interface;
using EuCorro.MVC.Site.Aolication.MvcExtensions;
using EuCorro.MVC.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Clientes.Controllers
{
    [ClienteAuth]
    public class InscricaoController : Controller
    {
        #region Global declaration

        private readonly IEventoApp _evento;
        private readonly IHomeSiteApp _homeApp;

        #endregion Global declaration

        #region Constructor
        public InscricaoController(IEventoApp evento, IHomeSiteApp home)
        {
            _evento = evento;
            _homeApp = home;
        }
        #endregion

        // GET: Clientes/Inscricao
        public ActionResult Index()
        {
            ViewBag.Tela = "Inscrição";
            ViewBag.Area = "ÁREA DE INSCRIÇÃO";
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

        // GET: Clientes/Inscricao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Inscricao/Create
        public ActionResult Create(int evento, int modalidade)
        {
            ViewBag.Tela = "Inscrição";
            ViewBag.Area = "ÁREA DE INSCRIÇÃO";
            return View();
        }

        // POST: Clientes/Inscricao/Create
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

        // GET: Clientes/Inscricao/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Tela = "Editar";
            ViewBag.Area = "ÁREA DE INSCRIÇÃO";
            return View();
        }

        // POST: Clientes/Inscricao/Edit/5
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

        // GET: Clientes/Inscricao/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Tela = "Exclusão";
            ViewBag.Area = "ÁREA DE INSCRIÇÃO";
            return View();
        }

        // POST: Clientes/Inscricao/Delete/5
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
    }
}
