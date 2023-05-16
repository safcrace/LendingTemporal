using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed.Catalogs;

public static class DepartmentSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var deparments = new Departamento[]
        {
            new()
            {
                Id = 1,
                Nombre = "Guatemala",
                Descripcion = "Guatemala",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 2,
                Nombre = "El Progreso",
                Descripcion = "El Progreso",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 3,
                Nombre = "Sacatepéquez",
                Descripcion = "Sacatepéquez",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 4,
                Nombre = "Chimaltenango",
                Descripcion = "Chimaltenango",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 5,
                Nombre = "Escuintla",
                Descripcion = "Escuintla",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 6,
                Nombre = "Santa Rosa",
                Descripcion = "Santa Rosa",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 7,
                Nombre = "Solola",
                Descripcion = "Solola",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 8,
                Nombre = "Totonicapán",
                Descripcion = "Totonicapán",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 9,
                Nombre = "Quetzaltenango",
                Descripcion = "Quetzaltenango",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 10,
                Nombre = "Suchitepéquez",
                Descripcion = "Suchitepéquez",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 11,
                Nombre = "Retalhuleu",
                Descripcion = "Retalhuleu",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 12,
                Nombre = "San Marcos",
                Descripcion = "San Marcos",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 13,
                Nombre = "Huehuetenango",
                Descripcion = "Huehuetenango",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 14,
                Nombre = "Quiché",
                Descripcion = "Quiché",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 15,
                Nombre = "Baja Verapaz",
                Descripcion = "Baja Verapaz",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 16,
                Nombre = "Alta Verapaz",
                Descripcion = "Alta Verapaz",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 17,
                Nombre = "Petén",
                Descripcion = "Petén",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 18,
                Nombre = "Izabal",
                Descripcion = "Izabal",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 19,
                Nombre = "Zacapa",
                Descripcion = "Zacapa",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 20,
                Nombre = "Chiquimula",
                Descripcion = "Chiquimula",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 21,
                Nombre = "Jalapa",
                Descripcion = "Jalapa",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            },
            new()
            {
                Id = 22,
                Nombre = "Jutiapa",
                Descripcion = "Jutiapa",
                FechaCreacion = DateTime.Parse("2023-16-05"),
                FechaModificacion = DateTime.Parse("2023-16-05"),
                Habilitado = true,
                PaisId = null
            }
        };

        builder.Entity<Departamento>().HasData(deparments);
    }
}