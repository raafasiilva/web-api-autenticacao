using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;

namespace API.Interfaces.Services.V1
{
    public interface IAddressService : IBaseService
    {
        Task AddAddressAsync(AddressCreationModel creationModel);
        Task<AddressViewModel> GetAddressByIdAsync(Guid id);
        Task<ModelCollectionBaseViewModel<AddressViewModel>> GetAllAdressesAsync(FilterParamBaseQueryModel queryModel);
        Task<AddressViewModel> GetAddressByZipCodeAsync(string zipCode);
        Task RemoveAddressByIdAsync(Guid id);
        Task UpdateAddressAsync(AddressUpdateModel updateModel);
    }
}
