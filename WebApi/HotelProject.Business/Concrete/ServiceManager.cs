using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Service entity)
        {
            if (entity != null)
            {
                _unitOfWork.Service.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Service entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Service.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Service entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Service.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Service entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Service.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Service> GetAll(Expression<Func<Service, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Service.GetAll() :
                _unitOfWork.Service.GetAll(filter);
        }

        public List<Service> GetAllWithFilter(Expression<Func<Service, bool>>? predicate = null, params Expression<Func<Service, object>>[] includeProperties)
        {
            return _unitOfWork.Service.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Service>> GetAllWithFilterAsync(Expression<Func<Service, bool>>? predicate = null, params Expression<Func<Service, object>>[] includeProperties)
        {
            return await _unitOfWork.Service.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Service? GetById(int entityId)
        {
            return _unitOfWork.Service.GetById(x => x.Id == entityId);
        }

        public async Task<Service?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Service.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Service, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Service.GetCount() :
                _unitOfWork.Service.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Service, bool>>? filter = null)
        {
            return filter == null ? 
                await _unitOfWork.Service.GetCountAsync() : 
                await _unitOfWork.Service.GetCountAsync(filter);
        }

        public Service? GetWithFilter(Expression<Func<Service, bool>>? predicate = null, params Expression<Func<Service, object>>[] includeProperties)
        {
            return _unitOfWork.Service.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Service?> GetWithFilterAsync(Expression<Func<Service, bool>>? predicate = null, params Expression<Func<Service, object>>[] includeProperties)
        {
            return await _unitOfWork.Service.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Service entity)
        {
            if(entity != null)
            {
                _unitOfWork.Service.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Service entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Service.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Service entity)
        {
            if(entity != null)
            {
                _unitOfWork.Service.Update(entity); 
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Service entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Service.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
