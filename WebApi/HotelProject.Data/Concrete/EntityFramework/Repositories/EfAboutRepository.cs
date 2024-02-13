using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;


namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfAboutRepository : BaseRepository<About>, IAboutRepository
    {
        public EfAboutRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
