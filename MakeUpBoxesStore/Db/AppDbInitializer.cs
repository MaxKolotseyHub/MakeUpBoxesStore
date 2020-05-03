using MakeUpBoxesStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakeUpBoxesStore.Db
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role_admin = new IdentityRole { Name = "admin" };
            var role_user = new IdentityRole { Name = "user" };

            roleManager.Create(role_admin);
            roleManager.Create(role_user);

            var admin = new ApplicationUser
            {
                Email = "admin@gmail.com",
                UserName = "admin"
            };

            string password = "Admin1.";

            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role_admin.Name);
                userManager.AddToRole(admin.Id, role_user.Name);
            }


            var user = new ApplicationUser
            {
                Email = "user@gmail.com",
                UserName = "user"
            };

            password = "User1.";

            result = userManager.Create(user, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(user.Id, role_user.Name);
            }

            base.Seed(context);
        }
    }
}