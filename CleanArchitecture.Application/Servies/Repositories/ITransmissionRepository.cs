using CleanArchitecture.Domain.Entities;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Application.Servies.Repositories
{
    public interface ITransmissionRepository : IAsyncRepository<Transmission, Guid>, IRepository<Transmission, Guid>
    {
    }
}
