using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Persistance.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
