using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dyanmic;
using Core.Persistance.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Models.Queries.GetListByDynamic
{
    public class GetListByDynamicQuery : IRequest<GetListResponse<GetListByDynamicModelListItemDto>>
    {
        public PageRequest PageRequest  { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

        public class GetListByDynamicQueryHandler : IRequestHandler<GetListByDynamicQuery, GetListResponse<GetListByDynamicModelListItemDto>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListByDynamicModelListItemDto>> Handle(GetListByDynamicQuery request, CancellationToken cancellationToken)
            {
                Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                    dynamic: request.DynamicQuery,
                    include: x => x.Include(x => x.Brand).Include(x => x.Fuel).Include(x => x.Transmission),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                    );

                GetListResponse<GetListByDynamicModelListItemDto>  response = 
                    _mapper.Map<GetListResponse<GetListByDynamicModelListItemDto>>(models);

                return response;
            }
        }
    }
}
