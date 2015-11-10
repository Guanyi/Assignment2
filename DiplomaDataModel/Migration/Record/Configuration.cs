namespace DiplomaDataModel.Migration.Record
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModel.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migration\Record";
        }

        protected override void Seed(DiplomaDataModel.Models.DataContext context)
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

            context.YearTerms.AddOrUpdate(
                y => new { y.Year, y.Term },
                new YearTerm() { Year = 2015, Term = 10, IsDefault = false },
                new YearTerm() { Year = 2015, Term = 20, IsDefault = false },
                new YearTerm() { Year = 2015, Term = 30, IsDefault = false },
                new YearTerm() { Year = 2016, Term = 10, IsDefault = true }
            );
            context.SaveChanges();

            context.Options.AddOrUpdate(
                yt => yt.Title,
                new Option() { Title = "Data Communications", IsActive = true },
                new Option() { Title = "Client Server", IsActive = true },
                new Option() { Title = "Digital Processing", IsActive = true },
                new Option() { Title = "Information Systems", IsActive = true },
                new Option() { Title = "Database", IsActive = false },
                new Option() { Title = "Web & Mobile", IsActive = true },
                new Option() { Title = "Tech Pro", IsActive = false }
                );
            context.SaveChanges();
        }
    }
}
