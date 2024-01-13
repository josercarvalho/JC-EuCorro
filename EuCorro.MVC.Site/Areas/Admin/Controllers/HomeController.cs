using System.Web.Mvc;
using EuCorro.App.Interface;
using EuCorro.MVC.Site.ViewModels;

namespace EuCorro.MVC.Site.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeIndexApp _homeApp;

        public HomeController(IHomeIndexApp home)
        {
            _homeApp = home;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var retorno = new IndexHomeViewModel
            {
                InscricoesAbertas = _homeApp.InscricoesAbertas(),
                EventosRealizados = _homeApp.EventosRealizados(),
                TotalDeAtletas = _homeApp.TotalAtletas(),
                InscricoesRealizadas = _homeApp.TotalInscritos()
            };

            return View(retorno);
        }

        public ActionResult Blank()
        {
            return View();
        }
    }
}