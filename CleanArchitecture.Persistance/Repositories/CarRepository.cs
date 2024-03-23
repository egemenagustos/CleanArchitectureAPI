using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Persistance.Repositories
{
    public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
    {
        public CarRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
