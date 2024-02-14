using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class VideoManager : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VideoManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Video entity)
        {
            if (entity != null)
            {
                _unitOfWork.Video.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Video entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Video.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Video entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Video.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Video entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Video.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Video> GetAll(Expression<Func<Video, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Video.GetAll() : _unitOfWork.Video.GetAll(filter);
        }

        public List<Video> GetAllWithFilter(Expression<Func<Video, bool>>? predicate = null, params Expression<Func<Video, object>>[] includeProperties)
        {
            return _unitOfWork.Video.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Video>> GetAllWithFilterAsync(Expression<Func<Video, bool>>? predicate = null, params Expression<Func<Video, object>>[] includeProperties)
        {
            return await _unitOfWork.Video.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Video? GetById(int entityId)
        {
            return _unitOfWork.Video.GetById(x => x.Id == entityId);
        }

        public async Task<Video?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Video.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Video, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Video.GetCount() : _unitOfWork.Video.GetCount(filter);
        }

        public Task<int> GetCountAsync(Expression<Func<Video, bool>>? filter = null)
        {
            return filter == null ? _unitOfWork.Video.GetCountAsync() : _unitOfWork.Video.GetCountAsync(filter);
        }

        public Video? GetWithFilter(Expression<Func<Video, bool>>? predicate = null, params Expression<Func<Video, object>>[] includeProperties)
        {
            return _unitOfWork.Video.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Video?> GetWithFilterAsync(Expression<Func<Video, bool>>? predicate = null, params Expression<Func<Video, object>>[] includeProperties)
        {
            return await _unitOfWork.Video.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Video entity)
        {
            if (entity != null)
            {
                _unitOfWork.Video.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Video entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Video.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Video entity)
        {
            if(entity != null)
            {
                _unitOfWork.Video.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Video entity)
        {
            if( entity != null)
            {
                await _unitOfWork.Video.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
