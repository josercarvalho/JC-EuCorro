﻿using System.Web.Mvc;

namespace EuCorro.MVC.Site.Areas.Painel
{
    public class PainelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Painel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Painel_default",
                "Painel/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "EuCorro.MVC.Site.Areas.Painel.Controllers" }
            );
        }
    }
}