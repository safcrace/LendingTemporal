using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class EntrevistaConfiguration : IEntityTypeConfiguration<Entrevista>
    {
        public void Configure(EntityTypeBuilder<Entrevista> builder)
        {
            builder.Property(x => x.Texto).HasMaxLength(25000);
        }
    }
}
