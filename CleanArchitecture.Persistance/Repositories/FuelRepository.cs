using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Persistance.Repositories
{
    public class FuelRepository : EfRepositoryBase<Fuel, Guid, BaseDbContext>, IFuelRepository
    {
        public FuelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
