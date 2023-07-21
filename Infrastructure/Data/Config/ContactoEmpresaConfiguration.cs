using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ContactoEmpresaConfiguration : IEntityTypeConfiguration<ContactoEmpresa>
    {
        public void Configure(EntityTypeBuilder<ContactoEmpresa> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(75);            
        }
    }
}
