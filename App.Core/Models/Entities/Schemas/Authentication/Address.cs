using App.Domain.Models.Entities.BaseEntities;

namespace App.Domain.Models.Entities.Schemas.Authentication
{
    public class Address : AddressBase
    {
        public Address Normalize()
        {
            ZipCode = ZipCode?.Replace("-", "");
            StateCode = StateCode?.ToUpper();
            Complement = string.IsNullOrEmpty(Complement) ? null : Complement;

            return this;
        }
    }
}
