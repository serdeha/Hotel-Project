using HotelProject.Data.Abstract;

namespace HotelProject.Data.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRoomRepository Room { get; }
        IServiceRepository Service { get; }
        IStaffRepository Staff { get; }
        ISubscribeRepository Subscribe { get; }
        ITestimonialRepository Testimonial { get; }
        IAboutRepository About { get; }
        IVideoRepository Video { get; }
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
