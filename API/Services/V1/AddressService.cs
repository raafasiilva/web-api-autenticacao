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
    public class AddressService(IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper) 
        : BaseService<AddressService>(serviceWrapper, repositoryWrapper), IAddressService
    {
        public async Task AddAddressAsync(AddressCreationModel creationModel, CancellationToken cancellationToken)
        {
            Address address = _serviceWrapper.Mapper.Map<Address>(creationModel).Normalize();
            ValidationResult validations = new AddressInsertValidation().Validate(address);

            if (!validations.IsValid) ThrowException(validations);

            await _repositoryWrapper.Address.AddAsync(address, cancellationToken);
        }

        public async Task<AddressViewModel> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken) =>
            _serviceWrapper.Mapper.Map<AddressViewModel>(await _repositoryWrapper.Address.GetByIdAsync(id, cancellationToken));

        public async Task<ModelCollectionBaseViewModel<AddressViewModel>> GetAllAdressesAsync(FilterParamBaseQueryModel queryModel, CancellationToken cancellationToken) =>
            _serviceWrapper.Mapper.Map<ModelCollectionBaseViewModel<AddressViewModel>>(await _repositoryWrapper.Address
                .GetAllAsync(_serviceWrapper.Mapper.Map<FilterParamBase>(queryModel), cancellationToken));

        public async Task<AddressViewModel> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken) =>
            _serviceWrapper.Mapper.Map<AddressViewModel>(await _serviceWrapper.ViaCepIntegration.GetAddressByZipCodeAsync(zipCode));

        public async Task RemoveAddressByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _repositoryWrapper.Address.RemoveAsync(await _repositoryWrapper.Address.GetByIdAsync(id, cancellationToken), cancellationToken);

        public async Task UpdateAddressAsync(AddressUpdateModel updateModel, CancellationToken cancellationToken)
        {
            Address address = _serviceWrapper.Mapper.Map<Address>(updateModel).Normalize();
            ValidationResult validations = await new AddressUpdateValidation(_repositoryWrapper).ValidateAsync(address);

            if (!validations.IsValid) ThrowException(validations);

            await _repositoryWrapper.Address.UpdateAsync(address, cancellationToken);
        }
    }
}
