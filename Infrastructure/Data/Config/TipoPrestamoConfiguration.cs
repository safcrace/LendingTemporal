using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TipoPrestamoConfiguration : IEntityTypeConfiguration<TipoPrestamo>
    {
        public void Configure(EntityTypeBuilder<TipoPrestamo> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasMaxLength(100);
            builder.Property(x => x.MinInteres).HasPrecision(18,2);
            builder.Property(x => x.MaxInteres).HasPrecision(18,2);
            builder.Property(x => x.MinGastos).HasPrecision(18,2);
            builder.Property(x => x.MaxGastos).HasPrecision(18,2);
            builder.Property(x => x.MinMora).HasPrecision(18,2);
            builder.Property(x => x.MaxMora).HasPrecision(18,2);
            builder.Property(x => x.MinMonto).HasPrecision(18,2);
            builder.Property(x => x.MaxMonto).HasPrecision(18,2);
            builder.Property(x => x.CurrencyId).HasDefaultValue(1);
        }
    }
}
