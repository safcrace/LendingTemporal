using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TipoPrestamoConfiguration : IEntityTypeConfiguration<TipoPrestamo>
    {
        public void Configure(EntityTypeBuilder<TipoPrestamo> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Descripcion).HasMaxLength(150);           
            builder.Property(x => x.TasaIva).HasPrecision(18,2);
            builder.Property(x => x.MonedaId).HasDefaultValue(1);
            builder.Property(x => x.TPA).HasMaxLength(200);
            builder.Property(x => x.MontoMinimoJefeCreditos).HasPrecision(18,2);
            builder.Property(x => x.MontoMaximoJefeCreditos).HasPrecision(18,2);
            builder.Property(x => x.MontoMinimoComiteGerencia).HasPrecision(18,2);
            builder.Property(x => x.MontoMaximoComiteGerencia).HasPrecision(18,2);
            builder.Property(x => x.MontoMinimoComiteDirectores).HasPrecision(18,2);
            builder.Property(x => x.MontoMaximoComiteDirectores).HasPrecision(18,2);
        }
    }
}
