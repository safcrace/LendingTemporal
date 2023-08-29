using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MotivoRechazoConfiguration : IEntityTypeConfiguration<MotivoRechazo>
    {
        public void Configure(EntityTypeBuilder<MotivoRechazo> builder)
        {
            builder.Property(x => x.Nombre).HasMaxLength(150);
        }
    }
}
