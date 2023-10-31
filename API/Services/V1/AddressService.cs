using API.Interfaces.Services;
using API.Interfaces.Services.V1;
using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;
using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Repositories;
using App.Domain.Models.Entities.Schemas.Authentication;
using App.Domain.Models.EntitiesValidations.AddressValidations;
using App.Domain.Models.FilterParams.BaseFilters;
using FluentValidation.Results;

namespace API.Services.V1
{
    public class AddressService : BaseService<AddressService>, IAddressService
    {
        public AddressService(IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper)
            : base(serviceWrapper, repositoryWrapper) { }

        public async Task AddAddressAsync(AddressCreationModel creationModel)
        {
            Address address = _serviceWrapper.Mapper.Map<Address>(creationModel).Normalize();
            ValidationResult validations = new AddressInsertValidation().Validate(address);

            if (!validations.IsValid) ThrowException(validations);

            await _repositoryWrapper.Address.AddAsync(address);
        }

        public async Task<AddressViewModel> GetAddressByIdAsync(Guid id) =>
            _serviceWrapper.Mapper.Map<AddressViewModel>(await _repositoryWrapper.Address.GetByIdAsync(id));

        public async Task<ModelCollectionBaseViewModel<AddressViewModel>> GetAllAdressesAsync(FilterParamBaseQueryModel queryModel) =>
            _serviceWrapper.Mapper.Map<ModelCollectionBaseViewModel<AddressViewModel>>(await _repositoryWrapper.Address
                .GetAllAsync(_serviceWrapper.Mapper.Map<FilterParamBase>(queryModel)));

        public async Task<AddressViewModel> GetAddressByZipCodeAsync(string zipCode) =>
            _serviceWrapper.Mapper.Map<AddressViewModel>(await _serviceWrapper.ViaCepIntegration.GetAddressByZipCodeAsync(zipCode));

        public async Task RemoveAddressByIdAsync(Guid id) =>
            await _repositoryWrapper.Address.RemoveAsync(await _repositoryWrapper.Address.GetByIdAsync(id));

        public async Task UpdateAddressAsync(AddressUpdateModel updateModel)
        {
            Address address = _serviceWrapper.Mapper.Map<Address>(updateModel).Normalize();
            ValidationResult validations = await new AddressUpdateValidation(_repositoryWrapper).ValidateAsync(address);

            if (!validations.IsValid) ThrowException(validations);

            await _repositoryWrapper.Address.UpdateAsync(address);
        }
    }
}
