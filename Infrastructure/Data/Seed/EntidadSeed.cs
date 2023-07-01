using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class EntidadSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var entities = new Entidad[]
        {
            new()
            {
                Id = 2,
                TipoEntidadId = 1,
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 1,
                TipoEntidadId = 2,
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
        };

        builder.Entity<Entidad>().HasData(entities);

        var types = new TipoEntidad[]
        {
            new()
            {
                Id = 1,
                Nombre = "Persona",
                Descripcion = "Persona",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Organización",
                Descripcion = "Organización",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoEntidad>().HasData(types);

        var relationTypes = new TipoRelacion[]
        {
            new()
            {
                Id = 1,
                Nombre = "Cliente",
                Descripcion = "Cliente",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Asesor",
                Descripcion = "Asesor",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "Empleado",
                Descripcion = "Empleado",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "Empresa con planilla",
                Descripcion = "Empresa con planilla",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoRelacion>().HasData(relationTypes);
    }
}