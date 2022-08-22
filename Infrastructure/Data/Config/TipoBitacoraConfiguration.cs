using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TipoBitacoraConfiguration : IEntityTypeConfiguration<TipoBitacora>
    {
        public void Configure(EntityTypeBuilder<TipoBitacora> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(75);
            builder.Property(b => b.Descripcion).HasMaxLength(75);
        }
    }
}
