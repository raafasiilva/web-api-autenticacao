using App.Domain.Models.Entities.BaseEntities;
using App.Domain.Models.FilterParams.BaseFilters;

namespace App.Domain.Interfaces.Repositories
{
    public interface ITEntityRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        IEnumerable<TEntity> GetAll();
        EntityCollectionBase<TEntity> GetAll(FilterParamBase filterParam);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<EntityCollectionBase<TEntity>> GetAllAsync(FilterParamBase filterParam, CancellationToken cancellationToken);
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    }
}
