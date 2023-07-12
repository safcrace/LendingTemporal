using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class InteresesDepartamentosConfiguration : IEntityTypeConfiguration<InteresesDepartamentos>
    {
        public void Configure(EntityTypeBuilder<InteresesDepartamentos> builder)
        {
            builder.Property(x => x.TasaMinima).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TasaMaxima).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TasaPredeterminada).HasColumnType("decimal(18,2)");            
        }
    }
}
