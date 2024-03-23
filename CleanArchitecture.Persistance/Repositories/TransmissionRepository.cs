using CleanArchitecture.Application.Servies.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Contexts;
using Core.Persistance.Repositories;

namespace CleanArchitecture.Persistance.Repositories
{
    public class TransmissionRepository : EfRepositoryBase<Transmission, Guid, BaseDbContext>, ITransmissionRepository
    {
        public TransmissionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
