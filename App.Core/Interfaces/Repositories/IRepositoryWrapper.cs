using App.Domain.Interfaces.Repositories.V1;

namespace App.Domain.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IAddressRepository Address { get; }
    }
}
