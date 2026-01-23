using App.Domain.Interfaces.Integrations.V1;
using App.Domain.Interfaces.Kernels;
using App.Domain.Models.Integrations.ViaCepIntegrations;
using System.Text.Json;

namespace App.Infraestructure.Integrations.V1
{
    public class ViaCepIntegration(HttpClient httpClient, IExceptionNotificationKernel exceptionNotificationKernel) 
        : BaseIntegration(httpClient, exceptionNotificationKernel), IViaCepIntegration
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Consulta endereço pelo CEP.
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns></returns>
        public async Task<AddressIntegrationViewModel> GetAddressByZipCodeAsync(string zipCode, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, $"{zipCode}/json");
            using HttpResponseMessage httpResponseMessage = await _httpClient
                .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);

            if (!httpResponseMessage.IsSuccessStatusCode)
                ThrowException($"Erro ao realizar a busca pelo CEP: {zipCode}");

            await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
            AddressIntegrationViewModel response = await JsonSerializer
                .DeserializeAsync<AddressIntegrationViewModel>(stream, _jsonOptions, cancellationToken);

            return response!;
        }
    }
}
