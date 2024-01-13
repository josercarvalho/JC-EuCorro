using EuCorro.Security.Context;
using EuCorro.Security.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EuCorro.MVC.Site.Startup))]
namespace EuCorro.MVC.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "eucorrocorridasslz@hotmail.com";
                user.Email = "eucorrocorridasslz@hotmail.com";
                user.Nome = "EUCORRO";
                user.PerfilUsuarioId = 1;

                string userPWD = "&Uc0rr0M@!$";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin para eucorro
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }

                // Usuário Admin padrão DEVELOP 
                var userDev = new ApplicationUser();
                userDev.UserName = "josercarvalho@gmail.com";
                userDev.Email = "josercarvalho@gmail.com";
                user.Nome = "José Ribeiro Carvalho";
                userDev.PerfilUsuarioId = 1;

                var userDevPWD = "J0t!nh@";

                chkUser = UserManager.Create(userDev, userDevPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result2 = UserManager.AddToRole(userDev.Id, "Admin");
                }
            }

            // creating Creating Operador role 
            if (!roleManager.RoleExists("Operador"))
            {
                var role = new IdentityRole();
                role.Name = "Operador";
                roleManager.Create(role);
            }

            // creating Creating Cliente role 
            if (!roleManager.RoleExists("Cliente"))
            {
                var role = new IdentityRole();
                role.Name = "Cliente";
                roleManager.Create(role);
            }
        }
    }
}
