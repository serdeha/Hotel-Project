using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Staff : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? SocialMedia1 { get; set; }
        public string? SocialMedia2 { get; set; }
        public string? SocialMedia3 { get; set; }
    }
}
