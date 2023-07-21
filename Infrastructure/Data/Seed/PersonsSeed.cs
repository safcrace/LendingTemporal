using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed;

public static class PersonsSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var persons = new Persona[]
        {
            new()
            {
                Id = 1,
                EntidadId = 2,
                GeneroId = 1,
                EstadoCivilId = 1,
                SegundoApellido = null,
                PrimerNombre = "User",
                ApellidoCasada = null,
                FechaNacimiento = null,
                Email = "user@example.com",
                Direccion = null,
                NIT = "123412340",
                NumeroTelefono = null,
                NumeroDocumento = "123412340",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true,
                Colonia = null,
                Comentarios = null,
                DepartamentoId = null,
                MunicipioId = null,
                NumeroCelular = null,
                NumeroTelefonoNegocio = null,
                OcupacionSinFinId = null,
                PaisNacimientoId = null,
                PrimerApellido = "Example",
                SegundoNombre = null,
                DireccionNegocio = null,
                //TipoViviendaId = null
            }
        };

        builder.Entity<Persona>().HasData(persons);

        var maritalStatus = new EstadoCivil[]
        {
            new()
            {
                Id = 1,
                Nombre = "Soltero(a)",
                Descripcion = "Soltero(a)",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            },
            new()
            {
                Id = 2,
                Nombre = "Casado(a)",
                Descripcion = "Casado(a)",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            },
            new()
            {
                Id = 3,
                Nombre = "Divorciado(a)",
                Descripcion = "Divorciado(a)",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            },
            new()
            {
                Id = 4,
                Nombre = "Viudo(a)",
                Descripcion = "Viudo(a)",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            }
        };

        builder.Entity<EstadoCivil>().HasData(maritalStatus);

        var genres = new Genero[]
        {
            new()
            {
                Id = 1,
                Nombre = "Masculino",
                Descripcion = "Masculino",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            },
            new()
            {
                Id = 2,
                Nombre = "Femenino",
                Descripcion = "Femenino",
                FechaModificacion = DateTime.Parse("2023-05-16"),
                FechaCreacion = DateTime.Parse("2023-05-16"),
            }
        };

        builder.Entity<Genero>().HasData(genres);
    }
}