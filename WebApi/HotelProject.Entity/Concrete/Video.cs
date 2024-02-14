using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Video:EntityBase,IEntity
    {
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? VideoSource { get; set; }
    }
}
