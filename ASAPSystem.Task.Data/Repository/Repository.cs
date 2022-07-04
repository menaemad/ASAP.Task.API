using ASAPSystem.Assignment.Core.Constants;
using ASAPSystem.Assignment.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

        }
        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public void DeleteRange(IEnumerable<TEntity> entities)
        {

            _context.Set<TEntity>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
                _context.Set<TEntity>().RemoveRange(entities);
                await _context.SaveChangesAsync();
        }


        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().FirstOrDefault(predicate);
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);


        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate).ToList();
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
            => await _context.Set<TEntity>().Where(predicate).ToListAsync();


        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int take, int skip)
            => _context.Set<TEntity>().Where(predicate).Skip(skip).Take(take).ToList();
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take)
                => await _context.Set<TEntity>().Where(predicate).Skip(skip).Take(take).ToListAsync();



        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int? take, int? skip, Expression<Func<TEntity, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            var query = _context.Set<TEntity>().Where(predicate);

            if (skip.HasValue && skip.Value > 0)
                query = query.Skip(skip.Value);

            if (take.HasValue && take.Value > 0)
                query = query.Take(take.Value);
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int? skip, int? take, Expression<Func<TEntity, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            var query = _context.Set<TEntity>().Where(predicate);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }


        public IEnumerable<TEntity> GetAll()
            => _context.Set<TEntity>().ToList();
        public async Task<IEnumerable<TEntity>> GetAllAsync()
                 => await _context.Set<TEntity>().ToListAsync();


        public TEntity GetById(int id)
            => _context.Set<TEntity>().Find(id);

        public async Task<TEntity> GetByIdAsync(int id)
         => await _context.Set<TEntity>().FindAsync(id);


        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false, bool includeDeleted = true)
        {

            var query = _context.Set<TEntity>().AsQueryable();
            query = func != null ? func(query) : query;
            return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
        }

    }
}
