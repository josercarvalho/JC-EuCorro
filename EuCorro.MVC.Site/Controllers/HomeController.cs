using EuCorro.App.Interface;
using EuCorro.MVC.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Controllers
{
    public class HomeController : Controller
    {
        #region Global declaration

        private readonly IHomeSiteApp _homeApp;

        #endregion Global declaration

        #region Constructor

        public HomeController(IHomeSiteApp home)
        {
            _homeApp = home;
        }

        #endregion Constructor

        #region Views Evento

        public ActionResult Index()
        {
            var niverMes = _homeApp.Aniversariantes();
            var HomeModel = new HomeViewModel()
            {
                Aniversariantes = _homeApp.Aniversariantes(),
                ProximosEventos = _homeApp.ProximosEvenetos(),
                Cadastrados = _homeApp.TotalAtletas(),
                Inscritos = _homeApp.TotalInscritos()
            };

            ListaBannerViewModel banner; // = new ListaBannerViewModel();
            List<ListaBannerViewModel> lstBanner = new List<ListaBannerViewModel>();
            var retorno = _homeApp.ListarBanner();
            string dataAtual = DateTime.Now.ToShortDateString();
            foreach (var item in retorno)
            {
                banner = new ListaBannerViewModel();
                banner.EventoId = item.EventoId;
                banner.Banner = item.BannerEvento;
                banner.Nome = item.Nome;
                banner.Descricao = item.DescricaoEvento;
                banner.Local = item.Endereco;
                banner.Cidade = _homeApp.BuscaCidade(item.CidadeId).Nome;
                banner.Estado = _homeApp.BuscaEstado(item.EstadoId).Nome;
                banner.DataEvento = item.DataEvento;
                banner.HoraEvento = item.HoraEvento;
                TimeSpan date = Convert.ToDateTime(item.DataEvento) -Convert.ToDateTime(dataAtual);
                banner.Previsao = date;
                banner.URL = item.URL;
                lstBanner.Add(banner);
            }

            HomeModel.ListaBanner = lstBanner;

            //var imagesModel = new ImageGallery();
            //var imageFiles = Directory.GetFiles(Server.MapPath("~/Uploads/Parceiros"));
            //foreach (var item in imageFiles)
            //{
            //    imagesModel.ImageList.Add(Path.GetFileName(item));
            //}

            var i = 0;
            var imagesModel = new List<imgParceirosViewModel>();
            imgParceirosViewModel imagem;

            var imageFiles = Directory.GetFiles(Server.MapPath("~/Uploads/Parceiros"));
            foreach (var item in imageFiles)
            {
                imagem = new imgParceirosViewModel();
                imagem.Id = i++;
                imagem.ImagePath = Path.GetFileName(item);
                imagesModel.Add(imagem);
            }

            ViewBag.Parceiros = imagesModel;

            return View(HomeModel);
        }

        public ActionResult Resultados()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos - RESULTADOS.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos - A EMPRESA.";

            return View();
        }

        public ActionResult Portifolio()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos - PROTIFOLIO.";

            return View();
        }

        public ActionResult Alugueis()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos.";

            return View();
        }

        public ActionResult Servicos()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos.";

            return View();
        }

        public ActionResult Eventos()
        {
            ViewBag.Message = "EUCORRO Acessoria Esportiva e Eventos Esportivos.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Entre em contato conosco.";

            return View();
        }

        #endregion Views Evento
    }
}