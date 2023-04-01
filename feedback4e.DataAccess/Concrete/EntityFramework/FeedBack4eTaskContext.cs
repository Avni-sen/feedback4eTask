using feedback4eTask.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace feedback4eTask.DataAccess.Concrete.EntityFramework
{
    public class FeedBack4eTaskContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ENCGM43;Database=FeedBack4eTask;Trusted_Connection=True;TrustServerCertificate=True;");

        }
        public DbSet<Airport> Airports { get; set; }
    }
}
