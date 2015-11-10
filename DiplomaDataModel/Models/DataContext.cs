using DiplomaDataModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DiplomaDataModel;

namespace DiplomaDataModel.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }

        public DbSet<YearTerm> YearTerms { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Option> Options { get; set; }
    }
}