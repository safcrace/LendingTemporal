using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed.Catalogs;

public static class BankSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var banks = new Banco[]
        {
            new()
            {
                Id = 1,
                Nombre = "Banco Industrial",
                Descripcion = "Banco Industrial",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Banrural",
                Descripcion = "Banrural",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "Banco G&T Continental",
                Descripcion = "Banco G&T Continental",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "No Aplica",
                Descripcion = "No Aplica",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            }
        };

        builder.Entity<Banco>().HasData(banks);

        var boxes = new Caja[]
        {
            new()
            {
                Id = 1,
                Nombre = "Caja General",
                Descripcion = "Caja General",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            }
        };

        builder.Entity<Caja>().HasData(boxes);
    }
}