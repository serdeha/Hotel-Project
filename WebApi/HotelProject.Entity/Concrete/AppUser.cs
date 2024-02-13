using Microsoft.AspNetCore.Identity;


namespace HotelProject.Entity.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? City { get; set; }
    }
}
