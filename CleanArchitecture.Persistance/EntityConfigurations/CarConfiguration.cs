﻿using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(x => x.Kilometer).HasColumnName("Kilometer").IsRequired();
            builder.Property(x => x.CarState).HasColumnName("State").IsRequired();
            builder.Property(x => x.ModelYear).HasColumnName("ModelYear").IsRequired();

            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasOne(x => x.Model);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
