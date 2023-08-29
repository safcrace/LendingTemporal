using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BitacoraPrestamoConfiguration : IEntityTypeConfiguration<BitacoraPrestamo>
    {
        public void Configure(EntityTypeBuilder<BitacoraPrestamo> builder)
        {
            builder.Property(x => x.Comentarios).HasMaxLength(300);
        }
    }
}
