using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Service : EntityBase, IEntity
    {
        public string? ServiceIcon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
