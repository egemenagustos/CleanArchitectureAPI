using AutoMapper;
using CleanArchitecture.Application.Features.Models.Queries.GetList;
using CleanArchitecture.Application.Features.Models.Queries.GetListByDynamic;
using CleanArchitecture.Domain.Entities;
using Core.Application.Responses;
using Core.Persistance.Paging;

namespace CleanArchitecture.Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Paginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();

            CreateMap<Model, GetListModelListItemDto>()
                .ForMember(destinationMember : x => x.BrandName, memberOptions : x => x.MapFrom(x => x.Brand.Name))
                .ForMember(destinationMember : x => x.FuelName, memberOptions : x => x.MapFrom(x => x.Fuel.Name))
                .ForMember(destinationMember : x => x.TransmissionName, memberOptions : x => x.MapFrom(x => x.Transmission.Name))
                .ReverseMap();

            CreateMap<Paginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();

            CreateMap<Model, GetListByDynamicModelListItemDto>()
                .ForMember(destinationMember: x => x.BrandName, memberOptions: x => x.MapFrom(x => x.Brand.Name))
                .ForMember(destinationMember: x => x.FuelName, memberOptions: x => x.MapFrom(x => x.Fuel.Name))
                .ForMember(destinationMember: x => x.TransmissionName, memberOptions: x => x.MapFrom(x => x.Transmission.Name))
                .ReverseMap();
        }
    }
}
