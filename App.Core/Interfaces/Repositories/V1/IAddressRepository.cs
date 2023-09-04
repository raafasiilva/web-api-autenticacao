using App.Domain.Models.Entities.Schemas.Authentication;

namespace App.Domain.Interfaces.Repositories.V1
{
    public interface IAddressRepository : ITEntityRepository<Address>
    {
        Task<bool> HasByIdAsync(Guid id);
    }
}
