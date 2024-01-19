using HotelProject.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data.Concrete.EntityFramework.Contexts
{
    public class HotelProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=HotelProjectApiDb;integrated security=true");
        }

        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Service>? Services { get; set; }
        public DbSet<Staff>? Staff { get; set; }
        public DbSet<Subscribe>? Subscribes { get; set; }
        public DbSet<Testimonial>? Testimonials { get; set; }
    }
}
