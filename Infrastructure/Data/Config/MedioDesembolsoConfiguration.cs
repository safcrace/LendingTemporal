using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class MedioDesembolsoConfiguration : IEntityTypeConfiguration<MedioDesembolso>
    {
        public void Configure(EntityTypeBuilder<MedioDesembolso> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
        }
    }
}
