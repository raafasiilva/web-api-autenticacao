namespace App.Domain.Models.Entities.BaseEntities
{
    public class AddressBase : EntityBase
    {
        public AddressBase() { }
        public AddressBase(string zipCode, string street, string number, string district,
            string city, string stateCode, string complement)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            District = district;
            City = city;
            StateCode = stateCode;
            Complement = complement;
        }

        public string StateCode { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
    }
}
