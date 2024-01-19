using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfRoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public EfRoomRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
