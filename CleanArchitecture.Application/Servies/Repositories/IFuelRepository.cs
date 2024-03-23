using CleanArchitecture.Domain.Entities;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Application.Servies.Repositories
{
    public interface IFuelRepository : IAsyncRepository<Fuel, Guid>, IRepository<Fuel, Guid>
    {
    }
}
