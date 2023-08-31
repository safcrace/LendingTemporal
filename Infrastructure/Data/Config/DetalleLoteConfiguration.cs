using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DetalleLoteConfiguration : IEntityTypeConfiguration<DetalleLote>
    {
        public void Configure(EntityTypeBuilder<DetalleLote> builder)
        {
            builder.Property(x => x.NombreEmisionCheque).HasMaxLength(100);
            builder.Property(x => x.Monto).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Documento).HasMaxLength(150);
        }
    }
}
