using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class About: EntityBase, IEntity
    {
        public string? Toptitle { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomerCount { get; set; }
    }
}
