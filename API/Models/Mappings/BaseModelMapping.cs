using API.Models.Contracts.AddressModels;
using API.Models.Contracts.BaseModels;
using App.Domain.Models.Entities.BaseEntities;
using App.Domain.Models.Entities.Schemas.Authentication;
using App.Domain.Models.FilterParams.BaseFilters;
using AutoMapper;

namespace API.Models.Mappings
{
    public class BaseModelMapping: Profile
    {
        public BaseModelMapping()
        {
            CreateMap<EntityCollectionBase<Address>, ModelCollectionBaseViewModel<AddressViewModel>>();
            CreateMap<FilterParamBaseQueryModel, FilterParamBase>();
        }
    }
}
