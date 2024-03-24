using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Models.Queries.GetList
{
    public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
    {
        public PageRequest PageRequest  { get; set; }

        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                Paginate<Model> models = await _modelRepository.GetListAsync(
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    include: x => x.Include(x => x.Brand).Include(x => x.Fuel).Include(x => x.Transmission),
                    cancellationToken: cancellationToken
                    );

                GetListResponse<GetListModelListItemDto> response = 
                    _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);

                return response;
            }
        }
    }
}
