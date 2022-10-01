using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class AbonoPlanConfiguration : IEntityTypeConfiguration<AbonoPlan>
    {
        public void Configure(EntityTypeBuilder<AbonoPlan> builder)
        {
            builder.Property(x => x.CuotaCapital).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaIntereses).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaMora).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaGastos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.CuotaIvaGastos).HasColumnType("decimal(18,2)");
        }
    }
}
