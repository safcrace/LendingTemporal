﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class ParametrosDepartamentosConfiguration : IEntityTypeConfiguration<ParametrosDepartamentos>
    {
        public void Configure(EntityTypeBuilder<ParametrosDepartamentos> builder)
        {
            builder.Property(x => x.MontoMinimo).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontoMaximo).HasColumnType("decimal(18,2)");
            builder.Property(x => x.MontoPredeterminado).HasColumnType("decimal(18,2)");
        }
    }
}