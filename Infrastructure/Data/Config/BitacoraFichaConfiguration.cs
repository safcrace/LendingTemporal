using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BitacoraFichaConfiguration : IEntityTypeConfiguration<BitacoraFicha>
    {
        public void Configure(EntityTypeBuilder<BitacoraFicha> builder)
        {
            builder.Property(x => x.Comentarios).HasMaxLength(300);
        }
    }
}
