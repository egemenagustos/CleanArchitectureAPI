using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;

namespace CleanArchitecture.Application.Features.Brands.Queries.GetList
{
    public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                Paginate<Brand> brand = await _brandRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    withDeleted : true,
                    cancellationToken: cancellationToken
                    );

                GetListResponse<GetListBrandListItemDto> response =
                    _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brand);

                return response;
            }
        }
    }
}
