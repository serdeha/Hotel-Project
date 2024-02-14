using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Data.Concrete.EntityFramework.Contexts
{
    public class HotelProjectDbContext : IdentityDbContext<AppUser, AppRole, int>
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
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Video>? Videos { get; set; }
    }
}
