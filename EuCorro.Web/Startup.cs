using EuCorro.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]    
namespace EuCorro.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}