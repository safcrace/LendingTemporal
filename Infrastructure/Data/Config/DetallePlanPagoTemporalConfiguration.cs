using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class DetallePlanPagoTemporalConfiguration : IEntityTypeConfiguration<DetallePlanPagoTemporal>
    {
        public void Configure(EntityTypeBuilder<DetallePlanPagoTemporal> builder)
        {
            builder.Property(x => x.Mes).IsRequired();
            builder.Property(x => x.CuotaCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaGastosAdministrativos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaIntereses).IsRequired().HasColumnType("decimal(18,2)");           
            builder.Property(x => x.TotalCuota).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.FechaPago).HasColumnType("Date");
        }
    }
}
