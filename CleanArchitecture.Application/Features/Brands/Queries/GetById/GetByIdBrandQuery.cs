using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Brands.Queries.GetById
{
    public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
    {
        public Guid Id { get; set; }

        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public GetByIdBrandQueryHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    withDeleted : true,
                    cancellationToken: cancellationToken
                    );

                GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(brand);

                return response;
            }
        }
    }
}
