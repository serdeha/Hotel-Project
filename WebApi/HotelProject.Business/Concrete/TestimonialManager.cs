using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestimonialManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Testimonial entity)
        {
            if(entity != null)
            {
                _unitOfWork.Testimonial.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Testimonial entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Testimonial.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Testimonial entity)
        {
            if(entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Testimonial.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Testimonial entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Testimonial.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Testimonial> GetAll(Expression<Func<Testimonial, bool>>? filter = null)
        {
            return filter == null ? 
                _unitOfWork.Testimonial.GetAll() :
                _unitOfWork.Testimonial.GetAll(filter);
        }

        public List<Testimonial> GetAllWithFilter(Expression<Func<Testimonial, bool>>? predicate = null, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return _unitOfWork.Testimonial.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Testimonial>> GetAllWithFilterAsync(Expression<Func<Testimonial, bool>>? predicate = null, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return await _unitOfWork.Testimonial.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Testimonial? GetById(int entityId)
        {
            return _unitOfWork.Testimonial.GetById(x=>x.Id == entityId);
        }

        public async Task<Testimonial?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Testimonial.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Testimonial, bool>>? filter = null)
        {
            return filter == null ? 
                _unitOfWork.Testimonial.GetCount() :
                _unitOfWork.Testimonial.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Testimonial, bool>>? filter = null)
        {
            return filter == null ?
                await _unitOfWork.Testimonial.GetCountAsync() :
                await _unitOfWork.Testimonial.GetCountAsync(filter);
        }

        public Testimonial? GetWithFilter(Expression<Func<Testimonial, bool>>? predicate = null, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return _unitOfWork.Testimonial.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Testimonial?> GetWithFilterAsync(Expression<Func<Testimonial, bool>>? predicate = null, params Expression<Func<Testimonial, object>>[] includeProperties)
        {
            return await _unitOfWork.Testimonial.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Testimonial entity)
        {
            if(entity != null)
            {
                _unitOfWork.Testimonial.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Testimonial entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Testimonial.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Testimonial entity)
        {
            if(entity != null)
            {
                _unitOfWork.Testimonial.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Testimonial entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Testimonial.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
