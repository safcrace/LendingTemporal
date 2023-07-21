using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CanalIngresoConfiguration : IEntityTypeConfiguration<CanalIngreso>
    {
        public void Configure(EntityTypeBuilder<CanalIngreso> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(75);
            builder.Property(b => b.Descripcion).HasMaxLength(75);
        }
    }
}
