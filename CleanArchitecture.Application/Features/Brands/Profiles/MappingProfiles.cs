using AutoMapper;
using CleanArchitecture.Application.Features.Brands.Commands.Create;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
        }
    }
}
