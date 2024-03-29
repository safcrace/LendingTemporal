﻿using Core.Entities;
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
            builder.Property(x => x.PrimerNombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SegundoNombre).HasMaxLength(50);
            builder.Property(x => x.PrimerApellido).IsRequired().HasMaxLength(50);
            builder.Property(x => x.SegundoApellido).HasMaxLength(50);
            builder.Property(x => x.ApellidoCasada).HasMaxLength(50);
            builder.Property(x => x.FechaNacimiento).HasColumnType("Date");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(75);
            builder.Property(x => x.Direccion).HasMaxLength(150);
            builder.Property(x => x.Colonia).HasMaxLength(50);
            builder.Property(x => x.Comentarios).HasMaxLength(200);
            builder.Property(x => x.NumeroTelefono).HasMaxLength(32);
            builder.Property(x => x.NumeroCelular).HasMaxLength(20);
            builder.Property(x => x.NumeroTelefonoLaboral).HasMaxLength(20);
            builder.Property(x => x.DireccionLaboral).HasMaxLength(150);
            builder.Property(x => x.NumeroDocumento).HasMaxLength(25);
        }
    }
}
