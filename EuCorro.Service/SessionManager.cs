using EuCorro.Domain.Models;
using System.Web;

namespace EuCorro.Service
{
    public class SessionManager
    {
        public static Usuario UsuarioLogado
        {
            set
            {

                HttpContext.Current.Session.Add("UsuarioLogado", value);
            }
            get
            {
                return (Usuario)HttpContext.Current.Session["UsuarioLogado"];
            }

        }

        public static Inscricoes Inscritos
        {
            set
            {

                HttpContext.Current.Session.Add("Inscritos", value);
            }
            get
            {
                return (Inscricoes)HttpContext.Current.Session["Inscritos"];
            }
        }

        public static Evento EventoModalidade
        {
            set
            {

                HttpContext.Current.Session.Add("EventoModalidade", value);
            }
            get
            {
                return (Evento)HttpContext.Current.Session["EventoModalidade"];
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                return ((Usuario)HttpContext.Current.Session["UsuarioLogado"]) != null;
            }
        }
    }
}
