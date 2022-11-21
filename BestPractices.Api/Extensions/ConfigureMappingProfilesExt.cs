using AutoMapper;

using BestPractices.Api.Data.Entities;
using BestPractices.Api.Models;

namespace BestPractices.Api.Extensions
{
    public static class ConfigureMappingProfilesExt
    {
        public static IServiceCollection ConfigureCustomMapping(this IServiceCollection services)
        {
            // Mapper configurations
            var mappingConfig = new MapperConfiguration(c => c.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

            return services;
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Contact, ContactDAO>()
                    .ForMember(
                        destMem => destMem.FullName,
                        opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                    ).ReverseMap();
            }
        }
    }
}
