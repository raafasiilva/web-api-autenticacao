using System.Text.Json.Serialization;

namespace App.Domain.Models.Integrations.ViaCepIntegrations
{
    public class AddressIntegrationViewModel
    {
        public AddressIntegrationViewModel() { }

        public AddressIntegrationViewModel(string zipCode, string street, string district, string city, string stateCode, string complement)
        {
            ZipCode = zipCode;
            Street = street;
            District = district;
            City = city;
            StateCode = stateCode;
            Complement = complement;
        }

        [JsonPropertyName("cep")]
        public string ZipCode { get; set; }

        [JsonPropertyName("logradouro")]
        public string Street { get; set; }

        [JsonPropertyName("bairro")]
        public string District { get; set; }

        [JsonPropertyName("localidade")]
        public string City { get; set; }

        [JsonPropertyName("uf")]
        public string StateCode { get; set; }

        [JsonPropertyName("complemento")]
        public string Complement { get; set; }
    }
}
