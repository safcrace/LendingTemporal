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
            builder.Property(x => x.Telefono).HasMaxLength(30);
            builder.Property(x => x.Direccion).HasMaxLength(100);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Nit).IsRequired().HasMaxLength(50);            
        }
    }
}
