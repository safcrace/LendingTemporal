using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class SesionConfiguration : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.HasOne(s => s.TipoBitacora).WithMany()
                 .HasForeignKey(c => c.TipoBitacoraId);
            builder.HasOne(s => s.AppUser).WithMany()
                 .HasForeignKey(c => c.AppUserId);
            builder.Property(s => s.Token).HasMaxLength(1000);
        }
    }
}
