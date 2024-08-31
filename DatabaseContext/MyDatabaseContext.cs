using Demoapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Demoapp.DatabaseContext
{
    public class MyDatabaseContext : DbContext
    {
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BuildingDb");
        }
        public DbSet<Building> Buildings { get; set; }
    }
}
