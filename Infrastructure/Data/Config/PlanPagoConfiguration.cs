using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PlanPagoConfiguration : IEntityTypeConfiguration<PlanPago>
    {
        public void Configure(EntityTypeBuilder<PlanPago> builder)
        {
            builder.Property(x => x.FechaPlan).IsRequired().HasColumnType("Date");
            builder.Property(x => x.MontoPlan).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontoCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Plazo).IsRequired();
            builder.Property(x => x.TasaInteres).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.TasaIva).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.TasaGastosAdministrativos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.TasaMora).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoGastosAdministrativos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIva).IsRequired().HasColumnType("decimal(18,2)");            
        }
    }
}
