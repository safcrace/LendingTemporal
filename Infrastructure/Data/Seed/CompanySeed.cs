using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class CompanySeed
{
    public static void Seed(ModelBuilder builder)
    {
        var companies = new Empresa[]
        {
            new()
            {
                Id = 1,
                EntidadId = 1,
                Nombre = "SinFin S.A.",
                Direccion = "Zona 15",
                Telefono = "123456",
                Email = "admin@sinfin.com",
                Nit = "12345678",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            }
        };

        builder.Entity<Empresa>().HasData(companies);
    }
}