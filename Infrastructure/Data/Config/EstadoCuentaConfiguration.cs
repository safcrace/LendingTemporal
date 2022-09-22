using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class EstadoCuentaConfiguration : IEntityTypeConfiguration<EstadoCuenta>
    {
        public void Configure(EntityTypeBuilder<EstadoCuenta> builder)
        {
            builder.Property(x => x.Cargo).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Abono).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoAnterior).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoActual).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Concepto).IsRequired().HasMaxLength(500);
        }
    }
}
