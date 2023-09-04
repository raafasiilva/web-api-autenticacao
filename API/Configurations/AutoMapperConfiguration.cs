using API.Models.Mappings;
using AutoMapper;

namespace API.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureModelMapper() =>
            new(options =>
            {
                options.AddProfile<AddressModelMapping>();
                options.AddProfile<BaseModelMapping>();
            });
    }
}
