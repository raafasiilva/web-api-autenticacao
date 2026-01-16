using App.Domain.Interfaces.Repositories;
using App.Domain.Models.Entities.BaseEntities;
using App.Domain.Models.FilterParams.BaseFilters;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace App.Infraestructure.Repositories
{
    public class TEntityRepository<TEntity, TDbContext>(DbContextOptions<TDbContext> dbContextOptions) 
        : ITEntityRepository<TEntity> where TEntity : EntityBase where TDbContext : DbContext
    {
        protected DbContextOptions<TDbContext> DbContextOptions { get; private set; } = dbContextOptions;

        public virtual void Add(TEntity entity)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().AddRange(entities);
            context.SaveChanges();
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            await context.Set<TEntity>().AddRangeAsync(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            return context.Set<TEntity>().AsNoTracking().ToList();
        }

        public virtual EntityCollectionBase<TEntity> GetAll(FilterParamBase filterParam)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            int totalItens = context.Set<TEntity>().AsNoTracking().Count();

            IEnumerable<TEntity> entities = context.Set<TEntity>().AsNoTracking()
                .Skip((filterParam.Page - 1) * filterParam.PageSize).Take(filterParam.PageSize).ToList();

            return new EntityCollectionBase<TEntity>(totalItens, filterParam.Page, filterParam.PageSize, entities);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            return await context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
        }

        public virtual async Task<EntityCollectionBase<TEntity>> GetAllAsync(FilterParamBase filterParam, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            int totalItens = await context.Set<TEntity>().AsNoTracking().CountAsync();

            IEnumerable<TEntity> entities = await context.Set<TEntity>().AsNoTracking()
                .Skip((filterParam.Page - 1) * filterParam.PageSize).Take(filterParam.PageSize).ToListAsync();

            return new EntityCollectionBase<TEntity>(totalItens, filterParam.Page, filterParam.PageSize, entities);
        }

        public virtual TEntity GetById(Guid id)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            return context.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            return await context.FindAsync<TEntity>(id, cancellationToken);
        }

        public virtual void Remove(TEntity entity)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }

        public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().RemoveRange(entities);
            context.SaveChanges();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().RemoveRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().UpdateRange(entities);
            context.SaveChanges();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            using TDbContext context = (TDbContext)Activator
                .CreateInstance(typeof(TDbContext), DbContextOptions);

            context.Set<TEntity>().UpdateRange(entities);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
