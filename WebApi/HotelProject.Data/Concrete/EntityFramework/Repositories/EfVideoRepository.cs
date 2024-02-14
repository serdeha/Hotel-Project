using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfVideoRepository : BaseRepository<Video>, IVideoRepository
    {
        public EfVideoRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
