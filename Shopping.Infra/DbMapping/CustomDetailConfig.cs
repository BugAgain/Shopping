using Shopping.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.Infra.DbMapping
{
    public class CustomDetailConfig : IEntityTypeConfiguration<CustomDetail>
    {
        public void Configure(EntityTypeBuilder<CustomDetail> entity)
        {
            entity.HasKey(p => p.CustomDetailId);

            entity.HasOne(p => p.Product).WithMany(p => p.CustomDetails);
        }
    }
}
