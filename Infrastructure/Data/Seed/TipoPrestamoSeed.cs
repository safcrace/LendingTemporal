using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class TipoPrestamoSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var currencies = new Moneda[]
        {
            new()
            {
                Id = 1,
                Nombre = "Quetzales",
                Descripcion = "Moneda de Guatemala",
                Simbolo = "Q",
                Habilitado = true,
                FechaCreacion = DateTime.Parse("2023-05-12"),
                FechaModificacion = DateTime.Parse("2023-05-12")
            },
            new()
            {
                Id = 2,
                Nombre = "Dolares",
                Descripcion = "Moneda de Estados Unidos",
                Simbolo = "$",
                Habilitado = true,
                FechaCreacion = DateTime.Parse("2023-05-12"),
                FechaModificacion = DateTime.Parse("2023-05-12")
            }
        };
        
        builder.Entity<Moneda>().HasData(currencies);
    }
}