using App.Domain.Models.Integrations.ViaCepIntegrations;

namespace App.Domain.Interfaces.Integrations.V1
{
    public interface IViaCepIntegration
    {
        Task<AddressIntegrationViewModel> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken);
    }
}
