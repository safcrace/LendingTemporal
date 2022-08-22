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
    internal class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {
            builder.Property(x => x.FechaAprobacion).HasColumnType("Date");
            builder.Property(x => x.MontoCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoIva).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoGastosAdministrativos).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.SaldoMora).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.InteresesAcumulados).IsRequired().HasColumnType("decimal(18,2)");            
        }
    }
}
