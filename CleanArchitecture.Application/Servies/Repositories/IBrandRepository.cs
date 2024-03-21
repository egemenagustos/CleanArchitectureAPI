using CleanArchitecture.Domain.Entities;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Application.Servies.Repositories
{
    public interface IBrandRepository : IAsyncRepository<Brand,Guid>, IRepository<Brand,Guid>
    {
    }
}
