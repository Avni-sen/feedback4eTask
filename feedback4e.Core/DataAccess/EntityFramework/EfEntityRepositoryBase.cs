using feedback4eTask.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace feedback4eTask.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
    {


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<TEntity>> AddIEnumerableAsync(IEnumerable<TEntity> entities)
        {
            using (TContext context = new())
            {
                await context.Set<TEntity>().AddRangeAsync(entities);
                await context.SaveChangesAsync();
                return entities;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext context = new())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext context = new())
            {
                if (expression == null)
                {
                    return context.Set<TEntity>().ToList();
                }
                else
                {
                    return context.Set<TEntity>().Where(expression).ToList();
                }
            }
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext context = new())
            {
                if (expression == null)
                {
                    return await context.Set<TEntity>().ToListAsync();
                }
                else
                {
                    return await context.Set<TEntity>().Where(expression).ToListAsync();
                }
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new())
            {
                return context.Set<TEntity>().FirstOrDefault(expression);
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            using (TContext context = new())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(expression);
            }
        }

        public int SaveChanges()
        {
            using (TContext context = new())
            {
                return context.SaveChanges();
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            using (TContext context = new())
            {
                return await context.SaveChangesAsync();
            }
        }

        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
