using HotelProject.Entity.Abstract;

namespace HotelProject.Entity.Concrete
{
    public class Subscribe : EntityBase, IEntity
    {
        public string? Email { get; set; }
    }
}