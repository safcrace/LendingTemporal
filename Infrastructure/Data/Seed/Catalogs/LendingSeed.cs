using Core.Entities;
using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seed.Catalogs;

public static class LendingSeed
{
    public static void Seed(ModelBuilder builder)
    {
        var types = new TipoPrestamo[]
        {
            new()
            {
                Id = 1,
                Nombre = "Abasto",
                Descripcion = "Abasto",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Comerciante",
                Descripcion = "Comerciante",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "Consumo LD",
                Descripcion = "Consumo LD",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "Planillero",
                Descripcion = "Planillero",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "Retail-AVLB",
                Descripcion = "Retail-AVLB",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 6,
                Nombre = "Armerías - Retail",
                Descripcion = "Armerías - Retail",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 7,
                Nombre = "Automóviles",
                Descripcion = "Automóviles",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 8,
                Nombre = "Celulares-DEP",
                Descripcion = "Celulares-DEP",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 9,
                Nombre = "Celulares-IND",
                Descripcion = "Celulares-IND",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 10,
                Nombre = "Motos-DEP",
                Descripcion = "Motos-DEP",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoPrestamo>().HasData(types);

        var destinations = new DestinoPrestamo[]
        {
            new()
            {
                Id = 1,
                Nombre = "Libre Disponiblidad",
                Descripcion = "LIbre Disponibilidad",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Compra de Vehiculo",
                Descripcion = "Compra de Vehiculo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "Compra, Reparación o Ampliación de Vivienda",
                Descripcion = "Compra, Reparación o Ampliación de Vivienda",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "Compra Equipo de Cómputo",
                Descripcion = "Compra Equipo de Cómputo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "Consolidación de Deuda",
                Descripcion = "Consolidación de Deuda",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 6,
                Nombre = "Capital de Trabajo",
                Descripcion = "Capital de Trabajo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 7,
                Nombre = "Mobiliario y Equipo",
                Descripcion = "Mobiliario y Equipo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 8,
                Nombre = "Factoraje",
                Descripcion = "Factoraje",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 9,
                Nombre = "Activo Fijo",
                Descripcion = "Activo Fijo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 10,
                Nombre = "Compra de Mercaderia",
                Descripcion = "Compra de Mercaderia",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 11,
                Nombre = "[DESCONOCIDO]",
                Descripcion = "[DESCONOCIDO]",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<DestinoPrestamo>().HasData(destinations);

        var states = new EstadoPrestamo[]
        {
            new()
            {
                Id = 1,
                Nombre = "Activo",
                Descripcion = "Activo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "En Proceso",
                Descripcion = "En Proceso",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "En Demanda",
                Descripcion = "En Demanda",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "Cancelado",
                Descripcion = "Cancelado",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "Cancelado por migración",
                Descripcion = "Cancelado por migración",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 6,
                Nombre = "Liquidado por Recrédito",
                Descripcion = "Liquidado por Recrédito",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 7,
                Nombre = "Cartera Saneada",
                Descripcion = "Cartera Saneada",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<EstadoPrestamo>().HasData(states);

        var origins = new EstadoOrigen[]
        {
            new()
            {
                Id = 1,
                Nombre = "CARTERA SANEADA",
                Descripcion = "CARTERA SANEADA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "LISTO A DESEMBOLSAR",
                Descripcion = "LISTO A DESEMBOLSAR",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "VENCIDO",
                Descripcion = "VENCIDO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "VIGENTE AL DIA",
                Descripcion = "VIGENTE AL DIA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "VIGENTE EN MORA",
                Descripcion = "VIGENTE EN MORA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<EstadoOrigen>().HasData(origins);

        var payforms = new FormaPago[]
        {
            new()
            {
                Id = 1,
                Nombre = "CHEQUE",
                Descripcion = "CHEQUE ",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "EFECTIVO",
                Descripcion = "EFECTIVO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 3,
                Nombre = "TRANSFERENCIA",
                Descripcion = "TRANSFERENCIA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "[DESCONOCIDO]",
                Descripcion = "[DESCONOCIDO]",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 5,
                Nombre = "DESEMBOLSO",
                Descripcion = "DESEMBOLSO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 6,
                Nombre = "REVESRA",
                Descripcion = "REVESRA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 7,
                Nombre = "REESTRUCTURA",
                Descripcion = "REESTRUCTURA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 8,
                Nombre = "CARTERA SANEADA",
                Descripcion = "CARTERA SANEADA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 9,
                Nombre = "AJUSTE",
                Descripcion = "AJUSTE",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 10,
                Nombre = "RESTRUCTURA",
                Descripcion = "RESTRUCTURA",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 11,
                Nombre = "DEPÓSITO",
                Descripcion = "DEPÓSITO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 12,
                Nombre = "RENEGOCIACIÓN",
                Descripcion = "RENEGOCIACIÓN",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 13,
                Nombre = "NOTA DÉBITO",
                Descripcion = "NOTA DÉBITO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = false
            },
            new()
            {
                Id = 14,
                Nombre = "TARJETA DE CREDITO",
                Descripcion = "TARJETA DE CREDITO",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<FormaPago>().HasData(payforms);

        var transactionTypes = new TipoTransaccion[]
        {
            new()
            {
                Id = 1,
                Nombre = "Cargo Saldo Capital",
                Descripcion = "Cargo de Monto Total del Prestamo",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 2,
                Nombre = "Cargo Saldo Intereses",
                Descripcion = "Cargo Saldo Inicial de Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 3,
                Nombre = "Cargo Saldo Iva",
                Descripcion = "Cargo Saldo Inicial de Iva",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 4,
                Nombre = "Cargo Saldo Mora",
                Descripcion = "Cargo Saldo Inicial Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 5,
                Nombre = "Cargo Saldo Iva Mora",
                Descripcion = "Cargo Saldo Inicial Iva Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 6,
                Nombre = "Cargo Saldo Gastos",
                Descripcion = "Cargo Saldo Inicial Gastos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 7,
                Nombre = "Cargo Saldo Iva Gastos",
                Descripcion = "Cargo Saldo Inicial Iva Gastos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 8,
                Nombre = "Abono Capital",
                Descripcion = "Abono Saldo de Capital",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 9,
                Nombre = "Abono Intereses",
                Descripcion = "Abono Saldo Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 10,
                Nombre = "Abono Iva Intereses",
                Descripcion = "Abono Saldo Iva Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 11,
                Nombre = "Abono Mora",
                Descripcion = "Abono Saldo Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 12,
                Nombre = "Abono Iva Mora",
                Descripcion = "Abono Saldo Iva Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 13,
                Nombre = "Abono Gastos",
                Descripcion = "Abono Saldo Gastos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 14,
                Nombre = "Abono Iva Gastos",
                Descripcion = "Abono Saldo Iva Gastos",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 15,
                Nombre = "Abono Migración",
                Descripcion = "Abono Migración",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 16,
                Nombre = "Cargo por Regularización",
                Descripcion = "Cargo por Regularización",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 17,
                Nombre = "Abono de Ajuste de Iva de Intereses",
                Descripcion = "Abono de Ajuste de Iva de Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 18,
                Nombre = "Abono de Ajuste por Migración",
                Descripcion = "Abono de Ajuste por Migración",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 19,
                Nombre = "Cargo de Ajuste por Migración",
                Descripcion = "Cargo de Ajuste por Migración",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 20,
                Nombre = "Abono de Ajuste de Intereses",
                Descripcion = "Abono de Ajuste de Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 21,
                Nombre = "Abono de Ajuste de Iva de Mora",
                Descripcion = "Abono de Ajuste de Iva de Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 22,
                Nombre = "Abono de Ajuste Mora",
                Descripcion = "Abono de Ajuste Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 23,
                Nombre = "Cargo de Ajuste Iva de Intereses",
                Descripcion = "Cargo de Ajuste Iva de Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 24,
                Nombre = "Cargo de Ajuste Intereses",
                Descripcion = "Cargo de Ajuste Intereses",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 25,
                Nombre = "Cargo de Ajuste Iva de Mora",
                Descripcion = "Cargo de Ajuste Iva de Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 26,
                Nombre = "Cargo de Ajuste Mora",
                Descripcion = "Cargo de Ajuste Mora",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 27,
                Nombre = "Nota de Débito (Ajuste por Liquidación)",
                Descripcion = "Nota de Débito (Ajuste por Liquidación)",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            },
            new()
            {
                Id = 28,
                Nombre = "Transacción por Regularización",
                Descripcion = "Transacción por Regularización",
                FechaCreacion = DateTime.Parse("2023-05-16"),
                FechaModificacion = DateTime.Parse("2023-05-16"),
                Habilitado = true
            }
        };

        builder.Entity<TipoTransaccion>().HasData(transactionTypes);
    }
}