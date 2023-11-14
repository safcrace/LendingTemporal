using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ReferenciaEmpresaConfiguration : IEntityTypeConfiguration<ReferenciaEmpresa>
    {
        public void Configure(EntityTypeBuilder<ReferenciaEmpresa> builder)
        {
            builder.Property(x => x.NombreCompleto).HasMaxLength(100);
            builder.Property(x => x.Comentario).HasMaxLength(6000);
        }
    }
}
