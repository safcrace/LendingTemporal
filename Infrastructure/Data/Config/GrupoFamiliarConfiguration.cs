using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GrupoFamiliarConfiguration : IEntityTypeConfiguration<GrupoFamiliar>
    {
        public void Configure(EntityTypeBuilder<GrupoFamiliar> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Descripcion).HasMaxLength(50);
        }
    }
}
