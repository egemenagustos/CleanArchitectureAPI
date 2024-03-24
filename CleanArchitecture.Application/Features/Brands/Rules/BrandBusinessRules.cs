using CleanArchitecture.Application.Features.Brands.Constants;
using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace CleanArchitecture.Application.Features.Brands.Rules
{
    public class BrandBusinessRules : BaseBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCannotBeDuplicatedWhenInserted(string name)
        {
            Brand? brand = await _brandRepository.GetAsync(
                predicate: x => x.Name.ToLower() == name.ToLower()
                );

            if (brand is not null)
                throw new BusinessException(BrandsMessages.BrandNameExists);
        }
    }
}
