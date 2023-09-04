using System;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Contracts.AddressModels
{
    [ExcludeFromCodeCoverage]
    public class AddressUpdateModel
    {
        public AddressUpdateModel() { }

        public AddressUpdateModel(string zipCode, string street, string number, string district, string city, string stateCode, string complement)
        {
            Id = new Guid();
            ZipCode = zipCode;
            Street = street;
            Number = number;
            District = district;
            City = city;
            StateCode = stateCode;
            Complement = complement;
        }

        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string Complement { get; set; }
    }
}
