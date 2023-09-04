using Microsoft.AspNetCore.Identity;

namespace App.Domain.Models.Entities.Schemas.Authentication
{
    public class User : IdentityUser
    {
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}
