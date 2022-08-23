using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {

            //builder.HasOne(c => c.Pais).WithMany()
            //     .HasForeignKey(c => c.PaisId)
            //     .OnDelete(DeleteBehavior.Restrict);
            

            builder.Property(x => x.NIT).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Nombres).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Apellidos).IsRequired().HasMaxLength(150);
            builder.Property(x => x.ApellidoCasada).HasMaxLength(150);
            builder.Property(x => x.FechaNacimiento).HasColumnType("Date");
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Direccion).HasMaxLength(150);
            builder.Property(x => x.NumeroTelefono).HasMaxLength(32);
            builder.Property(x => x.NumeroDocumento).HasMaxLength(25);
        }
    }
}
