using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductoInteresadoConfiguration : IEntityTypeConfiguration<ProductoInteresado>
    {
        public void Configure(EntityTypeBuilder<ProductoInteresado> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Descripcion).HasMaxLength(150);
        }
    }
}
