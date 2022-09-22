using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class GestorConfiguration : IEntityTypeConfiguration<Gestor>
    {
        public void Configure(EntityTypeBuilder<Gestor> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).HasMaxLength(30);
            builder.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
