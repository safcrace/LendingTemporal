using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RelacionConfiguration : IEntityTypeConfiguration<Relacion>
    {
        public void Configure(EntityTypeBuilder<Relacion> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(100);           
        }
    }
}
