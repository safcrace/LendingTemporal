using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class DetalleDesembolsoConfiguration : IEntityTypeConfiguration<DetalleDesembolso>
    {
        public void Configure(EntityTypeBuilder<DetalleDesembolso> builder)
        {
            builder.Property(x => x.NumeroCuenta).HasMaxLength(15);
            builder.Property(x => x.NombreEmisionCheque).HasMaxLength(100);
            builder.Property(x => x.Comentario).HasMaxLength(100);
            builder.Property(x => x.CantidadDesembolso).HasColumnType("decimal(18,2)");
        }
    }
}
