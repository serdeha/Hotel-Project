using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubscribeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Subscribe entity)
        {
            if (entity != null)
            {
                _unitOfWork.Subscribe.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Subscribe entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Subscribe.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Subscribe entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                _unitOfWork.Subscribe.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Subscribe entity)
        {
            if (entity != null)
            {
                entity.IsDeleted = true;
                entity.IsActive = false;
                await _unitOfWork.Subscribe.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Subscribe> GetAll(Expression<Func<Subscribe, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Subscribe.GetAll() :
                _unitOfWork.Subscribe.GetAll(filter);
        }

        public List<Subscribe> GetAllWithFilter(Expression<Func<Subscribe, bool>>? predicate = null, params Expression<Func<Subscribe, object>>[] includeProperties)
        {
            return _unitOfWork.Subscribe.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Subscribe>> GetAllWithFilterAsync(Expression<Func<Subscribe, bool>>? predicate = null, params Expression<Func<Subscribe, object>>[] includeProperties)
        {
            return await _unitOfWork.Subscribe.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Subscribe? GetById(int entityId)
        {
            return _unitOfWork.Subscribe.GetById(x=>x.Id == entityId);
        }

        public async Task<Subscribe?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Subscribe.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Subscribe, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Subscribe.GetCount() :
                _unitOfWork.Subscribe.GetCount(filter);
        }

        public Task<int> GetCountAsync(Expression<Func<Subscribe, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Subscribe.GetCountAsync() :
                _unitOfWork.Subscribe.GetCountAsync(filter);
        }

        public Subscribe? GetWithFilter(Expression<Func<Subscribe, bool>>? predicate = null, params Expression<Func<Subscribe, object>>[] includeProperties)
        {
            return _unitOfWork.Subscribe.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Subscribe?> GetWithFilterAsync(Expression<Func<Subscribe, bool>>? predicate = null, params Expression<Func<Subscribe, object>>[] includeProperties)
        {
            return await _unitOfWork.Subscribe.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Subscribe entity)
        {
            if(entity != null)
            {
                _unitOfWork.Subscribe.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Subscribe entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Subscribe.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Subscribe entity)
        {
            if(entity != null)
            {
                _unitOfWork.Subscribe.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Subscribe entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Subscribe.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
