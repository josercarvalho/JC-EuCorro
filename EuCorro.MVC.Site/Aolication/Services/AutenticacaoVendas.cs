namespace EuCorro.MVC.Site.Aolication.Services
{
    public class AutenticacaoVendas : Autenticacao
    {
        protected override string NomeCookie
        {
            get { return "SITE.VENDAS.AUTH"; }
        }
    }
}