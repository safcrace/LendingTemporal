using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class TipoCuotaConfiguration : IEntityTypeConfiguration<TipoCuota>
    {
        public void Configure(EntityTypeBuilder<TipoCuota> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasMaxLength(100);
        }
    }
}
