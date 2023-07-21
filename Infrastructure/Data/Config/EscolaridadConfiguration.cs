using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class EscolaridadConfiguration : IEntityTypeConfiguration<Escolaridad>
    {
        public void Configure(EntityTypeBuilder<Escolaridad> builder)
        {
            builder.Property(b => b.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Descripcion).HasMaxLength(125);
        }
    }
}
