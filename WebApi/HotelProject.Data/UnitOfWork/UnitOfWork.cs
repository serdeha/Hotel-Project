using HotelProject.Data.Abstract;
using HotelProject.Data.Concrete.EntityFramework.Contexts;
using HotelProject.Data.Concrete.EntityFramework.Repositories;

namespace HotelProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelProjectDbContext _context;
        private EfRoomRepository? _roomRepository;
        private EfServiceRepository? _serviceRepository;
        private EfStaffRepository? _staffRepository;
        private EfSubscribeRepository? _subscribeRepository;
        private EfTestimonialRepository? _testimonialRepository;
        public UnitOfWork(HotelProjectDbContext context)
        {
            _context = context;
        }
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public IRoomRepository Room => _roomRepository ??= new EfRoomRepository(_context);

        public IServiceRepository Service => _serviceRepository ??= new EfServiceRepository(_context);

        public IStaffRepository Staff => _staffRepository ??= new EfStaffRepository(_context);

        public ISubscribeRepository Subscribe => _subscribeRepository ??= new EfSubscribeRepository(_context);

        public ITestimonialRepository Testimonial => _testimonialRepository ??= new EfTestimonialRepository(_context);

        
    }
}
