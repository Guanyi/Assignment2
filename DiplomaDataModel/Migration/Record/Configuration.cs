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

            context.Choices.AddOrUpdate(
                c => new { c.StudentId, c.YearTermId },
                new Choice()
                {
                    StudentId = "A00987650",
                    StudentFirstName = "Peter",
                    StudentLastName = "White",
                    FirstChoiceOptionId = 1,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987651",
                    StudentFirstName = "John",
                    StudentLastName = "Doe",
                    FirstChoiceOptionId = 1,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987652",
                    StudentFirstName = "Alice",
                    StudentLastName = "Green",
                    FirstChoiceOptionId = 1,
                    SecondChoiceOptionId = 6,
                    ThirdChoiceOptionId = 2,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987653",
                    StudentFirstName = "Mary",
                    StudentLastName = "Liu",
                    FirstChoiceOptionId = 6,
                    SecondChoiceOptionId = 1,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987654",
                    StudentFirstName = "William",
                    StudentLastName = "Hanes",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987655",
                    StudentFirstName = "Katie",
                    StudentLastName = "Kopp",
                    FirstChoiceOptionId = 3,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 4,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987656",
                    StudentFirstName = "Clifford",
                    StudentLastName = "Davis",
                    FirstChoiceOptionId = 6,
                    SecondChoiceOptionId = 4,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987657",
                    StudentFirstName = "George",
                    StudentLastName = "Flowers",
                    FirstChoiceOptionId = 1,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 4,
                    FourthChoiceOptionId = 3,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987658",
                    StudentFirstName = "Dale",
                    StudentLastName = "Ross",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 3,
                    ThirdChoiceOptionId = 2,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987659",
                    StudentFirstName = "Walter",
                    StudentLastName = "Houghton",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 3
                },

                new Choice()
                {
                    StudentId = "A00987660",
                    StudentFirstName = "Dennis",
                    StudentLastName = "Sullins",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987661",
                    StudentFirstName = "Dolores",
                    StudentLastName = "Sandifer",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 3,
                    ThirdChoiceOptionId = 2,
                    FourthChoiceOptionId = 6,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987662",
                    StudentFirstName = "Willie",
                    StudentLastName = "Parker",
                    FirstChoiceOptionId = 1,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987663",
                    StudentFirstName = "Tiffany",
                    StudentLastName = "McShane",
                    FirstChoiceOptionId = 6,
                    SecondChoiceOptionId = 3,
                    ThirdChoiceOptionId = 2,
                    FourthChoiceOptionId = 4,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987664",
                    StudentFirstName = "Ronnie",
                    StudentLastName = "Rivera",
                    FirstChoiceOptionId = 6,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987665",
                    StudentFirstName = "Luis",
                    StudentLastName = "Carrillo",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 6,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987666",
                    StudentFirstName = "Donna",
                    StudentLastName = "Copeland",
                    FirstChoiceOptionId = 2,
                    SecondChoiceOptionId = 4,
                    ThirdChoiceOptionId = 6,
                    FourthChoiceOptionId = 3,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987667",
                    StudentFirstName = "Micky",
                    StudentLastName = "Johnson",
                    FirstChoiceOptionId = 3,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 6,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987668",
                    StudentFirstName = "Michael",
                    StudentLastName = "Kime",
                    FirstChoiceOptionId = 6,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 3,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                },

                new Choice()
                {
                    StudentId = "A00987669",
                    StudentFirstName = "Olivia",
                    StudentLastName = "Ball",
                    FirstChoiceOptionId = 4,
                    SecondChoiceOptionId = 2,
                    ThirdChoiceOptionId = 6,
                    FourthChoiceOptionId = 1,
                    SelectionDate = DateTime.Now,
                    YearTermId = 4
                }

                );
            context.SaveChanges();
        }
    }
}
