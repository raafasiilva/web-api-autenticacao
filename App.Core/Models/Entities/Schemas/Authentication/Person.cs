using App.Domain.Models.Entities.BaseEntities;

namespace App.Domain.Models.Entities.Schemas.Authentication
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
