using feedback4eTask.Core.Entities;
using System.Linq.Expressions;

namespace feedback4eTask.Core.DataAccess
{
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        T Add(T entity);
        Task<IEnumerable<T>> AddIEnumerable(IEnumerable<T> entities);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
        T Get(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
