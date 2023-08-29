using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class TipoCuentaConfiguration : IEntityTypeConfiguration<TipoCuenta>
    {
        public void Configure(EntityTypeBuilder<TipoCuenta> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}
