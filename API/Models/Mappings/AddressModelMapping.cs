using API.Models.Contracts.AddressModels;
using App.Domain.Models.Entities.Schemas.Authentication;
using App.Domain.Models.Integrations.ViaCepIntegrations;
using AutoMapper;

namespace API.Models.Mappings
{
    public class AddressModelMapping : Profile
    {
        public AddressModelMapping()
        {
            CreateMap<AddressIntegrationViewModel, AddressViewModel>();
            CreateMap<AddressCreationModel, Address>();
            CreateMap<AddressUpdateModel, Address>();
            CreateMap<Address, AddressViewModel>();
        }
    }
}
