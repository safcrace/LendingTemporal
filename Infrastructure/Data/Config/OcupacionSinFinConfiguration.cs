using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OcupacionSinFinConfiguration : IEntityTypeConfiguration<OcupacionSinFin>
    {
        public void Configure(EntityTypeBuilder<OcupacionSinFin> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Descripcion).HasMaxLength(100);
        }
    }
}
