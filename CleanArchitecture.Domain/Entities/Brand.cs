﻿using Core.Persistance.Repositories;

namespace CleanArchitecture.Domain.Entities
{
    public class Brand : Entity<Guid>
    {
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public Brand(Guid id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public Brand()
        {
            Models = new HashSet<Model>();
        }
    }
}