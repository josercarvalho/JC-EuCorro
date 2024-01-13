using EuCorro.MVC.Site.Aolication.MvcExtensions;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Vendas.Controllers
{
    [VendasAuth]
    public class HomeController : Controller
    {
        // GET: Vendas/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}