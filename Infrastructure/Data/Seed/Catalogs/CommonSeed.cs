using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed.Catalogs;

public static class CommonSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var logTypes = new TipoBitacora[]
        {
            new()
            {
                Id = 1,
                Nombre = "Ingreso Sistema",
                Descripcion = "Ingreso Sistema",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Salida Sistema",
                Descripcion = "Salida Sistema",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoBitacora>().HasData(logTypes);

        var housingTypes = new TipoVivienda[]
        {
            new()
            {
                Id = 1,
                Nombre = "FAMILIAR",
                Descripcion = "FAMILIAR",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "PROPIA",
                Descripcion = "PROPIA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "ALQUILADA",
                Descripcion = "ALQUILADA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoVivienda>().HasData(housingTypes);
    }
}