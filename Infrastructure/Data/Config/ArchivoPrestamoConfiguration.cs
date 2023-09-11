using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ArchivoPrestamoConfiguration : IEntityTypeConfiguration<ArchivoPrestamo>
    {
        public void Configure(EntityTypeBuilder<ArchivoPrestamo> builder)
        {
            builder.Property(x => x.Descripcion).HasMaxLength(150);
            builder.Property(x => x.NombreDocumentoSid).HasMaxLength(150);
        }
    }
}
