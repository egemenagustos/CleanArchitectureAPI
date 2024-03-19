using Core.Persistance.Repositories;

namespace CleanArchitecture.Domain.Entities
{
    public class Brand : Entity<Guid>
    {
        public Brand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Brand()
        {
        }

        public string Name { get; set; }
    }
}