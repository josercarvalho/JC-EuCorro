using System.Web.Mvc;
using System.Web.Routing;

namespace EuCorro.MVC.Site
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string[] namespaces = new string[] {
                "EuCorro.MVC.Site.Controllers"
            };

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: namespaces
                //namespaces: new[] { "EuCorro.MVC.Site.Controllers" }
            );
        }
    }
}
