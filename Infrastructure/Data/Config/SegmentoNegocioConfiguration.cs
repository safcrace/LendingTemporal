using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SegmentoNegocioConfiguration : IEntityTypeConfiguration<SegmentoNegocio>
    {
        public void Configure(EntityTypeBuilder<SegmentoNegocio> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Descripcion).HasMaxLength(125);
        }
    }
}
