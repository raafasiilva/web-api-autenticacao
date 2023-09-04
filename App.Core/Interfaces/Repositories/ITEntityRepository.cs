using App.Domain.Models.Entities.BaseEntities;
using App.Domain.Models.FilterParams.BaseFilters;

namespace App.Domain.Interfaces.Repositories
{
    public interface ITEntityRepository<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> GetAll();
        EntityCollectionBase<TEntity> GetAll(FilterParamBase filterParam);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<EntityCollectionBase<TEntity>> GetAllAsync(FilterParamBase filterParam);
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        void Remove(TEntity entity);
        Task RemoveAsync(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
    }
}
