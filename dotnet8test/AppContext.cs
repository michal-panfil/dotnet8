
using Microsoft.EntityFrameworkCore;

namespace dotnet8test
{
    public class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;");
        }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
