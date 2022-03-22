using AutoMapper;
using Domain;
using Features.CustomerFeatures.Queries;
using Features.PackageFeatures.Queries;
using Features.PromotionFeatures.Queries;

namespace Features.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(
                        dest => dest.Promotions,
                        opt => opt.MapFrom(src => src.PromotionPrograms.Select(x => x.Promotion))
                    );
        CreateMap<Promotion, CustomerPromotionDto>();
        CreateMap<Package, PackageDto>();
        CreateMap<Promotion, PromotionDto>();
    }
}