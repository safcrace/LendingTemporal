using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DocumentoPrestamoConfiguration : IEntityTypeConfiguration<DocumentosPrestamo>
    {
        public void Configure(EntityTypeBuilder<DocumentosPrestamo> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Descripcion).HasMaxLength(150);
        }
    }
}
