using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RegistroCajaConfiguration : IEntityTypeConfiguration<RegistroCaja>
    {
        public void Configure(EntityTypeBuilder<RegistroCaja> builder)
        {
            builder.Property(b => b.FechaTransaccion).HasDefaultValueSql("GetDate()");
            builder.Property(b => b.NumeroDocumento).HasMaxLength(100);
            builder.Property(b => b.MontoPago).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoCapital).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoInteres).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoIvaIntereses).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoMora).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoIvaMora).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoGastos).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoIvaGastos).HasColumnType("decimal(18,2)");
            builder.Property(b => b.MontoCapitalAnticipado).HasColumnType("decimal(18,2)");            
            builder.Property(b => b.TotalCuotasVencidas).HasColumnType("decimal(18,2)");
            builder.Property(b => b.Observaciones).HasMaxLength(400);
            builder.Property(b => b.MotivoAnulacion).HasMaxLength(400);
            builder.Property(b => b.BatchKey).HasMaxLength(37);
        }
    }
}
