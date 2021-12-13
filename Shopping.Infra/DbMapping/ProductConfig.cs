using Shopping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.Infra.DbMapping
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(p => p.ProductId);

            entity.Property(p => p.CreatedAt);
            entity.HasIndex(x => x.CreatedAt);

            entity.Property(p => p.Name).IsRequired().HasMaxLength(25);
            entity.Property(p => p.Description).HasMaxLength(500);

            entity.Property(p => p.Price)
                .HasPrecision(12, 10);

            entity.Ignore(p => p.Quantity);

            entity.HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}
