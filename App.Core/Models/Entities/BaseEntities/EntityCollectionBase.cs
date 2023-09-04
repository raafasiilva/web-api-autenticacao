namespace App.Domain.Models.Entities.BaseEntities
{
    public class EntityCollectionBase<TEntity> where TEntity : class
    {
        public EntityCollectionBase(int page, int pageSize, int totalItens, IEnumerable<TEntity> data)
        {
            Page = page;
            PageSize = pageSize;
            TotalItens = totalItens;
            Data = data;
        }

        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItens { get; private set; }

        public IEnumerable<TEntity> Data { get; private set; }
    }
}
