using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Alias).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).HasMaxLength(30);
            builder.Property(x => x.Direccion).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Nit).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Nit).IsUnique();
            builder.Property(x => x.VentasMensuales).HasColumnType("decimal(18,2)");
            builder.Property(x => x.GananciasMensuales).HasColumnType("decimal(18,2)");
            builder.Property(x => x.OtrosIngresos).HasColumnType("decimal(18,2)");
            builder.Property(x => x.OrigenOtrosIngresos).HasMaxLength(200);
            builder.Property(x => x.Comentarios).HasMaxLength(150);            
        }
    }
}
