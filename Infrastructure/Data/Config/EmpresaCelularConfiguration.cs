using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class EmpresaCelularConfiguration : IEntityTypeConfiguration<EmpresaCelular>
    {
        public void Configure(EntityTypeBuilder<EmpresaCelular> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(75);
            builder.Property(b => b.Descripcion).HasMaxLength(75);
        }
    }
}
