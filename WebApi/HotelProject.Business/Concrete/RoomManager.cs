using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Room entity)
        {
            if(entity != null)
            {
                _unitOfWork.Room.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Room entity)
        {
            if(entity != null )
            {
                await _unitOfWork.Room.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Room entity)
        {
            if(entity != null )
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Room.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Room entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Room.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Room> GetAll(Expression<Func<Room, bool>>? filter = null)
        {
            return _unitOfWork.Room.GetAll(filter);
        }

        public List<Room> GetAllWithFilter(Expression<Func<Room, bool>>? predicate = null, params Expression<Func<Room, object>>[] includeProperties)
        {
            return _unitOfWork.Room.GetAllWithFilter(predicate,includeProperties);
        }

        public async Task<List<Room>> GetAllWithFilterAsync(Expression<Func<Room, bool>>? predicate = null, params Expression<Func<Room, object>>[] includeProperties)
        {
            return await _unitOfWork.Room.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Room? GetById(int entityId)
        {
            return _unitOfWork.Room.GetById(x => x.Id == entityId);
        }

        public async Task<Room?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Room.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Room, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Room.GetCount() :
                _unitOfWork.Room.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Room, bool>>? filter = null)
        {
            return filter == null ?
                await _unitOfWork.Room.GetCountAsync() :
                await _unitOfWork.Room.GetCountAsync(filter);
        }

        public Room? GetWithFilter(Expression<Func<Room, bool>>? predicate = null, params Expression<Func<Room, object>>[] includeProperties)
        {
            return _unitOfWork.Room.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Room?> GetWithFilterAsync(Expression<Func<Room, bool>>? predicate = null, params Expression<Func<Room, object>>[] includeProperties)
        {
            return await _unitOfWork.Room.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Room entity)
        {
            if(entity != null)
            {
                _unitOfWork.Room.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Room entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Room.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Room entity)
        {
            if(entity != null)
            {
                _unitOfWork.Room.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Room entity)
        {
            if(entity != null)
            {
                await _unitOfWork.Room.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
