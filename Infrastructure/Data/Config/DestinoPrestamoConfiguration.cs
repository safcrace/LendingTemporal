using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DestinoPrestamoConfiguration : IEntityTypeConfiguration<DestinoPrestamo>
    {       
        public void Configure(EntityTypeBuilder<DestinoPrestamo> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasMaxLength(100);
        }
    }
}
