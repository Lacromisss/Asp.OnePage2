using HeyatdanBezmek.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyatdanBezmek.Dal
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {

        }
       public DbSet<Slider> sliders { get; set; }
    }
}
