using HotelProject.Business.Abstract;
using HotelProject.Data.UnitOfWork;
using HotelProject.Entity.Concrete;
using System.Linq.Expressions;

namespace HotelProject.Business.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StaffManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Staff entity)
        {
            if (entity != null)
            {
                _unitOfWork.Staff.Add(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task AddAsync(Staff entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Staff.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public void Delete(Staff entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                _unitOfWork.Staff.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task DeleteAsync(Staff entity)
        {
            if (entity != null)
            {
                entity.IsActive = false;
                entity.IsDeleted = true;
                await _unitOfWork.Staff.DeleteAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public List<Staff> GetAll(Expression<Func<Staff, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Staff.GetAll() :
                _unitOfWork.Staff.GetAll(filter);
        }

        public List<Staff> GetAllWithFilter(Expression<Func<Staff, bool>>? predicate = null, params Expression<Func<Staff, object>>[] includeProperties)
        {
            return _unitOfWork.Staff.GetAllWithFilter(predicate, includeProperties);
        }

        public async Task<List<Staff>> GetAllWithFilterAsync(Expression<Func<Staff, bool>>? predicate = null, params Expression<Func<Staff, object>>[] includeProperties)
        {
            return await _unitOfWork.Staff.GetAllWithFilterAsync(predicate, includeProperties);
        }

        public Staff? GetById(int entityId)
        {
            return _unitOfWork.Staff.GetById(x => x.Id == entityId);
        }

        public async Task<Staff?> GetByIdAsync(int entityId)
        {
            return await _unitOfWork.Staff.GetByIdAsync(x => x.Id == entityId);
        }

        public int GetCount(Expression<Func<Staff, bool>>? filter = null)
        {
            return filter == null ?
                _unitOfWork.Staff.GetCount() :
                _unitOfWork.Staff.GetCount(filter);
        }

        public async Task<int> GetCountAsync(Expression<Func<Staff, bool>>? filter = null)
        {
            return filter == null ?
                await _unitOfWork.Staff.GetCountAsync() :
                await _unitOfWork.Staff.GetCountAsync(filter);
        }

        public Staff? GetWithFilter(Expression<Func<Staff, bool>>? predicate = null, params Expression<Func<Staff, object>>[] includeProperties)
        {
            return _unitOfWork.Staff.GetWithFilter(predicate, includeProperties);
        }

        public async Task<Staff?> GetWithFilterAsync(Expression<Func<Staff, bool>>? predicate = null, params Expression<Func<Staff, object>>[] includeProperties)
        {
            return await _unitOfWork.Staff.GetWithFilterAsync(predicate, includeProperties);
        }

        public void HardDelete(Staff entity)
        {
            if (entity != null)
            {
                _unitOfWork.Staff.HardDelete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task<int> HardDeleteAsync(Staff entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Staff.HardDeleteAsync(entity);
                return await _unitOfWork.SaveChangesAsync();
            }

            return 0;
        }

        public void Update(Staff entity)
        {
            if (entity != null)
            {
                _unitOfWork.Staff.Update(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public async Task UpdateAsync(Staff entity)
        {
            if (entity != null)
            {
                await _unitOfWork.Staff.UpdateAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
