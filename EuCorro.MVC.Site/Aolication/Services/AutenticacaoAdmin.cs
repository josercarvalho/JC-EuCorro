namespace EuCorro.MVC.Site.Aolication.Services
{
    public class AutenticacaoAdmin : Autenticacao
    {
        protected override string NomeCookie
        {
            get { return "SITE.ADMIN.AUTH"; }
        }
    }
}