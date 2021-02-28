﻿using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Web.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
 
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
 
            roleManager.Create(role1);
            roleManager.Create(role2);
 
            var admin = new ApplicationUser { Email = "admin@mail.ru", UserName = "admin@mail.ru" };
            var password = "ad46D_ewr3";
            var result = userManager.Create(admin, password);
 
            if(result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
 
            base.Seed(context);
        }
    }
}