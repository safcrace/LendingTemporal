using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class DesembolsoConfiguration : IEntityTypeConfiguration<Desembolso>
    {
        public void Configure(EntityTypeBuilder<Desembolso> builder)
        {           
            builder.Property(x => x.AprobacionCreditos).HasMaxLength(100);
            builder.Property(x => x.AprobacionDireccion).HasMaxLength(100);
            builder.Property(x => x.AprobacionGerencia).HasMaxLength(100);
        }
    }
}
