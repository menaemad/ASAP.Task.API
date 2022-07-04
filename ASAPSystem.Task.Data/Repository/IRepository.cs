using ASAPSystem.Assignment.Core.Constants;
using ASAPSystem.Assignment.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASAPSystem.Assignment.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {

        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IPagedList<TEntity>> GetAllPagedAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false, bool includeDeleted = true);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int take, int skip);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int skip, int take);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, int? take, int? skip,
            Expression<Func<TEntity, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, int? skip, int? take,
            Expression<Func<TEntity, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task DeleteAsync(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);




    }
}
