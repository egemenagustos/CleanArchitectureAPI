﻿using AutoMapper;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Pipelines.Caching;
using MediatR;

namespace CleanArchitecture.Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? CacheKey => "";

        public bool BypassCache { get; }

        public string? CacheGroupKey => "GetBrands";

        public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;

            public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
            {
                _mapper = mapper;
                _brandRepository = brandRepository;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(
                    predicate: x => x.Id == request.Id,
                    cancellationToken: cancellationToken
                    );

                brand = _mapper.Map(request,brand);
                await _brandRepository.UpdateAsync(brand);

                UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);
                return response;
            }
        }
    }
}
