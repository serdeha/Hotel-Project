using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Room:EntityBase,IEntity
    {        
        public string? RoomNumber { get; set; }
        public string? RoomCoverImage { get; set; }
        public decimal? Price { get; set; }
        public string? Title { get; set; }
        public string? BedCount { get; set; }
        public string? BathCount { get; set; }
        public string? Wifi { get; set; }
        public string? Description { get; set; }
    }
}
