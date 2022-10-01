using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PlanPagoConfiguration : IEntityTypeConfiguration<PlanPago>
    {
        public void Configure(EntityTypeBuilder<PlanPago> builder)
        {
            builder.Property(x => x.Periodo).IsRequired();
            builder.Property(x => x.CuotaCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaGastos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaGastos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoCapital).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIntereses).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIvaIntereses).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIvaMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoGastos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIvaGastos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalCuota).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoTotal).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.FechaPago).HasColumnType("Date");            
        }
    }
}
