using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedFunctionFoCalculateBaseFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlanPago_PlanPago_PlanPagoId",
                table: "DetallePlanPago");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPago_AspNetUsers_AppUserId",
                table: "PlanPago");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPago_EstadoPlan_EstadoPlanId",
                table: "PlanPago");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPago_Prestamo_PrestamoId",
                table: "PlanPago");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_AspNetUsers_AppUserId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_DestinoPrestamo_DestinoPrestamoId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_EstadoPrestamo_EstadoPrestamoId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Personas_PersonaId",
                table: "Prestamo");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_TipoPrestamo_TipoPrestamoId",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPrestamo",
                table: "TipoPrestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prestamo",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanPago",
                table: "PlanPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPrestamo",
                table: "EstadoPrestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPlan",
                table: "EstadoPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlanPagoTemporal",
                table: "DetallePlanPagoTemporal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlanPago",
                table: "DetallePlanPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinoPrestamo",
                table: "DestinoPrestamo");

            migrationBuilder.RenameTable(
                name: "TipoPrestamo",
                newName: "TipoPrestamos");

            migrationBuilder.RenameTable(
                name: "Prestamo",
                newName: "Prestamos");

            migrationBuilder.RenameTable(
                name: "PlanPago",
                newName: "PlanPagos");

            migrationBuilder.RenameTable(
                name: "EstadoPrestamo",
                newName: "EstadoPrestamos");

            migrationBuilder.RenameTable(
                name: "EstadoPlan",
                newName: "EstadoPlanes");

            migrationBuilder.RenameTable(
                name: "DetallePlanPagoTemporal",
                newName: "DetallePlanPagoTemporales");

            migrationBuilder.RenameTable(
                name: "DetallePlanPago",
                newName: "DetallePlanPagos");

            migrationBuilder.RenameTable(
                name: "DestinoPrestamo",
                newName: "DestinoPrestamos");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_TipoPrestamoId",
                table: "Prestamos",
                newName: "IX_Prestamos_TipoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_PersonaId",
                table: "Prestamos",
                newName: "IX_Prestamos_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_EstadoPrestamoId",
                table: "Prestamos",
                newName: "IX_Prestamos_EstadoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_DestinoPrestamoId",
                table: "Prestamos",
                newName: "IX_Prestamos_DestinoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamo_AppUserId",
                table: "Prestamos",
                newName: "IX_Prestamos_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPago_PrestamoId",
                table: "PlanPagos",
                newName: "IX_PlanPagos_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPago_EstadoPlanId",
                table: "PlanPagos",
                newName: "IX_PlanPagos_EstadoPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPago_AppUserId",
                table: "PlanPagos",
                newName: "IX_PlanPagos_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlanPago_PlanPagoId",
                table: "DetallePlanPagos",
                newName: "IX_DetallePlanPagos_PlanPagoId");

            migrationBuilder.AlterColumn<string>(
                name: "PlanPagoId",
                table: "DetallePlanPagoTemporales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPrestamos",
                table: "TipoPrestamos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prestamos",
                table: "Prestamos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanPagos",
                table: "PlanPagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPrestamos",
                table: "EstadoPrestamos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPlanes",
                table: "EstadoPlanes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlanPagoTemporales",
                table: "DetallePlanPagoTemporales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlanPagos",
                table: "DetallePlanPagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinoPrestamos",
                table: "DestinoPrestamos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlanPagos_PlanPagos_PlanPagoId",
                table: "DetallePlanPagos",
                column: "PlanPagoId",
                principalTable: "PlanPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPagos_AspNetUsers_AppUserId",
                table: "PlanPagos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPagos_EstadoPlanes_EstadoPlanId",
                table: "PlanPagos",
                column: "EstadoPlanId",
                principalTable: "EstadoPlanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPagos_Prestamos_PrestamoId",
                table: "PlanPagos",
                column: "PrestamoId",
                principalTable: "Prestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_AspNetUsers_AppUserId",
                table: "Prestamos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos",
                column: "DestinoPrestamoId",
                principalTable: "DestinoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Personas_PersonaId",
                table: "Prestamos",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos",
                column: "TipoPrestamoId",
                principalTable: "TipoPrestamos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql(
                @"SET ANSI_NULLS ON
                    GO
                    SET QUOTED_IDENTIFIER ON
                    GO
                    Create FUNCTION [dbo].[CalculateFee] 
                    (	
	                    -- Add the parameters for the function here
	                    @capital decimal (18,6),
	                    @interesAnual decimal (18,6),
	                    @payments int	
                    )  
                    RETURNS decimal (18,6)
                    AS  
                    BEGIN  
	                    DECLARE
		                    @interesMensual decimal (18,6),		
		                    @subtotal decimal (18,6)
	
	                    set @interesAnual *= 0.01
	                    set @interesMensual = @interesAnual/12
	

	                    SET @subtotal = (@capital * @interesMensual) / (1 - Power((1 + @interesMensual), -@payments))

	                    RETURN @subtotal

                    END
                  GO
                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallePlanPagos_PlanPagos_PlanPagoId",
                table: "DetallePlanPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPagos_AspNetUsers_AppUserId",
                table: "PlanPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPagos_EstadoPlanes_EstadoPlanId",
                table: "PlanPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanPagos_Prestamos_PrestamoId",
                table: "PlanPagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_AspNetUsers_AppUserId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_DestinoPrestamos_DestinoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_EstadoPrestamos_EstadoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Personas_PersonaId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_TipoPrestamos_TipoPrestamoId",
                table: "Prestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoPrestamos",
                table: "TipoPrestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prestamos",
                table: "Prestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanPagos",
                table: "PlanPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPrestamos",
                table: "EstadoPrestamos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstadoPlanes",
                table: "EstadoPlanes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlanPagoTemporales",
                table: "DetallePlanPagoTemporales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallePlanPagos",
                table: "DetallePlanPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DestinoPrestamos",
                table: "DestinoPrestamos");

            migrationBuilder.RenameTable(
                name: "TipoPrestamos",
                newName: "TipoPrestamo");

            migrationBuilder.RenameTable(
                name: "Prestamos",
                newName: "Prestamo");

            migrationBuilder.RenameTable(
                name: "PlanPagos",
                newName: "PlanPago");

            migrationBuilder.RenameTable(
                name: "EstadoPrestamos",
                newName: "EstadoPrestamo");

            migrationBuilder.RenameTable(
                name: "EstadoPlanes",
                newName: "EstadoPlan");

            migrationBuilder.RenameTable(
                name: "DetallePlanPagoTemporales",
                newName: "DetallePlanPagoTemporal");

            migrationBuilder.RenameTable(
                name: "DetallePlanPagos",
                newName: "DetallePlanPago");

            migrationBuilder.RenameTable(
                name: "DestinoPrestamos",
                newName: "DestinoPrestamo");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_TipoPrestamoId",
                table: "Prestamo",
                newName: "IX_Prestamo_TipoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_PersonaId",
                table: "Prestamo",
                newName: "IX_Prestamo_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_EstadoPrestamoId",
                table: "Prestamo",
                newName: "IX_Prestamo_EstadoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_DestinoPrestamoId",
                table: "Prestamo",
                newName: "IX_Prestamo_DestinoPrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prestamos_AppUserId",
                table: "Prestamo",
                newName: "IX_Prestamo_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPagos_PrestamoId",
                table: "PlanPago",
                newName: "IX_PlanPago_PrestamoId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPagos_EstadoPlanId",
                table: "PlanPago",
                newName: "IX_PlanPago_EstadoPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_PlanPagos_AppUserId",
                table: "PlanPago",
                newName: "IX_PlanPago_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DetallePlanPagos_PlanPagoId",
                table: "DetallePlanPago",
                newName: "IX_DetallePlanPago_PlanPagoId");

            migrationBuilder.AlterColumn<int>(
                name: "PlanPagoId",
                table: "DetallePlanPagoTemporal",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoPrestamo",
                table: "TipoPrestamo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prestamo",
                table: "Prestamo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanPago",
                table: "PlanPago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPrestamo",
                table: "EstadoPrestamo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstadoPlan",
                table: "EstadoPlan",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlanPagoTemporal",
                table: "DetallePlanPagoTemporal",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallePlanPago",
                table: "DetallePlanPago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DestinoPrestamo",
                table: "DestinoPrestamo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallePlanPago_PlanPago_PlanPagoId",
                table: "DetallePlanPago",
                column: "PlanPagoId",
                principalTable: "PlanPago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPago_AspNetUsers_AppUserId",
                table: "PlanPago",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPago_EstadoPlan_EstadoPlanId",
                table: "PlanPago",
                column: "EstadoPlanId",
                principalTable: "EstadoPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanPago_Prestamo_PrestamoId",
                table: "PlanPago",
                column: "PrestamoId",
                principalTable: "Prestamo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_AspNetUsers_AppUserId",
                table: "Prestamo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_DestinoPrestamo_DestinoPrestamoId",
                table: "Prestamo",
                column: "DestinoPrestamoId",
                principalTable: "DestinoPrestamo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_EstadoPrestamo_EstadoPrestamoId",
                table: "Prestamo",
                column: "EstadoPrestamoId",
                principalTable: "EstadoPrestamo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Personas_PersonaId",
                table: "Prestamo",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_TipoPrestamo_TipoPrestamoId",
                table: "Prestamo",
                column: "TipoPrestamoId",
                principalTable: "TipoPrestamo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.Sql("DROP FUNCTION [dbo].[CalculateFee]");
        }
    }
}
