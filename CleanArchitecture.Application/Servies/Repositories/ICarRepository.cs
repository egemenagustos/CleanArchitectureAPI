using CleanArchitecture.Domain.Entities;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Application.Servies.Repositories
{
    public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
    {
    }
}
