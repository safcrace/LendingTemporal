using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bancos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Banco Industrial", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Banco Industrial" },
                    { 2, "Banrural", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Banrural" },
                    { 3, "Banco G&T Continental", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Banco G&T Continental" },
                    { 4, "No Aplica", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "No Aplica" }
                });

            migrationBuilder.InsertData(
                table: "Cajas",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[] { 1, "Caja General", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Caja General" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { 1, "Guatemala", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guatemala", null },
                    { 2, "El Progreso", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Progreso", null },
                    { 3, "Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sacatepéquez", null },
                    { 4, "Chimaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chimaltenango", null },
                    { 5, "Escuintla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Escuintla", null },
                    { 6, "Santa Rosa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Rosa", null },
                    { 7, "Solola", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Solola", null },
                    { 8, "Totonicapán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Totonicapán", null },
                    { 9, "Quetzaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quetzaltenango", null },
                    { 10, "Suchitepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Suchitepéquez", null },
                    { 11, "Retalhuleu", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Retalhuleu", null },
                    { 12, "San Marcos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Marcos", null },
                    { 13, "Huehuetenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Huehuetenango", null },
                    { 14, "Quiché", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quiché", null },
                    { 15, "Baja Verapaz", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Baja Verapaz", null },
                    { 16, "Alta Verapaz", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alta Verapaz", null },
                    { 17, "Petén", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Petén", null },
                    { 18, "Izabal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Izabal", null },
                    { 19, "Zacapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zacapa", null },
                    { 20, "Chiquimula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chiquimula", null },
                    { 21, "Jalapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jalapa", null },
                    { 22, "Jutiapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jutiapa", null }
                });

            migrationBuilder.InsertData(
                table: "DestinoPrestamos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "LIbre Disponibilidad", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Libre Disponiblidad" },
                    { 2, "Compra de Vehiculo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Compra de Vehiculo" },
                    { 3, "Compra, Reparación o Ampliación de Vivienda", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Compra, Reparación o Ampliación de Vivienda" },
                    { 4, "Compra Equipo de Cómputo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Compra Equipo de Cómputo" },
                    { 5, "Consolidación de Deuda", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Consolidación de Deuda" },
                    { 6, "Capital de Trabajo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Capital de Trabajo" },
                    { 7, "Mobiliario y Equipo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mobiliario y Equipo" },
                    { 8, "Factoraje", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Factoraje" },
                    { 9, "Activo Fijo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Activo Fijo" },
                    { 10, "Compra de Mercaderia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Compra de Mercaderia" },
                    { 11, "[DESCONOCIDO]", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "[DESCONOCIDO]" }
                });

            migrationBuilder.InsertData(
                table: "EstadoCivil",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Soltero(a)", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4937), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4937), true, "Soltero(a)" },
                    { 2, "Casado(a)", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4938), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4938), true, "Casado(a)" },
                    { 3, "Divorciado(a)", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4939), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4939), true, "Divorciado(a)" },
                    { 4, "Viudo(a)", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4940), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4940), true, "Viudo(a)" }
                });

            migrationBuilder.InsertData(
                table: "EstadoPrestamos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Activo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Activo" },
                    { 2, "En Proceso", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "En Proceso" },
                    { 3, "En Demanda", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "En Demanda" },
                    { 4, "Cancelado", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cancelado" },
                    { 5, "Cancelado por migración", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cancelado por migración" },
                    { 6, "Liquidado por Recrédito", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Liquidado por Recrédito" },
                    { 7, "Cartera Saneada", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cartera Saneada" }
                });

            migrationBuilder.InsertData(
                table: "EstadosOrigen",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "CARTERA SANEADA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CARTERA SANEADA" },
                    { 2, "LISTO A DESEMBOLSAR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "LISTO A DESEMBOLSAR" },
                    { 3, "VENCIDO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "VENCIDO" },
                    { 4, "VIGENTE AL DIA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "VIGENTE AL DIA" },
                    { 5, "VIGENTE EN MORA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "VIGENTE EN MORA" }
                });

            migrationBuilder.InsertData(
                table: "FormaPagos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "CHEQUE ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CHEQUE" },
                    { 2, "EFECTIVO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "EFECTIVO" },
                    { 3, "TRANSFERENCIA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "TRANSFERENCIA" },
                    { 4, "[DESCONOCIDO]", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "[DESCONOCIDO]" },
                    { 5, "DESEMBOLSO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "DESEMBOLSO" },
                    { 6, "REVESRA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "REVESRA" },
                    { 7, "REESTRUCTURA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "REESTRUCTURA" },
                    { 8, "CARTERA SANEADA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "CARTERA SANEADA" },
                    { 9, "AJUSTE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "AJUSTE" },
                    { 10, "RESTRUCTURA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "RESTRUCTURA" },
                    { 11, "DEPÓSITO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "DEPÓSITO" },
                    { 12, "RENEGOCIACIÓN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "RENEGOCIACIÓN" },
                    { 13, "NOTA DÉBITO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "NOTA DÉBITO" },
                    { 14, "TARJETA DE CREDITO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "TARJETA DE CREDITO" }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Masculino", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4955), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4956), true, "Masculino" },
                    { 2, "Femenino", new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4957), new DateTime(2023, 5, 16, 10, 19, 14, 359, DateTimeKind.Local).AddTicks(4957), true, "Femenino" }
                });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "ASISTENTE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ASISTENTE" },
                    { 2, "AGENTE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "AGENTE" },
                    { 3, "ANALISTA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ANALISTA" },
                    { 4, "ARQUITECTO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ARQUITECTO" },
                    { 5, "ARTESANO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ARTESANO" },
                    { 6, "AUXILIAR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "AUXILIAR" },
                    { 7, "CAJERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CAJERO" },
                    { 8, "CARNICERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CARNICERO" },
                    { 9, "CARPINTERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "CARPINTERO" },
                    { 10, "COCINERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "COCINERO" },
                    { 11, "EJECUTIVO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "EJECUTIVO" },
                    { 12, "ESTILISTA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ESTILISTA" },
                    { 13, "ENFERMERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ENFERMERO" },
                    { 14, "JEFATURA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "JEFATURA" }
                });

            migrationBuilder.InsertData(
                table: "Ocupaciones",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 15, "INGENIERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "INGENIERO" },
                    { 16, "OPERARIO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "OPERARIO" },
                    { 17, "MECÁNICO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "MECÁNICO" },
                    { 18, "MEDICO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "MEDICO" },
                    { 19, "MENSAJERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "MENSAJERO" },
                    { 20, "PANADERO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "PANADERO" },
                    { 21, "PILOTO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "PILOTO" },
                    { 22, "PROFESOR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "PROFESOR" },
                    { 23, "PROPIETARIO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "PROPIETARIO" },
                    { 24, "SERVICIOS PROFESIONALES", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "SERVICIOS PROFESIONALES" },
                    { 25, "TÉCNICO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "TÉCNICO" },
                    { 26, "VENDEDOR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "VENDEDOR" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "ABW", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Holandesa", "Aruba" },
                    { "AFG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Afgana", "Afghanistan" },
                    { "AGO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Angola", "Angola" },
                    { "AIA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Anguilla", "Anguilla" },
                    { "ALB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Albanesa", "Albania" },
                    { "AND", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Andorrana", "Andorra" },
                    { "ANT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Holandesa", "Antillas Holandesas" },
                    { "ARE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Emiratense", "Emiratos Arabes Unidos" },
                    { "ARG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Argentina", "Argentina" },
                    { "ARM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Armenia", "Armenia" },
                    { "ASM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Norte Americana (Samoa)", "Samoa Americana" },
                    { "ATA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Antartica", "Antartica" },
                    { "ATF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francesa", "Territorio del Sur de Francia" },
                    { "ATG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Antigua y Barbuda", "Antigua y Barbuda" },
                    { "AUS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Australiana", "Australia" },
                    { "AUT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Austriaca", "Austria" },
                    { "AZE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Azerbaijan", "Azerbaijan" },
                    { "BDI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Burundi", "Burundi" },
                    { "BEL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Belga", "Belgica" },
                    { "BEN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Benin", "Benin" },
                    { "BFA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Burkina Faso", "Burkina Faso" },
                    { "BGD", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bangladesh", "Bangladesh" },
                    { "BGR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bulgara", "Bulgaria" },
                    { "BHR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bahrain", "Bahrain" },
                    { "BHS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bahamesa", "Bahamas" },
                    { "BIH", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bosnia and Herzegovina", "Bosnia and Herzegovina" },
                    { "BLR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bielorrusa", "Belarus" },
                    { "BLZ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Beliceña", "Belice" },
                    { "BMU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bermudesa", "Bermuda" },
                    { "BOL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Boliviana", "Bolivia" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "BRA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Brasileña", "Brasil" },
                    { "BRB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Barbadense", "Barbados" },
                    { "BRN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Brunei", "Brunei" },
                    { "BTN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Butana", "Butan" },
                    { "BVT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bouvet Island", "Bouvet Island" },
                    { "BWA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Botswana", "Botswana" },
                    { "CAF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Africana", "Republica Central de Africa" },
                    { "CAN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Canadiense", "Canada" },
                    { "CCK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Australiana", "Islas Cocos (Keeling)" },
                    { "CHE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Suiza", "Suiza" },
                    { "CHL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chilena", "Chile" },
                    { "CHN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "China", "China" },
                    { "CIV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Marfileña", "COSTA DE MARFIL" },
                    { "CMR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Camerunes", "Camerun" },
                    { "COG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Congolesa", "Congo" },
                    { "COK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Islas Cook", "Islas Cook" },
                    { "COL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Colombiana", "Colombia" },
                    { "COM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francesa", "Comoros" },
                    { "CPV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Caboverdiana", "Cabo Verde" },
                    { "CRI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Costarricense", "Costa Rica" },
                    { "CUB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cubana", "Cuba" },
                    { "CXR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Isla Navidad", "Isla Navidad" },
                    { "CYM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Caimanes", "Islas Caiman" },
                    { "CYP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chipriota", "Chipre" },
                    { "CZE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Checa", "Republica Checa" },
                    { "DEU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alemana", "Alemania" },
                    { "DJI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Yibutiana", "Yibuti" },
                    { "DMA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dominiques", "Dominica" },
                    { "DNK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Danesa", "Dinamarca" },
                    { "DOM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dominicana", "Republica Dominicana" },
                    { "DZA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Algeriana", "Algeria" },
                    { "ECU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ecuatoriana", "Ecuador" },
                    { "EGY", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Egipcia", "Egipto" },
                    { "ERI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Eritrea", "Eritrea" },
                    { "ESH", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sahauri", "Sahara Occidental" },
                    { "ESP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Española", "España" },
                    { "EST", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Estonia", "Estonia" },
                    { "ETH", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Etiope", "Etiopia" },
                    { "FIN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Finlandesa", "Finlandia" },
                    { "FJI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Fijena", "Islas de Fiji" },
                    { "FLK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kelpers", "Islas Malvinas" },
                    { "FRA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francesa", "Francia" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "FRO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Feroesa", "Islas Faroe" },
                    { "GAB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Gabona", "Gabon" },
                    { "GBR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Britanica", "Reino Unido" },
                    { "GEO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Georgiana", "Georgia" },
                    { "GHA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ghanesa", "Ghana" },
                    { "GIB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Gibraltareña", "Gibraltar" },
                    { "GIN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guinesa", "Guinea" },
                    { "GLP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francesa", "Guadeloupe" },
                    { "GMB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Gambiana", "Gambiana" },
                    { "GNB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Bissauguineana", "Guinea-Bissau" },
                    { "GNQ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ecuatoguineana", "Guinea Ecuatorial" },
                    { "GRC", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Griega", "Grecia" },
                    { "GRD", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Granadeña", "Granada" },
                    { "GRL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Groenlandesa", "Groenlandia" },
                    { "GTM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guatemalteca", "Guatemala" },
                    { "GUF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francoguyanesa", "Guyana Francesa" },
                    { "GUM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guamesa", "Guam" },
                    { "GUY", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guyanesa", "Guyana" },
                    { "HKG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Hongkonesa", "Hong Kong" },
                    { "HND", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Hondureña", "Honduras" },
                    { "HRV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Croata", "Croacia" },
                    { "HTI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Haitiana", "Haiti" },
                    { "HUN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Hungara", "Hungria" },
                    { "IDN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Indonesa", "Indonesia" },
                    { "IND", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "India", "India" },
                    { "IOT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chaguense", "Territorio Britanico del Oceano Indico" },
                    { "IRL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Irlandesa", "Irlanda" },
                    { "IRN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Irani", "Iran" },
                    { "IRQ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Iraqui", "Iraq" },
                    { "ISL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Islandesa", "Islandia" },
                    { "ISR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Israelita", "Israel" },
                    { "ITA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Italiana", "Italia" },
                    { "JAM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jamaiquino", "Jamaica" },
                    { "JOR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jordana", "Jordania" },
                    { "JPN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Japonesa", "Japon" },
                    { "KAZ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kazako", "Kazakstan" },
                    { "KEN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Keniana", "Kenia" },
                    { "KGZ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kiguiso", "Kirguistan" },
                    { "KHM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Camboyana", "Camboya" },
                    { "KIR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kiribatiana", "Kiribati" },
                    { "KNA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sancristobaleña", "San Cristobal y Nieves" },
                    { "KOR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Coreana", "Republica de Corea" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "KWT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Kuwaiti", "Kuwait" },
                    { "LAO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Laosiana", "Laos" },
                    { "LBN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Libanesa", "Libano" },
                    { "LBR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Liberiana", "Liberia" },
                    { "LBY", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Libica", "Libia" },
                    { "LCA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santaluciana", "Santa Lucia" },
                    { "LIE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Liechtensteiniana", "Liechtenstein" },
                    { "LKA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sri Lanka", "Sri Lanka" },
                    { "LSO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lesothensa", "Lesotho" },
                    { "LTU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lituana", "Lituania" },
                    { "LUX", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Luxemburguesa", "Luxemburgo" },
                    { "LVA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Leton", "Letonia" },
                    { "MAC", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Macaense", "Macao" },
                    { "MAR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Marroqui", "Marruecos" },
                    { "MCO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monaco", "Monaco" },
                    { "MDA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moldava", "Moldavia" },
                    { "MDG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Malgache", "Madagascar" },
                    { "MDV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Maldiva", "Maldivas" },
                    { "MEX", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mexicana", "Mexico" },
                    { "MHL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Marshalesa", "Islas Marshall" },
                    { "MKD", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Macedonia", "Macedonia" },
                    { "MLI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mali", "Mali" },
                    { "MLT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Maltesa", "Malta" },
                    { "MMR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Birmana", "Birmania" },
                    { "MNG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mongolesa", "Mongolia" },
                    { "MNP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Normarianense", "Islas Marianas del Norte" },
                    { "MOZ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mozambiqueña", "Mozambique" },
                    { "MRT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mauritana", "Mauritania" },
                    { "MSR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "De Montserrat", "Montserrat" },
                    { "MTQ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Martiniqueña", "Martinica" },
                    { "MUS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mauriciana", "Mauricio" },
                    { "MWI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Malawi", "Malawi" },
                    { "MYS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Malaya", "Malasia" },
                    { "MYT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mayotesa", "Mayotte" },
                    { "NAM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Namibia", "Namibia" },
                    { "NCL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Neocaledonia", "Nueva Caledonia" },
                    { "NER", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nigerina", "Niger" },
                    { "NFK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Norfolkense", "Isla Norfolk" },
                    { "NGA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nigeriana", "Nigeria" },
                    { "NIC", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "nicaragüense", "Nicaragua" },
                    { "NIU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Niuana", "Niue" },
                    { "NLD", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Neerlandesa", "Paises Bajos" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "NOR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Noruega", "Noruega" },
                    { "NPL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nepalesa", "Nepal" },
                    { "NRU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nauru", "Nauru" },
                    { "NZL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Neozelandesa", "Nueva Zelandia" },
                    { "OMN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Omana", "Oman" },
                    { "PAK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pakistani", "Pakistan" },
                    { "PAN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Panameña", "Panama" },
                    { "PCN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pitcairnesa", "Islas Pitcairn" },
                    { "PER", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Peruana", "Peru" },
                    { "PHL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Filipina", "Filipinas" },
                    { "PLW", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Palauana", "Palau" },
                    { "PNG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Papu Neoguineano", "Papua Nueva Guinea" },
                    { "POL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Polaca", "Polonia" },
                    { "PRI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Puertorriqueña", "Puerto Rico" },
                    { "PRK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Coreana", "Corea del Sur" },
                    { "PRT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Portuguesa", "Portugal" },
                    { "PRY", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Paraguaya", "Paraguay" },
                    { "PSE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Palestina", "Palestina" },
                    { "PYF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francopolinesia", "Polinesia Francesa" },
                    { "QAT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Catari", "Catar" },
                    { "REU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Reunionesa", "Runion" },
                    { "RKS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "kosovar", "Kosovo" },
                    { "ROM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Rumana", "Rumania" },
                    { "RUS", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Rusa", "Rusia" },
                    { "RWA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ruandes", "Ruanda" },
                    { "SAU", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Saudi", "Arabia Saudita" },
                    { "SCT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Escocesa", "ESCOCIA" },
                    { "SDN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sudanesa", "Sudan" },
                    { "SEN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "sebegalesa", "Senegal" },
                    { "SGP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Singapurense", "Singapur" },
                    { "SHN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santahelena", "Santa Helena" },
                    { "SLB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salomonense", "Islas Salomon" },
                    { "SLE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Leonesa", "Sierra Leona" },
                    { "SLV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salvadoreña", "Salvador" },
                    { "SMR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Marino", "San Marino" },
                    { "SOM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Somalia", "Somalia" },
                    { "SPM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedrina", "San Pedro y Miquelon" },
                    { "SRB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Serbia", "Serbia" },
                    { "STP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santotomense", "Santo Tome y Principe" },
                    { "SUR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Surinamesa", "Surinam" },
                    { "SVK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Eslovaca", "Eslovaquia" },
                    { "SVN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Eslovena", "Eslovenia" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "Nacionalidad", "Nombre" },
                values: new object[,]
                {
                    { "SWE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sueca", "Suecia" },
                    { "SWZ", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Suazi", "Swazilandia" },
                    { "SYC", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Seychelense", "Seychelles" },
                    { "SYR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Siria", "Siria" },
                    { "TCA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Turcocainesa", "Islas Turcas y Caicos" },
                    { "TCD", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chadiana", "Chad" },
                    { "TGO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Togolesa", "Togo" },
                    { "THA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tailandesa", "Tailandia" },
                    { "TJK", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tayika", "Tayikistan" },
                    { "TKL", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tokelauana", "Tokelau" },
                    { "TKM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Turcomana", "Turkmenistan" },
                    { "TMP", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Timorense", "Timor Leste" },
                    { "TON", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tonga", "Tonga" },
                    { "TTO", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Trinitense", "Trinidad y Tobago" },
                    { "TUN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tunecina", "Tunez" },
                    { "TUR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Turca", "Turquia" },
                    { "TUV", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tuvaluana", "Tuvalu" },
                    { "TWN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "China/Taiwan", "China/Taiwan" },
                    { "TZA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tanzana", "Tanzania" },
                    { "UGA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ugandesa", "Uganda" },
                    { "UKR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ucraniana", "Ucrania" },
                    { "URY", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Uruguaya", "Uruguay" },
                    { "USA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Estadounidense", "Estados Unidos" },
                    { "UZB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Uzbeca", "Uzbekistan" },
                    { "VAT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vaticana", "Ciudad del Vaticano" },
                    { "VCT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sanvicentina", "San Vicente y Granadinas" },
                    { "VEN", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Venezolana", "Venezuela" },
                    { "VGB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Virginense", "Islas Virgenes" },
                    { "VI", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vicentina", "Vicentina" },
                    { "VIR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Virginense Britanica", "Islas Virgenes" },
                    { "VNM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vietnamita", "Vietnam" },
                    { "VUT", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Vanuatuenense", "Vanuatu" },
                    { "WLF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Walisiana", "Wallis and Futuna" },
                    { "WSM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Samoana", "Samoa" },
                    { "YEM", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Yemen", "Yemen" },
                    { "YUG", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Yugoslava", "Yugoslavia" },
                    { "ZAF", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sudafricana", "Sudafrica" },
                    { "ZMB", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zambio", "Zambia" },
                    { "ZWE", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zimbabuense", "Zimbabue" }
                });

            migrationBuilder.InsertData(
                table: "TipoBitacoras",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Ingreso Sistema", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ingreso Sistema" },
                    { 2, "Salida Sistema", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salida Sistema" }
                });

            migrationBuilder.InsertData(
                table: "TipoEntidad",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[] { 1, "Persona", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Persona" });

            migrationBuilder.InsertData(
                table: "TipoEntidad",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[] { 2, "Organización", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Organización" });

            migrationBuilder.InsertData(
                table: "TipoPrestamos",
                columns: new[] { "Id", "CurrencyId", "Descripcion", "DiasGracia", "DisponibleOrganizaciones", "DisponiblePersonas", "FechaCreacion", "FechaModificacion", "Habilitado", "MaxCuotas", "MaxGastos", "MaxInteres", "MaxMonto", "MaxMora", "MinCuotas", "MinGastos", "MinInteres", "MinMonto", "MinMora", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Abasto", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Abasto" },
                    { 2, 1, "Comerciante", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Comerciante" },
                    { 3, 1, "Consumo LD", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Consumo LD" },
                    { 4, 1, "Planillero", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Planillero" },
                    { 5, 1, "Retail-AVLB", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Retail-AVLB" },
                    { 6, 1, "Armerías - Retail", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Armerías - Retail" },
                    { 7, 1, "Automóviles", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Automóviles" },
                    { 8, 1, "Celulares-DEP", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Celulares-DEP" },
                    { 9, 1, "Celulares-IND", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Celulares-IND" },
                    { 10, 1, "Motos-DEP", 0, false, false, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 0m, 0m, 0m, 0m, 1, 0m, 0m, 1m, 0m, "Motos-DEP" }
                });

            migrationBuilder.InsertData(
                table: "TipoRelacion",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cliente", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cliente" },
                    { 2, "Asesor", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Asesor" },
                    { 3, "Empleado", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Empleado" },
                    { 4, "Empresa con planilla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Empresa con planilla" }
                });

            migrationBuilder.InsertData(
                table: "TipoTransaccion",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Cargo de Monto Total del Prestamo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Capital" },
                    { 2, "Cargo Saldo Inicial de Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Intereses" },
                    { 3, "Cargo Saldo Inicial de Iva", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Iva" },
                    { 4, "Cargo Saldo Inicial Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Mora" },
                    { 5, "Cargo Saldo Inicial Iva Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Iva Mora" },
                    { 6, "Cargo Saldo Inicial Gastos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Gastos" },
                    { 7, "Cargo Saldo Inicial Iva Gastos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo Saldo Iva Gastos" },
                    { 8, "Abono Saldo de Capital", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Capital" },
                    { 9, "Abono Saldo Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Intereses" },
                    { 10, "Abono Saldo Iva Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Iva Intereses" },
                    { 11, "Abono Saldo Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Mora" },
                    { 12, "Abono Saldo Iva Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Iva Mora" },
                    { 13, "Abono Saldo Gastos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Gastos" },
                    { 14, "Abono Saldo Iva Gastos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Iva Gastos" },
                    { 15, "Abono Migración", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono Migración" },
                    { 16, "Cargo por Regularización", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo por Regularización" },
                    { 17, "Abono de Ajuste de Iva de Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono de Ajuste de Iva de Intereses" },
                    { 18, "Abono de Ajuste por Migración", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono de Ajuste por Migración" },
                    { 19, "Cargo de Ajuste por Migración", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo de Ajuste por Migración" },
                    { 20, "Abono de Ajuste de Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono de Ajuste de Intereses" },
                    { 21, "Abono de Ajuste de Iva de Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono de Ajuste de Iva de Mora" },
                    { 22, "Abono de Ajuste Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Abono de Ajuste Mora" },
                    { 23, "Cargo de Ajuste Iva de Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo de Ajuste Iva de Intereses" },
                    { 24, "Cargo de Ajuste Intereses", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo de Ajuste Intereses" },
                    { 25, "Cargo de Ajuste Iva de Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo de Ajuste Iva de Mora" },
                    { 26, "Cargo de Ajuste Mora", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cargo de Ajuste Mora" },
                    { 27, "Nota de Débito (Ajuste por Liquidación)", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nota de Débito (Ajuste por Liquidación)" }
                });

            migrationBuilder.InsertData(
                table: "TipoTransaccion",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[] { 28, "Transacción por Regularización", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Transacción por Regularización" });

            migrationBuilder.InsertData(
                table: "TiposVivienda",
                columns: new[] { "Id", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { 1, "FAMILIAR", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "FAMILIAR" },
                    { 2, "PROPIA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "PROPIA" },
                    { 3, "ALQUILADA", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "ALQUILADA" }
                });

            migrationBuilder.InsertData(
                table: "Entidades",
                columns: new[] { "Id", "FechaCreacion", "FechaModificacion", "Habilitado", "TipoEntidadId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 2, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "1001", 10, "Mazatenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mazatenango" },
                    { "1002", 10, "Cuyotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cuyotenango" },
                    { "1003", 10, "San Francisco Zapotitlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Francisco Zapotitlán" },
                    { "1004", 10, "San Bernardino", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Bernardino" },
                    { "1005", 10, "San José el Ídolo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José el Ídolo" },
                    { "1006", 10, "Santo Domingo Suchitepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santo Domingo Suchitepéquez" },
                    { "1007", 10, "San Lorenzo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Lorenzo" },
                    { "1008", 10, "Samayac", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Samayac" },
                    { "1009", 10, "San Pablo Jocopilas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pablo Jocopilas" },
                    { "101", 1, "Guatemala", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guatemala" },
                    { "1010", 10, "San Antonio Suchitepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Suchitepéquez" },
                    { "1011", 10, "San Miguel Panán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Panán" },
                    { "1012", 10, "San Gabriel", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Gabriel" },
                    { "1013", 10, "Chicacao", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chicacao" },
                    { "1014", 10, "Patulul", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Patulul" },
                    { "1015", 10, "Santa Bárbara", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Bárbara" },
                    { "1016", 10, "San Juan Bautista", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Bautista" },
                    { "1017", 10, "Santo Tomas la Unión", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santo Tomas la Unión" },
                    { "1018", 10, "Zunilito", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zunilito" },
                    { "1019", 10, "Pueblo Nuevo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pueblo Nuevo" },
                    { "102", 1, "Santa Catarina Pinula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina Pinula" },
                    { "1020", 10, "Río Bravo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Río Bravo" },
                    { "1021", 10, "San José La Máquina", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José La Máquina" },
                    { "103", 1, "San José Pinula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José Pinula" },
                    { "104", 1, "San José del Golfo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José del Golfo" },
                    { "105", 1, "Palencia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Palencia" },
                    { "106", 1, "Chinautla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chinautla" },
                    { "107", 1, "San Pedro Ayampuc", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Ayampuc" },
                    { "108", 1, "Mixco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mixco" },
                    { "109", 1, "San Pedro Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Sacatepéquez" },
                    { "110", 1, "San Juan Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Sacatepéquez" },
                    { "1101", 11, "Retalhuleu", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Retalhuleu" },
                    { "1102", 11, "San Sebastián", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Sebastián" },
                    { "1103", 11, "Santa Cruz Muluá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz Muluá" },
                    { "1104", 11, "San Martín Zapotitlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Martín Zapotitlán" },
                    { "1105", 11, "San Felipe", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Felipe" },
                    { "1106", 11, "San Andrés Villa Seca", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés Villa Seca" },
                    { "1107", 11, "Champerico", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Champerico" },
                    { "1108", 11, "Nuevo San Carlos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nuevo San Carlos" },
                    { "1109", 11, "El Asintal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Asintal" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "111", 1, "San Raymundo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Raymundo" },
                    { "112", 1, "Chuarrancho", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chuarrancho" },
                    { "113", 1, "Fraijanes", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Fraijanes" },
                    { "114", 1, "Amatitlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Amatitlán" },
                    { "115", 1, "Villa Nueva", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Villa Nueva" },
                    { "116", 1, "Villa Canales", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Villa Canales" },
                    { "117", 1, "Petapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Petapa" },
                    { "1201", 12, "San Marcos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Marcos" },
                    { "1202", 12, "San Pedro Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Sacatepéquez" },
                    { "1203", 12, "San Antonio Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Sacatepéquez" },
                    { "1204", 12, "Comitancillo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Comitancillo" },
                    { "1205", 12, "San Miguel Ixtahuacán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Ixtahuacán" },
                    { "1206", 12, "Concepción Tutuapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Concepción Tutuapa" },
                    { "1207", 12, "Tacaná", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tacaná" },
                    { "1208", 12, "Sibinal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sibinal" },
                    { "1209", 12, "Tajumulco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tajumulco" },
                    { "1210", 12, "Tejutla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tejutla" },
                    { "1211", 12, "San Rafael Pie de la Cuesta", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Rafael Pie de la Cuesta" },
                    { "1212", 12, "Nuevo Progreso", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nuevo Progreso" },
                    { "1213", 12, "El Tumbador", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Tumbador" },
                    { "1214", 12, "San José el Rodeo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José el Rodeo" },
                    { "1215", 12, "Malacatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Malacatán" },
                    { "1216", 12, "Catarina", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Catarina" },
                    { "1217", 12, "Ayutla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ayutla" },
                    { "1218", 12, "Ocós", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ocós" },
                    { "1219", 12, "San Pablo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pablo" },
                    { "1220", 12, "El Quetzal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Quetzal" },
                    { "1221", 12, "La Reforma", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Reforma" },
                    { "1222", 12, "Pajapita", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pajapita" },
                    { "1223", 12, "Ixchiguán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ixchiguán" },
                    { "1224", 12, "San José Ojetenam", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José Ojetenam" },
                    { "1225", 12, "San Cristóbal Cucho", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Cristóbal Cucho" },
                    { "1226", 12, "Sipacapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sipacapa" },
                    { "1227", 12, "Esquipulas Palo Gordo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Esquipulas Palo Gordo" },
                    { "1228", 12, "Río Blanco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Río Blanco" },
                    { "1229", 12, "San Lorenzo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Lorenzo" },
                    { "1230", 12, "La Blanca", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Blanca" },
                    { "1301", 13, "Huehuetenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Huehuetenango" },
                    { "1302", 13, "Chiantla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chiantla" },
                    { "1303", 13, "Malacatancito", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Malacatancito" },
                    { "1304", 13, "Cuilco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cuilco" },
                    { "1305", 13, "Nentón", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nentón" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "1306", 13, "San Pedro Necta", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Necta" },
                    { "1307", 13, "Jacaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jacaltenango" },
                    { "1308", 13, "San Pedro Soloma", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Soloma" },
                    { "1309", 13, "San Ildefonso Ixtahuacán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Ildefonso Ixtahuacán" },
                    { "1310", 13, "Santa Bárbara", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Bárbara" },
                    { "1311", 13, "La Libertad", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Libertad" },
                    { "1312", 13, "La Democracia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Democracia" },
                    { "1313", 13, "San Miguel Acatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Acatán" },
                    { "1314", 13, "San Rafael La Independencia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Rafael La Independencia" },
                    { "1315", 13, "Todos Santos Cuchumatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Todos Santos Cuchumatán" },
                    { "1316", 13, "San Juan Atitán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Atitán" },
                    { "1317", 13, "Santa Eulalia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Eulalia" },
                    { "1318", 13, "San Mateo Ixtatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Mateo Ixtatán" },
                    { "1319", 13, "Colotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Colotenango" },
                    { "1320", 13, "San Sebastián Huehuetenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Sebastián Huehuetenango" },
                    { "1321", 13, "Tectitán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tectitán" },
                    { "1322", 13, "Concepción Huista", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Concepción Huista" },
                    { "1323", 13, "San Juan Ixcoy", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Ixcoy" },
                    { "1324", 13, "San Antonio Huista", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Huista" },
                    { "1325", 13, "San Sebastián Coatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Sebastián Coatán" },
                    { "1326", 13, "Santa Cruz Barrillas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz Barrillas" },
                    { "1327", 13, "Aguacatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Aguacatán" },
                    { "1328", 13, "San Rafael Petzal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Rafael Petzal" },
                    { "1329", 13, "San Gaspar Ixchil", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Gaspar Ixchil" },
                    { "1330", 13, "Santiago Chimaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santiago Chimaltenango" },
                    { "1331", 13, "Santa Ana Huista", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Ana Huista" },
                    { "1332", 13, "Unión Cantinil", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Unión Cantinil" },
                    { "1333", 13, "Petatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Petatán" },
                    { "1401", 14, "Santa Cruz del Quiché", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz del Quiché" },
                    { "1402", 14, "Chiché", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chiché" },
                    { "1403", 14, "Chinique", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chinique" },
                    { "1404", 14, "Zacualpa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zacualpa" },
                    { "1405", 14, "Chajul", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chajul" },
                    { "1406", 14, "Santo TomásChichicastenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santo TomásChichicastenango" },
                    { "1407", 14, "Patzité", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Patzité" },
                    { "1408", 14, "San Antonio Ilotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Ilotenango" },
                    { "1409", 14, "San Pedro Jocopilas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Jocopilas" },
                    { "1410", 14, "Cunén", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cunén" },
                    { "1411", 14, "San Juan Cotzal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Cotzal" },
                    { "1412", 14, "Joyabaj", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Joyabaj" },
                    { "1413", 14, "Santa María Nebaj", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María Nebaj" },
                    { "1414", 14, "San Andrés Sajcabajá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés Sajcabajá" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "1415", 14, "San Miguel Uspantán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Uspantán" },
                    { "1416", 14, "Sacapulas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sacapulas" },
                    { "1417", 14, "San Bartolomé Jocotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Bartolomé Jocotenango" },
                    { "1418", 14, "Canillá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Canillá" },
                    { "1419", 14, "Chicamán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chicamán" },
                    { "1420", 14, "Ixcán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ixcán" },
                    { "1421", 14, "Pachalum", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pachalum" },
                    { "1501", 15, "Salamá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salamá" },
                    { "1502", 15, "San Miguel Chicaj", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Chicaj" },
                    { "1503", 15, "Rabinal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Rabinal" },
                    { "1504", 15, "Cubulco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cubulco" },
                    { "1505", 15, "Granados", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Granados" },
                    { "1506", 15, "El Chol", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Chol" },
                    { "1507", 15, "San Jerónimo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Jerónimo" },
                    { "1508", 15, "Purulhá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Purulhá" },
                    { "1601", 16, "Cobán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cobán" },
                    { "1602", 16, "Santa Cruz Verapaz", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz Verapaz" },
                    { "1603", 16, "San Cristóbal Verapaz", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Cristóbal Verapaz" },
                    { "1604", 16, "Tactic", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tactic" },
                    { "1605", 16, "Tamahú", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tamahú" },
                    { "1606", 16, "Tucurú", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tucurú" },
                    { "1607", 16, "Panzós", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Panzós" },
                    { "1608", 16, "Senahú", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Senahú" },
                    { "1609", 16, "San Pedro Carchá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Carchá" },
                    { "1610", 16, "San Juan Chamelco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Chamelco" },
                    { "1611", 16, "San Agustín Lanquín", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Agustín Lanquín" },
                    { "1612", 16, "Santa María Cahabón", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María Cahabón" },
                    { "1613", 16, "Chisec", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chisec" },
                    { "1614", 16, "Chahal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chahal" },
                    { "1615", 16, "Fray Bartolomé de Las Casas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Fray Bartolomé de Las Casas" },
                    { "1616", 16, "Santa Catarina La Tinta", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina La Tinta" },
                    { "1617", 16, "Raxruhá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Raxruhá" },
                    { "1701", 17, "Flores", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Flores" },
                    { "1702", 17, "San José", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José" },
                    { "1703", 17, "San Benito", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Benito" },
                    { "1704", 17, "San Andrés", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés" },
                    { "1705", 17, "La Libertad", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Libertad" },
                    { "1706", 17, "San Francisco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Francisco" },
                    { "1707", 17, "Santa Ana", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Ana" },
                    { "1708", 17, "Dolores", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Dolores" },
                    { "1709", 17, "San Luis", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Luis" },
                    { "1710", 17, "Sayaxché", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sayaxché" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "1711", 17, "Melchor de Mencos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Melchor de Mencos" },
                    { "1712", 17, "Poptún", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Poptún" },
                    { "1713", 17, "Las Cruces", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Las Cruces" },
                    { "1714", 17, "El Chal", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Chal" },
                    { "1801", 18, "Puerto Barrios", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Puerto Barrios" },
                    { "1802", 18, "Livingston", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Livingston" },
                    { "1803", 18, "El Estor", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Estor" },
                    { "1804", 18, "Morales", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Morales" },
                    { "1805", 18, "Los Amates", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Los Amates" },
                    { "1901", 19, "Zacapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zacapa" },
                    { "1902", 19, "Estanzuela", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Estanzuela" },
                    { "1903", 19, "Río Hondo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Río Hondo" },
                    { "1904", 19, "Gualán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Gualán" },
                    { "1905", 19, "Teculután", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Teculután" },
                    { "1906", 19, "Usumatlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Usumatlán" },
                    { "1907", 19, "Caba±as", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Caba±as" },
                    { "1908", 19, "San Diego", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Diego" },
                    { "1909", 19, "La Unión", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Unión" },
                    { "1910", 19, "Huité", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Huité" },
                    { "1911", 19, "San Jorge", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Jorge" },
                    { "2001", 20, "Chiquimula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chiquimula" },
                    { "2002", 20, "San José La Arada", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José La Arada" },
                    { "2003", 20, "San Juan Ermita", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Ermita" },
                    { "2004", 20, "Jocotán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jocotán" },
                    { "2005", 20, "Camotán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Camotán" },
                    { "2006", 20, "Olopa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Olopa" },
                    { "2007", 20, "Esquipulas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Esquipulas" },
                    { "2008", 20, "Concepción las Minas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Concepción las Minas" },
                    { "2009", 20, "Quezaltepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quezaltepeque" },
                    { "201", 2, "Guastatoya", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guastatoya" },
                    { "2010", 20, "San Jacinto", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Jacinto" },
                    { "2011", 20, "Ipala", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ipala" },
                    { "202", 2, "Morazán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Morazán" },
                    { "203", 2, "San Agustín Acasaguastlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Agustín Acasaguastlán" },
                    { "204", 2, "San Cristóbal Acasaguastlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Cristóbal Acasaguastlán" },
                    { "205", 2, "El Jícaro", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Jícaro" },
                    { "206", 2, "Sansare", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sansare" },
                    { "207", 2, "Sanarate", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sanarate" },
                    { "208", 2, "San Antonio la Paz", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio la Paz" },
                    { "2101", 21, "Jalapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jalapa" },
                    { "2102", 21, "San Pedro Pinula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Pinula" },
                    { "2103", 21, "San Luis Jilotepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Luis Jilotepeque" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "2104", 21, "San Manuel Chaparrón", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Manuel Chaparrón" },
                    { "2105", 21, "San Carlos Alzatate", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Carlos Alzatate" },
                    { "2106", 21, "Monjas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Monjas" },
                    { "2107", 21, "Mataquescuintla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Mataquescuintla" },
                    { "2201", 22, "Jutiapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jutiapa" },
                    { "2202", 22, "El Progreso", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Progreso" },
                    { "2203", 22, "Santa Catarina Mita", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina Mita" },
                    { "2204", 22, "Agua Blanca", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Agua Blanca" },
                    { "2205", 22, "Asunción Mita", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Asunción Mita" },
                    { "2206", 22, "Yupiltepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Yupiltepeque" },
                    { "2207", 22, "Atescatempa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Atescatempa" },
                    { "2208", 22, "Jerez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jerez" },
                    { "2209", 22, "El Adelanto", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Adelanto" },
                    { "2210", 22, "Zapotitlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zapotitlán" },
                    { "2211", 22, "Comapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Comapa" },
                    { "2212", 22, "Jalpatagua", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jalpatagua" },
                    { "2213", 22, "Conguaco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Conguaco" },
                    { "2214", 22, "Moyuta", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Moyuta" },
                    { "2215", 22, "Pasaco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pasaco" },
                    { "2216", 22, "San José Acatempa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José Acatempa" },
                    { "2217", 22, "Quesada", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quesada" },
                    { "301", 3, "Antigua Guatemala", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Antigua Guatemala" },
                    { "302", 3, "Jocotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Jocotenango" },
                    { "303", 3, "Pastores", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pastores" },
                    { "304", 3, "Sumpango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sumpango" },
                    { "305", 3, "Santo Domingo Xenacoj", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santo Domingo Xenacoj" },
                    { "306", 3, "Santiago Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santiago Sacatepéquez" },
                    { "307", 3, "San Bartolomé Milpas Altas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Bartolomé Milpas Altas" },
                    { "308", 3, "San Lucas Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Lucas Sacatepéquez" },
                    { "309", 3, "Santa Lucía Milpas Altas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Lucía Milpas Altas" },
                    { "310", 3, "Magdalena Milpas Altas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Magdalena Milpas Altas" },
                    { "311", 3, "Santa María de Jesús", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María de Jesús" },
                    { "312", 3, "Ciudad Vieja", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ciudad Vieja" },
                    { "313", 3, "San Miguel Due±as", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Due±as" },
                    { "314", 3, "San Juan Alotenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Alotenango" },
                    { "315", 3, "San Antonio Aguas Calientes", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Aguas Calientes" },
                    { "316", 3, "Santa Catarina Barahona", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina Barahona" },
                    { "401", 4, "Chimaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chimaltenango" },
                    { "402", 4, "San José  Poaquil", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José  Poaquil" },
                    { "403", 4, "San Martín Jilotepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Martín Jilotepeque" },
                    { "404", 4, "Comalapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Comalapa" },
                    { "405", 4, "Santa Apolonia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Apolonia" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "406", 4, "Tecpán Guatemala", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tecpán Guatemala" },
                    { "407", 4, "Patzún", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Patzún" },
                    { "408", 4, "San Miguel Pochuta", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Pochuta" },
                    { "409", 4, "Patzicía", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Patzicía" },
                    { "410", 4, "Santa Cruz Balanyá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz Balanyá" },
                    { "411", 4, "Acatenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Acatenango" },
                    { "412", 4, "San Pedro Yepocapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro Yepocapa" },
                    { "413", 4, "San Andrés Itzapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés Itzapa" },
                    { "414", 4, "Parramos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Parramos" },
                    { "415", 4, "Zaragoza", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zaragoza" },
                    { "416", 4, "El Tejar", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Tejar" },
                    { "501", 5, "Escuintla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Escuintla" },
                    { "502", 5, "Santa Lucía Cotzumalguapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Lucía Cotzumalguapa" },
                    { "503", 5, "La Democracia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Democracia" },
                    { "504", 5, "Siquinalá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Siquinalá" },
                    { "505", 5, "Masagua", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Masagua" },
                    { "506", 5, "Tiquisate", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Tiquisate" },
                    { "507", 5, "La Gomera", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Gomera" },
                    { "508", 5, "Guanagazapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guanagazapa" },
                    { "509", 5, "San José", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José" },
                    { "510", 5, "Iztapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Iztapa" },
                    { "511", 5, "Palín", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Palín" },
                    { "512", 5, "San Vicente Pacaya", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Vicente Pacaya" },
                    { "513", 5, "Nueva Concepción", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nueva Concepción" },
                    { "514", 5, "Sipacate", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sipacate" },
                    { "601", 6, "Cuilapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cuilapa" },
                    { "602", 6, "Barberena", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Barberena" },
                    { "603", 6, "Santa Rosa de Lima", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Rosa de Lima" },
                    { "604", 6, "Casillas", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Casillas" },
                    { "605", 6, "San Rafael Las Flores", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Rafael Las Flores" },
                    { "606", 6, "Oratorio", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Oratorio" },
                    { "607", 6, "San Juan Tecuaco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Tecuaco" },
                    { "608", 6, "Chiquimulilla", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Chiquimulilla" },
                    { "609", 6, "Taxisco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Taxisco" },
                    { "610", 6, "Santa María Ixhuatán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María Ixhuatán" },
                    { "611", 6, "Guazacapán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Guazacapán" },
                    { "612", 6, "Santa Cruz Naranjo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz Naranjo" },
                    { "613", 6, "Pueblo Nuevo Vi±as", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Pueblo Nuevo Vi±as" },
                    { "614", 6, "Nueva Santa Rosa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nueva Santa Rosa" },
                    { "701", 7, "Sololá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sololá" },
                    { "702", 7, "San José Chacayá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San José Chacayá" },
                    { "703", 7, "Santa María Visitación", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María Visitación" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "704", 7, "Santa Lucía Utatlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Lucía Utatlán" },
                    { "705", 7, "Nahualá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nahualá" },
                    { "706", 7, "Santa Catarina Ixtahuacán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina Ixtahuacán" },
                    { "707", 7, "Santa Clara La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Clara La Laguna" },
                    { "708", 7, "Concepción", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Concepción" },
                    { "709", 7, "San Andrés Semetabaj", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés Semetabaj" },
                    { "710", 7, "Panajachel", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Panajachel" },
                    { "711", 7, "Santa Catarina Palopó", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Catarina Palopó" },
                    { "712", 7, "San Antonio Palopó", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Antonio Palopó" },
                    { "713", 7, "San Lucas Tolimán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Lucas Tolimán" },
                    { "714", 7, "Santa Cruz La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Cruz La Laguna" },
                    { "715", 7, "San Pablo La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pablo La Laguna" },
                    { "716", 7, "San Marcos La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Marcos La Laguna" },
                    { "717", 7, "San Juan La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan La Laguna" },
                    { "718", 7, "San Pedro La Laguna", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Pedro La Laguna" },
                    { "719", 7, "Santiago Atitlán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santiago Atitlán" },
                    { "801", 8, "Totonicapán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Totonicapán" },
                    { "802", 8, "San Cristóbal Totonicapán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Cristóbal Totonicapán" },
                    { "803", 8, "San Francisco El Alto", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Francisco El Alto" },
                    { "804", 8, "San Andrés Xecul", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Andrés Xecul" },
                    { "805", 8, "Momostenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Momostenango" },
                    { "806", 8, "Santa María Chiquimula", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa María Chiquimula" },
                    { "807", 8, "Santa Lucía La Reforma", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Santa Lucía La Reforma" },
                    { "808", 8, "San Bartolo Aguas Calientes", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Bartolo Aguas Calientes" },
                    { "901", 9, "Quetzaltenango", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Quetzaltenango" },
                    { "902", 9, "Salcajá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Salcajá" },
                    { "903", 9, "San Juan Olintepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Olintepeque" },
                    { "904", 9, "San Carlos Sija", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Carlos Sija" },
                    { "905", 9, "Sibilia", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Sibilia" },
                    { "906", 9, "Cabricán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cabricán" },
                    { "907", 9, "Cajolá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cajolá" },
                    { "908", 9, "San Miguel Siguilá", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Miguel Siguilá" },
                    { "909", 9, "San Juan Ostuncalco", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Juan Ostuncalco" },
                    { "910", 9, "San Mateo", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Mateo" },
                    { "911", 9, "Concepción Chiquirichapa", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Concepción Chiquirichapa" },
                    { "912", 9, "San Martín Sacatepéquez", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Martín Sacatepéquez" },
                    { "913", 9, "Almolonga", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Almolonga" },
                    { "914", 9, "Cantel", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Cantel" },
                    { "915", 9, "Huitán", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Huitán" },
                    { "916", 9, "Zunil", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Zunil" },
                    { "917", 9, "Colomba Costa Cuca", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Colomba Costa Cuca" },
                    { "918", 9, "San Francisco La Unión", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "San Francisco La Unión" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "DepartamentoId", "Descripcion", "FechaCreacion", "FechaModificacion", "Habilitado", "Nombre" },
                values: new object[,]
                {
                    { "919", 9, "El Palmar", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "El Palmar" },
                    { "920", 9, "Coatepeque", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Coatepeque" },
                    { "921", 9, "Génova", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Génova" },
                    { "922", 9, "Flores Costa Cuca", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Flores Costa Cuca" },
                    { "923", 9, "La Esperanza", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "La Esperanza" },
                    { "924", 9, "Palestina de Los Altos", new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Palestina de Los Altos" }
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Direccion", "Email", "EntidadId", "FechaCreacion", "FechaModificacion", "Habilitado", "Nit", "Nombre", "Telefono" },
                values: new object[] { 1, "Zona 15", "admin@sinfin.com", 1, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "12345678", "SinFin S.A.", "123456" });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "ApellidoCasada", "Colonia", "Comentarios", "DepartamentoId", "Direccion", "DireccionLaboral", "Email", "EntidadId", "EstadoCivilId", "FechaCreacion", "FechaModificacion", "FechaNacimiento", "GeneroId", "Habilitado", "MunicipioId", "NIT", "NumeroCelular", "NumeroDocumento", "NumeroTelefono", "NumeroTelefonoLaboral", "OcupacionId", "PaisNacimientoId", "PrimerApellido", "PrimerNombre", "SegundoApellido", "SegundoNombre", "TipoViviendaId" },
                values: new object[] { 1, null, null, null, null, null, null, "user@example.com", 2, 1, new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, null, "123412340", null, "123412340", null, null, null, null, "Example", "User", null, null, null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonaId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c44ab09d-9b73-4ea9-9191-064c903ac294", 0, "901ccf30-20ec-4565-abfe-8db39ab1c597", "user@example.com", false, true, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDTdljWg8MONBgC2PsrNPXLd6cOkQSwl8lAG69T1gHxFKSf75bihF/rOzt7P/hGu2A==", 1, null, false, "NWJLHEJLBLE32NELL55BUTYT5VUGH4BT", false, "user@example.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c44ab09d-9b73-4ea9-9191-064c903ac294");

            migrationBuilder.DeleteData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bancos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cajas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DestinoPrestamos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Empresas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EstadoPrestamos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EstadosOrigen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadosOrigen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadosOrigen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EstadosOrigen",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EstadosOrigen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "FormaPagos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1001");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1002");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1003");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1004");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1005");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1006");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1007");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1008");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1009");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "101");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1010");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1011");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1012");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1013");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1014");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1015");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1016");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1017");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1018");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1019");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "102");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1020");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1021");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "103");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "104");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "105");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "106");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "107");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "108");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "109");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "110");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1101");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1102");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1103");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1104");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1105");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1106");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1107");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1108");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1109");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "111");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "112");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "113");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "114");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "115");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "116");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "117");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1201");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1202");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1203");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1204");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1205");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1206");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1207");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1208");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1209");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1210");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1211");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1212");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1213");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1214");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1215");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1216");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1217");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1218");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1219");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1220");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1221");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1222");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1223");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1224");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1225");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1226");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1227");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1228");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1229");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1230");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1301");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1302");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1303");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1304");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1305");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1306");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1307");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1308");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1309");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1310");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1311");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1312");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1313");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1314");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1315");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1316");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1317");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1318");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1319");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1320");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1321");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1322");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1323");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1324");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1325");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1326");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1327");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1328");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1329");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1330");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1331");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1332");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1333");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1401");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1402");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1403");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1404");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1405");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1406");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1407");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1408");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1409");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1410");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1411");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1412");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1413");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1414");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1415");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1416");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1417");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1418");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1419");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1420");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1421");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1501");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1502");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1503");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1504");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1505");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1506");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1507");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1508");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1601");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1602");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1603");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1604");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1605");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1606");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1607");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1608");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1609");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1610");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1611");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1612");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1613");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1614");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1615");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1616");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1617");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1701");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1702");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1703");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1704");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1705");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1706");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1707");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1708");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1709");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1710");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1711");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1712");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1713");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1714");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1801");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1802");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1803");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1804");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1805");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1901");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1902");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1903");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1904");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1905");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1906");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1907");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1908");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1909");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1910");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "1911");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2001");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2002");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2003");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2004");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2005");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2006");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2007");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2008");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2009");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "201");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2010");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2011");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "202");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "203");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "204");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "205");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "206");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "207");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "208");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2101");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2102");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2103");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2104");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2105");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2106");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2107");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2201");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2202");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2203");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2204");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2205");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2206");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2207");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2208");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2209");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2210");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2211");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2212");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2213");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2214");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2215");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2216");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "2217");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "301");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "302");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "303");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "304");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "305");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "306");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "307");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "308");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "309");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "310");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "311");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "312");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "313");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "314");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "315");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "316");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "401");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "402");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "403");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "404");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "405");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "406");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "407");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "408");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "409");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "410");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "411");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "412");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "413");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "414");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "415");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "416");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "501");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "502");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "503");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "504");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "505");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "506");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "507");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "508");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "509");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "510");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "511");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "512");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "513");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "514");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "601");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "602");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "603");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "604");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "605");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "606");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "607");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "608");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "609");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "610");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "611");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "612");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "613");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "614");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "701");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "702");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "703");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "704");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "705");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "706");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "707");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "708");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "709");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "710");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "711");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "712");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "713");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "714");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "715");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "716");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "717");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "718");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "719");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "801");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "802");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "803");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "804");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "805");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "806");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "807");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "808");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "901");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "902");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "903");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "904");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "905");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "906");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "907");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "908");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "909");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "910");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "911");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "912");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "913");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "914");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "915");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "916");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "917");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "918");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "919");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "920");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "921");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "922");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "923");

            migrationBuilder.DeleteData(
                table: "Municipios",
                keyColumn: "Id",
                keyValue: "924");

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ocupaciones",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ABW");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AFG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AGO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AIA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ALB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AND");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ANT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ARE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ARG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ARM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ASM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ATA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ATF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ATG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AUS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AUT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "AZE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BDI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BEL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BEN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BFA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BGD");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BGR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BHR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BHS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BIH");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BLR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BLZ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BMU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BOL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BRA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BRB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BRN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BTN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BVT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "BWA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CAF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CAN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CCK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CHE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CHL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CHN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CIV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CMR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "COG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "COK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "COL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "COM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CPV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CRI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CUB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CXR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CYM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CYP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "CZE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DEU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DJI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DMA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DNK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DOM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "DZA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ECU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "EGY");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ERI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ESH");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ESP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "EST");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ETH");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "FIN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "FJI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "FLK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "FRA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "FRO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GAB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GBR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GEO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GHA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GIB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GIN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GLP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GMB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GNB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GNQ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GRC");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GRD");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GRL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GTM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GUF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GUM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "GUY");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "HKG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "HND");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "HRV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "HTI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "HUN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IDN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IND");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IOT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IRL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IRN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "IRQ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ISL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ISR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ITA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "JAM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "JOR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "JPN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KAZ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KEN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KGZ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KHM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KIR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KNA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KOR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "KWT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LAO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LBN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LBR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LBY");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LCA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LIE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LKA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LSO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LTU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LUX");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "LVA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MAC");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MAR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MCO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MDA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MDG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MDV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MEX");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MHL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MKD");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MLI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MLT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MMR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MNG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MNP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MOZ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MRT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MSR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MTQ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MUS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MWI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MYS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "MYT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NAM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NCL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NER");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NFK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NGA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NIC");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NIU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NLD");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NOR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NPL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NRU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "NZL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "OMN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PAK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PAN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PCN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PER");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PHL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PLW");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PNG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "POL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PRI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PRK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PRT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PRY");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PSE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "PYF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "QAT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "REU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "RKS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ROM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "RUS");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "RWA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SAU");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SCT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SDN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SEN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SGP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SHN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SLB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SLE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SLV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SMR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SOM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SPM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SRB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "STP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SUR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SVK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SVN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SWE");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SWZ");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SYC");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "SYR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TCA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TCD");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TGO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "THA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TJK");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TKL");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TKM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TMP");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TON");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TTO");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TUN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TUR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TUV");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TWN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "TZA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "UGA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "UKR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "URY");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "USA");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "UZB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VAT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VCT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VEN");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VGB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VI");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VIR");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VNM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "VUT");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "WLF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "WSM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "YEM");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "YUG");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ZAF");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ZMB");

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: "ZWE");

            migrationBuilder.DeleteData(
                table: "TipoBitacoras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoBitacoras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TipoPrestamos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TipoRelacion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoRelacion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoRelacion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoRelacion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TipoTransaccion",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TiposVivienda",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposVivienda",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TiposVivienda",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Departamentos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadoCivil",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoEntidad",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoEntidad",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
