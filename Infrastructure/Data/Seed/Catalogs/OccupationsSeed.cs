using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed.Catalogs;

public static class OccupationsSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var occupations = new Ocupacion[]
        {
            new()
            {
                Id = 1,
                Nombre = "ASISTENTE",
                Descripcion = "ASISTENTE",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "AGENTE",
                Descripcion = "AGENTE",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "ANALISTA",
                Descripcion = "ANALISTA",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "ARQUITECTO",
                Descripcion = "ARQUITECTO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "ARTESANO",
                Descripcion = "ARTESANO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 6,
                Nombre = "AUXILIAR",
                Descripcion = "AUXILIAR",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 7,
                Nombre = "CAJERO",
                Descripcion = "CAJERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 8,
                Nombre = "CARNICERO",
                Descripcion = "CARNICERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 9,
                Nombre = "CARPINTERO",
                Descripcion = "CARPINTERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 10,
                Nombre = "COCINERO",
                Descripcion = "COCINERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 11,
                Nombre = "EJECUTIVO",
                Descripcion = "EJECUTIVO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 12,
                Nombre = "ESTILISTA",
                Descripcion = "ESTILISTA",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 13,
                Nombre = "ENFERMERO",
                Descripcion = "ENFERMERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 14,
                Nombre = "JEFATURA",
                Descripcion = "JEFATURA",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 15,
                Nombre = "INGENIERO",
                Descripcion = "INGENIERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 16,
                Nombre = "OPERARIO",
                Descripcion = "OPERARIO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 17,
                Nombre = "MECÁNICO",
                Descripcion = "MECÁNICO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 18,
                Nombre = "MEDICO",
                Descripcion = "MEDICO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 19,
                Nombre = "MENSAJERO",
                Descripcion = "MENSAJERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 20,
                Nombre = "PANADERO",
                Descripcion = "PANADERO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 21,
                Nombre = "PILOTO",
                Descripcion = "PILOTO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 22,
                Nombre = "PROFESOR",
                Descripcion = "PROFESOR",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 23,
                Nombre = "PROPIETARIO",
                Descripcion = "PROPIETARIO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 24,
                Nombre = "SERVICIOS PROFESIONALES",
                Descripcion = "SERVICIOS PROFESIONALES",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 25,
                Nombre = "TÉCNICO",
                Descripcion = "TÉCNICO",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            },
            new()
            {
                Id = 26,
                Nombre = "VENDEDOR",
                Descripcion = "VENDEDOR",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true
            }
        };

        builder.Entity<Ocupacion>().HasData(occupations);
    }
}