using Microsoft.EntityFrameworkCore;
using PurpleTask.Models;

namespace PurpleTask.DAL.Context
{
    public class PurpleDbContext:DbContext
    {

        public PurpleDbContext(DbContextOptions<PurpleDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
       public DbSet<Slider> Sliders { get; set; }
        public DbSet<Card>Card { get; set; }

    }
}
