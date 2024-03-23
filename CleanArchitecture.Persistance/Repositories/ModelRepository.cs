using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Persistance.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, Guid, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
