using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace CleanArchitecture.Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string? CacheKey => "";

        public bool BypassCache { get; }

        public string? CacheGroupKey => "GetBrands";

        public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    cancellationToken: cancellationToken
                    );

                await _brandRepository.DeleteAsync(brand);

                DeletedBrandResponse response = _mapper.Map<DeletedBrandResponse>(brand);
                return response;
            }
        }
    }
}
