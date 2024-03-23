using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistance.EntityConfigurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("Fuels").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");

            builder.HasIndex(indexExpression: x => x.Name, name: "UK_Fuels_Name").IsUnique();
            builder.HasMany(x => x.Models);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
