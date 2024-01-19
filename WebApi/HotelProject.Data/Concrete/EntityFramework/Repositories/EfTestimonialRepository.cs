using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Entity.Concrete;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class EfTestimonialRepository : BaseRepository<Testimonial>, ITestimonialRepository
    {
        public EfTestimonialRepository(HotelProjectDbContext context) : base(context)
        {
        }
    }
}
