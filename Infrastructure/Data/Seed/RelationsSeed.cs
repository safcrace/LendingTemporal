using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class RelationsSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var relations = new RelacionEntidad[]
        {
            new()
            {
                Id = 1,
                TipoRelacionId = 2,
                EntidadPadreId = 1,
                EntidadHijaId = 2,
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
        };

        builder.Entity<RelacionEntidad>().HasData(relations);
    }
}