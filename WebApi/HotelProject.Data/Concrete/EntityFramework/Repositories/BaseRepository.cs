using HotelProject.Data.Abstract;
using HotelProject.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelProject.Data.Concrete.EntityFramework.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Update(entity);   
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Update(entity);
            });            
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(filter).ToList();
        }

        public List<T> GetAllWithFilter(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.ToList();
        }

        public async Task<List<T>> GetAllWithFilterAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public T? GetById(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ?
                _context.Set<T>().SingleOrDefault() :
                _context.Set<T>().Where(filter).SingleOrDefault();

        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ?
                await _context.Set<T>().SingleOrDefaultAsync() :
                await _context.Set<T>().Where(filter).SingleOrDefaultAsync();
        }

        public int GetCount(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ? 
                _context.Set<T>().Count() :
                _context.Set<T>().Where(filter).Count();
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null)
        {
            return filter == null ?
                await _context.Set<T>().CountAsync() :
                await _context.Set<T>().Where(filter).CountAsync();
        }

        public T? GetWithFilter(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.SingleOrDefault();
        }

        public async Task<T?> GetWithFilterAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            if(predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties.Any())
            {
                foreach(var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.SingleOrDefaultAsync();
        }

        public void HardDelete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
            });
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Update(entity);
            });
        }
    }
}
