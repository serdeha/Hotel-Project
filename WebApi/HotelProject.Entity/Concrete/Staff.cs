using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Staff : EntityBase, IEntity
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? StaffImage { get; set; }
        public string? FacebookLink { get; set; }
        public string? TwitterLink { get; set; }
        public string? InstagramLink { get; set; }
    }
}
