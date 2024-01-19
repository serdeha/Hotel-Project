using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfSubscribeRepository : BaseRepository<Subscribe>, ISubscribeRepository
    {
        public EfSubscribeRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
