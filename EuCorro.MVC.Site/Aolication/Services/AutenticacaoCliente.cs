namespace EuCorro.MVC.Site.Aolication.Services
{
    public class AutenticacaoCliente : Autenticacao
    {
        protected override string NomeCookie
        {
            get { return "SITE.CLIENTE.AUTH"; }
        }
    }
}