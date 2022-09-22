using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TipoTransaccionConfiguration : IEntityTypeConfiguration<TipoTransaccion>
    {
        public void Configure(EntityTypeBuilder<TipoTransaccion> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Nombre).HasMaxLength(100);
        }
    }
}
