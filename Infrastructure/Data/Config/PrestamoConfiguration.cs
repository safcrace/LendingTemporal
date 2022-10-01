using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class PrestamoConfiguration : IEntityTypeConfiguration<Prestamo>
    {
        public void Configure(EntityTypeBuilder<Prestamo> builder)
        {   
            builder.Property(x => x.ReferenciaMigracion).HasMaxLength(125);
            builder.Property(x => x.MontoOtorgado).HasColumnType("decimal(18,2)");
            builder.Property(x => x.InteresProyectado).HasColumnType("decimal(18,2)");
            builder.Property(x => x.IvaProyectado).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GastosProyectados).HasColumnType("decimal(18,2)");                        
            builder.Property(x => x.MontoTotalProyectado).HasColumnType("decimal(18,2)");                        
            builder.Property(x => x.TasaInteres).HasColumnType("decimal(18,2)");                        
            builder.Property(x => x.TasaIva).HasColumnType("decimal(18,2)");                        
            builder.Property(x => x.TasaMora).HasColumnType("decimal(18,2)");                        
            builder.Property(x => x.TasaGastos).HasColumnType("decimal(18,2)");
        }
    }
}
