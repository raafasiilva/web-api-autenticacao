namespace App.Domain.Models.Entities.BaseEntities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            UpdateDate = null;
        }

        public EntityBase(Guid id, DateTime creationDate, DateTime? updateDate = null)
        {
            Id = id;
            CreationDate = creationDate;
            UpdateDate = updateDate;
        }

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
