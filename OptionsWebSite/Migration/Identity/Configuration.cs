namespace OptionsWebSite.Migration.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionsWebSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration\Identity";
        }

        protected override void Seed(OptionsWebSite.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.ApplicationRole.AddOrUpdate(
              r => r.Name,
              new ApplicationRole { Name = "Admin" },
              new ApplicationRole { Name = "Student" },
              new ApplicationRole { Name = "Suspend" }
            );

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            string[] emails = { "a@a.a", "s@s.s", "@p.p", "q@q.q" };
            string[] usernames = { "A00111111", "A00222222", "A00888888", "A00777777" };

            if (userManager.FindByName(usernames[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = usernames[0],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Admin");
            }
            if (userManager.FindByName(usernames[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = usernames[1],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Student");
            }

            if (userManager.FindByName(usernames[2]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[2],
                    UserName = usernames[2],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Admin");
            }

            if (userManager.FindByName(usernames[3]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[3],
                    UserName = usernames[3],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByName(user.UserName).Id, "Student");
            }
        }
    }
}
