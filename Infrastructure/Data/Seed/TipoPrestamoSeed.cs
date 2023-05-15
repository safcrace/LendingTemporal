using Core.Entities.Configuration;
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
                Name = "Quetzales",
                Description = "Moneda de Guatemala",
                Symbol = "Q",
                Habilitado = true,
                FechaCreacion = DateTime.Parse("2023-05-12"),
                FechaModificacion = DateTime.Parse("2023-05-12")
            },
            new()
            {
                Id = 2,
                Name = "Dolares",
                Description = "Moneda de Estados Unidos",
                Symbol = "$",
                Habilitado = true,
                FechaCreacion = DateTime.Parse("2023-05-12"),
                FechaModificacion = DateTime.Parse("2023-05-12")
            }
        };
        
        builder.Entity<Moneda>().HasData(currencies);
    }
}