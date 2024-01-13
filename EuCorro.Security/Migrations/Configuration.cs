namespace EuCorro.Security.Migrations
{
    using Context;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //ApplicationDbContext context = new ApplicationDbContext();
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
                user.UserName = "EuCorro Admin";
                user.Email = "eucorrocorridasslz@hotmail.com";

                string userPWD = "&Uc0rr0M@!$";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin para eucorro
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");    
                }

                // Usuário Admin padrão DEVELOP 
                var userDev = new ApplicationUser();
                userDev.UserName = "José Carvalho";
                userDev.Email = "josercarvalho@gmail.com";

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
