namespace DemoApp.Backend.Models
{
    using Domain.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<ModelApp.Common.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<ModelApp.Common.Models.District> Districts { get; set; }

        public System.Data.Entity.DbSet<ModelApp.Common.Models.Region> Regions { get; set; }

        public System.Data.Entity.DbSet<ModelApp.Common.Models.Section> Sections { get; set; }

        public System.Data.Entity.DbSet<ModelApp.Common.Models.Title> Titles { get; set; }
    }
}