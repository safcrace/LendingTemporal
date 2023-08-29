using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class OrigenSolicitudConfiguration : IEntityTypeConfiguration<OrigenSolicitud>
    {
        public void Configure(EntityTypeBuilder<OrigenSolicitud> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(75);
            builder.Property(b => b.Descripcion).HasMaxLength(75);
        }
    }
}
