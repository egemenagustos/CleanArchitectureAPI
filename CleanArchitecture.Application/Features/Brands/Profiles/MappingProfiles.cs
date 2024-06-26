﻿using AutoMapper;
using CleanArchitecture.Application.Features.Brands.Commands.Create;
using CleanArchitecture.Application.Features.Brands.Commands.Delete;
using CleanArchitecture.Application.Features.Brands.Commands.Update;
using CleanArchitecture.Application.Features.Brands.Queries.GetById;
using CleanArchitecture.Application.Features.Brands.Queries.GetList;
using CleanArchitecture.Domain.Entities;
using Core.Application.Responses;
using Core.Persistance.Paging;

namespace CleanArchitecture.Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();

            CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
            CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();

            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();

            CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();

            CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
        }
    }
}
