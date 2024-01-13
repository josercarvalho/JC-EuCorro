using EuCorro.MVC.Site.Aolication.Services;
using System;
using System.Web;
using System.Web.Mvc;

namespace EuCorro.MVC.Site.Aolication.MvcExtensions
{
    public class VendasAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var usuario = new AutenticacaoVendas().ObterAutenticado();
            return (usuario != null);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string loginUrl = "~/vendas/login";
            string url = filterContext.HttpContext.Request.Url.PathAndQuery;
            string redirect = String.Format("{0}?returnUrl={1}", loginUrl, url);
            filterContext.Result = new RedirectResult(redirect);
        }
    }
}