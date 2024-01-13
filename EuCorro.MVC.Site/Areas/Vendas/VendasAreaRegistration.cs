using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Vendas
{
    public class VendasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Vendas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            string[] namespaces = new string[] {
                "EuCorro.MVC.Site.Areas.Vendas.Controllers"
            };

            context.MapRoute(
                name: "Vendas.Home.Index",
                url: "vendas",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: namespaces
            );              
            context.MapRoute(
                name: "Vendas.Account.Login",
                url: "vendas/login",
                defaults: new { controller = "Account", action = "Login" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Vendas.Account.LogOff",
                url: "vendas/logoff",
                defaults: new { controller = "Account", action = "LogOff" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Vendas.Atleta.Edit",
                url: "vendas/meusdados",
                defaults: new { controller = "Atleta", action = "Edit" },
                namespaces: namespaces
            );
            context.MapRoute(
                name: "Vendas.Account.ForgotPassword",
                url: "vendas/esquecisenha",
                defaults: new { controller = "Account", action = "ForgotPassword" },
                namespaces: namespaces
            );
        }
    }
}