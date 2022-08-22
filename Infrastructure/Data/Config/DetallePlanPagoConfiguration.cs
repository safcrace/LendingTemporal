using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DetallePlanPagoConfiguration : IEntityTypeConfiguration<DetallePlanPago>
    {
        public void Configure(EntityTypeBuilder<DetallePlanPago> builder)
        {
            builder.Property(x => x.Mes).IsRequired();
            builder.Property(x => x.CuotaCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaGastosAdministrativos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIva).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SubTotalCuota).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalCuota).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Saldo).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.FechaPago).HasColumnType("Date");
        }
    }
}
