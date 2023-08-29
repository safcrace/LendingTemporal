using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ContactoEmpresaConfiguration : IEntityTypeConfiguration<ContactoEmpresa>
    {
        public void Configure(EntityTypeBuilder<ContactoEmpresa> builder)
        {
            builder.Property(b => b.PrimerNombre).IsRequired().HasMaxLength(75);            
            builder.Property(b => b.SegundoNombre).HasMaxLength(75);            
            builder.Property(b => b.TercerNombre).HasMaxLength(75);            
            builder.Property(b => b.PrimerApellido).IsRequired().HasMaxLength(75);            
            builder.Property(b => b.SegundoApellido).HasMaxLength(75);            
            builder.Property(b => b.ApellidoCasada).HasMaxLength(75);            
            builder.Property(b => b.TelefonoPrincipal).HasMaxLength(40);            
            builder.Property(b => b.Celular).HasMaxLength(40);            
        }
    }
}
