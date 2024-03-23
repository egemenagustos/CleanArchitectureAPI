using CleanArchitecture.Domain.Entities;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Application.Servies.Repositories
{
    public interface IModelRepository : IAsyncRepository<Model, Guid>, IRepository<Model, Guid>
    {
    }
}
