using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;

namespace API.Interfaces.Services.V1
{
    public interface IAddressService : IBaseService
    {
        Task AddAddressAsync(AddressCreationModel creationModel, CancellationToken cancellationToken);
        Task<AddressViewModel> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<ModelCollectionBaseViewModel<AddressViewModel>> GetAllAdressesAsync(FilterParamBaseQueryModel queryModel, CancellationToken cancellationToken);
        Task<AddressViewModel> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken);
        Task RemoveAddressByIdAsync(Guid id, CancellationToken cancellationToken);
        Task UpdateAddressAsync(AddressUpdateModel updateModel, CancellationToken cancellationToken);
    }
}
