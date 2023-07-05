using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasMaxLength(100);
        }
    }
}
