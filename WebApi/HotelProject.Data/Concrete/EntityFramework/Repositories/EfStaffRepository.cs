using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfStaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public EfStaffRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
