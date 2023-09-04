using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Kernels;
using App.Domain.Models.Integrations.ViaCepIntegrations;
using System.Text.Json;

namespace App.Infraestructure.Integrations.V1
{
    public class ViaCepIntegration : BaseIntegration, IViaCepIntegration
    {
        public ViaCepIntegration(HttpClient httpClient, IExceptionNotificationKernel exceptionNotificationKernel)
            : base(httpClient, exceptionNotificationKernel) { }

        /// <summary>
        /// Consulta endereço pelo CEP.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<AddressIntegrationViewModel> GetAddressByZipCodeAsync(string zipCode)
        {
            using HttpResponseMessage httpResponseMessage = await _httpClient
                .GetAsync($"{zipCode}/json", HttpCompletionOption.ResponseHeadersRead);

            if (!httpResponseMessage.IsSuccessStatusCode)
                ThrowException($"Erro ao realizar a busca pelo CEP: {zipCode}");

            AddressIntegrationViewModel response = JsonSerializer
                .Deserialize<AddressIntegrationViewModel>(await httpResponseMessage.Content.ReadAsStringAsync());

            return response;
        }
    }
}
