using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public EfServiceRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
