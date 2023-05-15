using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Stored_Procedures : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            builder.Sql(@"-- =============================================
-- Author:		Sender Flores
-- Create date: 17/03/2023
-- Description:	Calcula Saldo de Prestamos en Lista de Prestamos
-- =============================================

create or alter function FxSaldoPrestamoListado(	@prestamoId int ) RETURNS decimal (18,2) AS
BEGIN
	-- Declare the return variable here
	DECLARE @saldoActual decimal(18,2),
			@cargos decimal(18,2),
			@abonos decimal(18,2),
			@ajustes decimal(18,2),
			@moraActual decimal (18,2),
			@ivaMoraActual decimal (18,2),
			@regularizacion decimal (18,2)

	-- Suma Cargos
	Select
		@prestamoId = PrestamoId,
		@cargos = sum(isnull(Cargo, 0.00))
	From
		EstadoCuentas
	Where
		PrestamoId = @prestamoId
	Group by
		PrestamoId

	-- Suma Abonos
	Select
		@prestamoId = PrestamoId,
		@abonos = sum(isnull(Abono, 0.00))
	From
		EstadoCuentas
	Where
		PrestamoId = @prestamoId
	Group By
		PrestamoId

	--Suma Regularizaciones
	Select
		@prestamoId = PrestamoId,
		@regularizacion = sum(isnull(Abono, 0.00))
	From
		EstadoCuentas
	Where
		PrestamoId = @prestamoId
	and
		TipoTransaccionId = 28
	Group by
		PrestamoId

	--Suma Mora e IvaMora a la Fecha
	Select top 1
		@moraActual = CuotaMora,
		@ivaMoraActual = CuotaIvaMora
	From
		PlanPagos
	Where
		PrestamoId = @prestamoId
	and
		Aplicado = 0

	--Calcula Saldo Actual
	Set @saldoActual = @cargos + IsNull(@moraActual, 0) + IsNull(@ivaMoraActual,0) + IsNull(@regularizacion, 0) - @abonos

	--Print @PrestamoId
	--Print @cargos
	--Print @abonos
	--Print @regularizacion
	--Print @saldoActual

	-- Return the result of the function
	RETURN IsNull(@saldoActual, 0)

END");

            builder.Sql(@"create or alter procedure ReporteContabilidad(@fechaInicio date, @fechaFin date)
As
Begin
Select
		pre.Id as CreditoId,
		IsNull(pre.ReferenciaMigracion, '') as Referencia,
		tipo.Nombre as TipoCredito,
		mdi.NIT,
		mdi.Nombre,
		ban.Nombre as Banco,
		IsNull(convert(date, rc.FechaPago), '') as FechaBoleta,
		IsNull(rc.NumeroDocumento, '') as NumeroDocumento,
		--MotivoTransaccion = 'PAGO DESDE CAJA',
		--pre.Plazo,
		--#CuotaPagada = pp.Id,
		convert(date, rc.FechaTransaccion) as FechaTransaccion,
		mdig.Nombre as Ejecutivo,
		TotalTransaccion = rc.MontoPago,
		Capital = rc.MontoCapital,
		Intereses = rc.MontoInteres,
		IvaIntereses = rc.MontoIvaIntereses,
		Mora = rc.MontoMora,
		IvaMora = rc.MontoIvaMora,
		ArchivoBatch = Case
							When rc.BatchDate < '2020-01-01' Then 'No' Else 'Si'
					   End
	from
		Prestamos as pre
	Inner Join
		v_mdi_general_full as mdi
	on
		mdi.EntidadId = pre.EntidadPrestamoId
	Inner Join
		v_mdi_general_full as mdig
	on
		mdig.EntidadId = pre.GestorPrestamoId
	Inner Join
		TipoPrestamos as tipo
	on
		tipo.Id = pre.TipoPrestamoId
	Inner Join
		RegistroCajas as rc
	On
		rc.PrestamoId = pre.Id
	Inner Join
		Bancos as ban
	On
		ban.Id = rc.BancoId
	where
		rc.FechaTransaccion Between @fechaInicio and @fechaFin
	and
		rc.MontoPago > 0
	order by rc.FechaTransaccion

End");

            builder.Sql(@"create or alter procedure ReporteGeneralCreditos
As
Begin
Select
		pre.Id as IdPrestamo,
		pre.ReferenciaMigracion as Referencia,
		mdi.Nombre,
		mdig.Nombre as Gestor,
		pre.MontoOtorgado,
		pre.TasaInteres,
		pre.Plazo,
		(select DeudaTotal from SaldosMigracion(pre.Id)) as DeudaTotal,
		pre.InteresProyectado,
		pre.IvaProyectado,
		pre.DiasMora,
		(select SaldoCapital from SaldosMigracion(pre.Id)) as SaldoCapital,
		(select SaldoInteres from SaldosMigracion(pre.Id)) as SaldoIntereses,
		(select SaldoIvaInteres from SaldosMigracion(pre.Id)) as SaldoIvaIntereses,
		(select SaldoMora from SaldosMigracion(pre.Id)) as SaldoMora,
		(select SaldoIvaMora from SaldosMigracion(pre.Id)) as SaldoIvaMora,
		estados.Nombre as Estado

	from
		Prestamos as pre
	Inner Join
		v_mdi_general_full as mdi
	on
		mdi.EntidadId = pre.EntidadPrestamoId
    Inner Join
		v_mdi_general_full as mdig
	on
		mdig.EntidadId = pre.GestorPrestamoId
	Inner Join
		EstadoPrestamos as estados
	on
		estados.Id = pre.EstadoPrestamoId
	where
		pre.EstadoPrestamoId = 1
	order by pre.Id

End");

            builder.Sql(@"create or alter function [dbo].[SaldosMigracion](@pid int)
returns @r table (
							Id int,
							ReferenciaMigracion nvarchar(125) null,
							DeudaTotal decimal(18, 2) default 0 null,
							CapitalPrestado decimal(18, 2) default 0 null,
							SaldoCapital decimal(18, 2) default 0 null,
							InteresProyectado decimal(18, 2) default 0 null,
							IvaProyectado decimal(18, 2) default 0 null,
							GastosProyectados decimal(18, 2) default 0 null,
							SaldoInteres decimal(18, 2) default 0 null,
							SaldoIvaInteres decimal(18, 2) default 0 null,
							Mora decimal(18, 2) default 0 null,
							SaldoMora decimal(18, 2) default 0 null,
							IvaMora decimal(18, 2) default 0 null,
							SaldoIvaMora decimal(18, 2) default 0 null,
							Gastos decimal(18, 2) default 0 null,
							SaldoGastos decimal(18, 2) default 0 null,
							IvaGastos decimal(18, 2) default 0 null,
							SaldoIvaGastos decimal(18, 2) default 0 null
						) as
begin

declare  @tipoTranAbono_20221031 varchar(100) =  'Nota de Débito (Ajuste por Liquidación)';
-- set @tipoTranAbono_20221031  = 'x';
declare @extras decimal(18, 2)
		, @cargomora decimal(18,2)
		, @cargoIvaMora decimal(18,2)
		, @mora  decimal(18, 2)
		, @ivaMora decimal(18, 2)
		, @gastos decimal(18, 2)
		, @ivagastos decimal(18, 2)
		, @capitalReversado decimal(18,2)
		, @interesesReversados decimal(18,2)
		, @ivaInteresesReversados decimal(18,2)

		, @tABO_C decimal(18, 2)
		, @tABO_I decimal(18, 2)
		, @tABO_IIVA decimal(18, 2)
		, @tABO_M decimal(18, 2)
		, @tABO_MIVA decimal(18, 2)
		, @tABO_G decimal(18, 2)
		, @tABO_GIVA decimal(18, 2)

		;
	/*
	if (1 = 0)
	begin
		select	Id, ReferenciaMigracion, MontoOtorgado,
				InteresProyectado, IvaProyectado, GastosProyectados, MontoTotalProyectado,
				Plazo, TasaInteres, TasaMora, TasaIva
		from Prestamos
		where Id = @pid;
	end; select * from estadoCuentas where id =1
	*/

	/** Cargo Mora **/
	select
		@pid = PrestamoId,
		@cargoMora = sum(isnull(Cargo, 0.00))
	from
		EstadoCuentas
	where
		PrestamoId = @pid
	and
		TipoTransaccionId in (4)
	Group By
		PrestamoId

	/** Cargo Iva Mora **/
	select
		@pid = PrestamoId,
		@cargoIvaMora = sum(isnull(Cargo, 0.00))
	from
		EstadoCuentas
	where
		PrestamoId = @pid
	and
		TipoTransaccionId in (5)
	Group By
		PrestamoId

	/** Capital Reversado **/
	select
		@pid = PrestamoId,
		@capitalReversado = sum(isnull(Cargo, 0.00))
	from
		EstadoCuentas
	where
		PrestamoId = @pid
	and
		TipoTransaccionId in (29)
	Group By
		PrestamoId

	/** Intereses Reversados **/
	select
		@pid = PrestamoId,
		@interesesReversados = sum(isnull(Cargo, 0.00))
	from
		EstadoCuentas
	where
		PrestamoId = @pid
	and
		TipoTransaccionId in (30)
	Group By
		PrestamoId

	/** Iva Intereses Reversados **/
	select
		@pid = PrestamoId,
		@ivaInteresesReversados = sum(isnull(Cargo, 0.00))
	from
		EstadoCuentas
	where
		PrestamoId = @pid
	and
		TipoTransaccionId in (31)
	Group By
		PrestamoId


	set @extras = (select SUM(CuotaMora + CuotaIvaMora + CuotaGastos + CuotaIvaGastos) from PlanPagos where PrestamoId = @pid);


	select
			@extras = SUM(CuotaMora + CuotaIvaMora + CuotaGastos + CuotaIvaGastos),
			@mora = sum(SaldoMora),
			@ivaMora = sum(SaldoIvaMora),
			@gastos = sum(CuotaGastos),
			@ivaGastos = sum(CuotaIvaGastos)
	from PlanPagos
	where PrestamoId = @pid;

	/*
	if ( 1 = 0)
	begin
		SELECT @cargoMora AS [ @cargoMora ]
		, @CargoIvaMora
		, @mora
		, @ivaMora
	end;
	*/
	-- Consulta de total de abonos por rubro
	if (1 = 1)
	begin
	-- select * from TipoTransaccion

		/*
		-- DARK PATCH 20221031 1/3 ::: Por la forma en que se registran las cosas en EstadoCuentas...
		-- => Se reemplazo el segmento en comentario por el siguiente

		set @tABO_C = (		select sum(a.MontoCapital)
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId
																and c.Nombre in ('Abono Migración', 'Abono Capital', @tipoTranAbono_20221031)
							where a.PrestamoId = @pid
						);
		*/

		-- [START] DARK PATCH 20221031 1/3 ----------------
		set	@tABO_C = (		select SUM(z.MontoCapital)
							from RegistroCajas z
								inner join (
												select distinct a.Id
												from RegistroCajas a
													inner join EstadoCuentas b on b.RegistroCajaId = a.Id
													inner join TipoTransaccion c on c.Id = b.TipoTransaccionId
																					and c.Nombre in ('Abono Migración', 'Abono Capital', @tipoTranAbono_20221031)
												where a.PrestamoId = @pid
											) y on y.Id = z.Id

						);
		-- [END] DARK PATCH 20221031 1/3 ----------------

/*
		-- DARK PATCH 20221031 2/3 ::: Por la forma en que se registran las cosas en EstadoCuentas...
		-- => Se reemplazo el segmento en comentario por el siguiente

		-- Dark patch (2/2) ::: 20221021 1312
		-- select * from TipoTransaccion where Id = 20
		-- select * from RegistroCajas where PrestamoId = 390
		set @tABO_I = (		select sum(		-- Dark patch (2/2) ::: 20221021 1312!!!
											case
												when c.Nombre = 'Abono de Ajuste de Intereses' then a.MontoPago
												else a.MontoInteres
											end
										)
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c
										on c.Id = b.TipoTransaccionId
											and c.Nombre in (
																'Abono Migración'
																, 'Abono Intereses'
																, 'Abono de Ajuste de Intereses'
																, @tipoTranAbono_20221031
															)
							where a.PrestamoId = @pid
						);
*/
			-- [START] DARK PATCH 20221031 2/3 ----------------
			set @tABO_I = isnull(
									(
									select sum(z.MontoInteres)
									from RegistroCajas z
										inner join (	select distinct a.Id
														from RegistroCajas a
																inner join EstadoCuentas b on b.RegistroCajaId = a.Id
																inner join TipoTransaccion c
																		on c.Id = b.TipoTransaccionId
																			and c.Nombre in (
																								'Abono Migración'
																								, 'Abono Intereses'
																								, 'Abono por Regularización'
																								-- , 'Abono de Ajuste de Intereses'
																								, @tipoTranAbono_20221031
																							)
															where a.PrestamoId = @pid
													) y on y.Id = z.Id

									)
									, 0);


			set @tABO_I += isnull(
									(
										select sum(z.MontoPago)
										from RegistroCajas z
											inner join (	select distinct a.Id
															from RegistroCajas a
																	inner join EstadoCuentas b on b.RegistroCajaId = a.Id
																	inner join TipoTransaccion c
																			on c.Id = b.TipoTransaccionId
																				and c.Nombre in (
																									-- 'Abono Migración'
																									-- , 'Abono Intereses'
																									'Abono de Ajuste de Intereses'
																									--  @tipoTranAbono_20221031
																								)
																where a.PrestamoId = @pid
														) y on y.Id = z.Id

									)
									, 0);


		-- [END] DARK PATCH 20221031 2/3 ----------------



		-- DARK PATCH 20221031 3/3 ::: Por la forma en que se registran las cosas en EstadoCuentas...
		-- => Se reemplazo el segmento en comentario por el siguiente
		/*
		-- Dark patch (1/2) ::: 20221021 1312
		-- select * from TipoTransaccion where Id = 17
		-- select * from RegistroCajas where PrestamoId = 390

		set @tABO_IIVA = (
							select sum(
											-- Dark patch (1/2) ::: 20221021 1312!!!
											case
												when c.Nombre = 'Abono de Ajuste de Iva de Intereses' then a.MontoPago
												else  a.MontoIvaIntereses
											end
											)
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c
										on c.Id = b.TipoTransaccionId
											and c.Nombre in (	'Abono Migración'
																, 'Abono Iva Intereses'
																, 'Abono de Ajuste de Iva de Intereses'
																, @tipoTranAbono_20221031
															)
							where a.PrestamoId = @pid
						);
						*/

		-- [START] DARK PATCH 20221031 3/3 ----------------
		set @tABO_IIVA = isnull(
									(
									select sum(z.MontoIvaIntereses)
									from RegistroCajas z
										inner join (	select distinct a.Id
														from RegistroCajas a
																inner join EstadoCuentas b on b.RegistroCajaId = a.Id
																inner join TipoTransaccion c
																		on c.Id = b.TipoTransaccionId
																			and c.Nombre in (	'Abono Migración'
																								, 'Abono Iva Intereses'
																								, @tipoTranAbono_20221031
																							)
															where a.PrestamoId = @pid
													) y on y.Id = z.Id

									)
									, 0);


			set @tABO_IIVA += isnull(
									(
										select sum(z.MontoPago)
										from RegistroCajas z
											inner join (	select distinct a.Id
															from RegistroCajas a
																	inner join EstadoCuentas b on b.RegistroCajaId = a.Id
																	inner join TipoTransaccion c
																			on c.Id = b.TipoTransaccionId
																				and c.Nombre in (
																									'Abono de Ajuste de Iva de Intereses'
																								)
																where a.PrestamoId = @pid
														) y on y.Id = z.Id

									)
									, 0);
		-- [END] DARK PATCH 20221031 3/3 ----------------


		set @tABO_M = (		select sum(a.MontoMora )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Mora', @tipoTranAbono_20221031)
							where a.PrestamoId = @pid
									and b.Concepto  = 'Abono Mora' -- 20230327 PCID
						);

		set @tABO_MIVA = (		select sum(a.MontoIvaMora )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Iva Mora', @tipoTranAbono_20221031)
							where a.PrestamoId = @pid
								and b.Concepto  = 'Abono IVA Mora' -- 20230327 PCID
						);

		set @tABO_G = (		select sum(a.MontoGastos )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Gastos', @tipoTranAbono_20221031)
							where a.PrestamoId = @pid
						);

		set @tABO_GIVA = (
							select sum(a.MontoIvaGastos )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Saldo Iva Gastos', @tipoTranAbono_20221031)
							where a.PrestamoId = @pid
						);

	end;

	insert into @r (	Id, ReferenciaMigracion, DeudaTotal, CapitalPrestado, SaldoCapital,
						InteresProyectado, IvaProyectado, GastosProyectados, SaldoInteres,
						SaldoIvaInteres, Mora, SaldoMora, IvaMora, SaldoIvaMora, Gastos,
						SaldoGastos, IvaGastos, SaldoIvaGastos
					)
		select  a.Id, a.ReferenciaMigracion,
				a.MontoTotalProyectado + @extras as DeudaTotal
				, a.MontoOtorgado as CapitalPrestado
				, a.MontoOtorgado - isnull(@tABO_C, 0) + isNull(@capitalReversado, 0) as SaldoCapital
				, a.InteresProyectado
				, a.IvaProyectado -- => IvaInteresProyectado
				, a.GastosProyectados

				, a.InteresProyectado - isnull(@tABO_I, 0) + isNull(@interesesReversados, 0) as SaldoInteres
				-- , @tABO_I as SaldoInteres
				, a.IvaProyectado - isnull(@tABO_IIVA, 0) + isNull(@ivaInteresesReversados, 0) as SaldoIvaInteres    -- => IvaInteresProyectado - @tABO_IIVA

				, @mora as Mora

				, @mora + IsNull(@cargoMora, 0) - isnull(@tABO_M, 0) as SaldoMora


				, @ivaMora as IvaMora
				, @ivaMora + IsNull(@cargoIvaMora, 0) - isnull(@tABO_MIVA, 0) as SaldoIvaMora
				, @gastos as Gastos
				, @gastos - isnull(@tABO_G, 0) as SaldoGastos
				, @ivaGastos as IvaGastos
				, @ivaGastos - isnull(@tABO_GIVA, 0) as SaldoIvaGastos


		from Prestamos a
		where a.Id = @pid;

	update @r set
				Id = isnull(Id, 0)
				, ReferenciaMigracion = isnull(ReferenciaMigracion, 0)
				, DeudaTotal = isnull(DeudaTotal, 0)
				, CapitalPrestado = isnull(CapitalPrestado, 0)
				, SaldoCapital = isnull(SaldoCapital, 0)
				, InteresProyectado = isnull(InteresProyectado, 0)
				, IvaProyectado = isnull(IvaProyectado, 0)
				, GastosProyectados = isnull(GastosProyectados, 0)
				, SaldoInteres = isnull(SaldoInteres, 0)
				, SaldoIvaInteres = isnull(SaldoIvaInteres, 0)
				, Mora = isnull(Mora, 0)
				, SaldoMora = isnull(SaldoMora, 0)
				, IvaMora = isnull(IvaMora, 0)
				, SaldoIvaMora = isnull(SaldoIvaMora, 0)
				, Gastos = isnull(Gastos, 0)
				, SaldoGastos = isnull(SaldoGastos, 0)
				, IvaGastos = isnull(IvaGastos, 0)
				, SaldoIvaGastos = isnull(SaldoIvaGastos, 0);

	-- 20221031 DARK PATCH CUADRADOR REQUERIDO POR SF.
	-- 20230327 - DESHABILITADO EL PARCHE OSCURO POR INDICACIÓN DE SF...
	if (1 = 0)
	begin
		update @r set
				SaldoCapital = case when abs(SaldoCapital) <= 0.05 then 0.00 else SaldoCapital end
				, SaldoInteres = case when abs(SaldoInteres) <= 0.05 then 0.00 else SaldoInteres end
				, SaldoIvaInteres = case when abs(SaldoIvaInteres) <= 0.05 then 0.00 else SaldoIvaInteres end
	end;
	return;



end;");
            
            builder.Sql(@"create or alter procedure dbo.sp_creatediagram
	(
		@diagramname 	sysname,
		@owner_id		int	= null,
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end

		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert;

		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end

		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;

		select @retval = @@IDENTITY
		return @retval
	END
go
exec sp_addextendedproperty 'microsoft_database_tools_support', 1, 'SCHEMA', 'dbo', 'PROCEDURE', 'sp_creatediagram'
go
deny execute on dbo.sp_creatediagram to guest
go
grant execute on dbo.sp_creatediagram to [public]
go");

            builder.Sql(@"create or alter function dbo.fn_diagramobjects() RETURNS int	WITH EXECUTE AS N'dbo' AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'),
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128

		return @InstalledObjects
	END
go 
exec sp_addextendedproperty 'microsoft_database_tools_support', 1, 'SCHEMA', 'dbo', 'FUNCTION', 'fn_diagramobjects'
go

deny execute on dbo.fn_diagramobjects to guest
go

grant execute on dbo.fn_diagramobjects to [public]
go
");

            builder.Sql(@"create or alter function fxBatchGetDetail(@batchKey varchar(100), @batchDate datetime)
	returns @r table (--ROWID int not null,
							[IDENTIFICADORDERELACION] [int] null,
							[TIPO] [int] null,
							[BienOServicio] [varchar](1) null,
							[NumeroLinea] [int] null,
							[Cantidad] [int] null,
							[UnidadMedida] [varchar](3) null,
							[Descripcion] [varchar](121) null,
							[PrecioUnitario] [decimal](18, 2) null,
							[Precio] [decimal](18, 2) null,
							[Descuento] [numeric](2, 2) null,
							[NombreCorto1] [varchar](3) null,
							[CodigoUnidadGravable1] [int] null,
							[MontoGravable1] [decimal](16, 2) null,
							[CantidadUnidadesGravables1] [varchar](1) null,
							[MontoImpuesto1] [decimal](16, 2) null,
							[NombreCorto2] [varchar](1) null,
							[CodigoUnidadGravable2] [varchar](1) null,
							[MontoGravable2] [varchar](1) null,
							[CantidadUnidadesGravables2] [varchar](1) null,
							[MontoImpuesto2] [varchar](1) null,
							[TOTAL] [decimal](17, 2) null,
							[CodigoProducto] [varchar](1) null,
							[OtrosDescuento] [varchar](1) null) as
begin
declare @json nvarchar(MAX);

	set @json = (		select JsonLog
						from  batch_logbatchfiles
						where BatchKey = @batchKey
								and BatchDate = @batchDate
								and Segmento = 'DETAIL'
					);

	insert into @r
		select *
		from openjson(@json)
			with (	-- ROWID int 'strict $.ROWID'
					[IDENTIFICADORDERELACION] int '$.""IDENTIFICADORDERELACION""'
					, [TIPO] int '$.""TIPO""'
					, [BienOServicio] varchar(1) '$.""BienOServicio""'
					, [NumeroLinea] int '$.""NumeroLinea""'
					, [Cantidad] int '$.""Cantidad""'
					, [UnidadMedida] varchar(3) '$.""UnidadMedida""'
					, [Descripcion] varchar(121) '$.""Descripcion""'
					, [PrecioUnitario] decimal(18, 2) '$.""PrecioUnitario""'
					, [Precio] decimal(18, 2) '$.""Precio""'
					, [Descuento] numeric(2, 2) '$.""Descuento""'
					, [NombreCorto1] varchar(3) '$.""NombreCorto1""'
					, [CodigoUnidadGravable1] int '$.""CodigoUnidadGravable1""'
					, [MontoGravable1] decimal(16, 2) '$.""MontoGravable1""'
					, [CantidadUnidadesGravables1] varchar(1) '$.""CantidadUnidadesGravables1""'
					, [MontoImpuesto1] decimal(16, 2) '$.""MontoImpuesto1""'
					, [NombreCorto2] varchar(1) '$.""NombreCorto2""'
					, [CodigoUnidadGravable2] varchar(1) '$.""CodigoUnidadGravable2""'
					, [MontoGravable2] varchar(1) '$.""MontoGravable2""'
					, [CantidadUnidadesGravables2] varchar(1) '$.""CantidadUnidadesGravables2""'
					, [MontoImpuesto2] varchar(1) '$.""MontoImpuesto2""'
					, [TOTAL] decimal(17, 2) '$.""TOTAL""'
					, [CodigoProducto] varchar(1) '$.""CodigoProducto""'
					, [OtrosDescuento] varchar(1) '$.""OtrosDescuento""'

				);
	return;
end;");

            builder.Sql(@"create or alter function fxBatchGetGralList()
	returns @r table (		BatchKey varchar(100) not null,
							BatchDate datetime not null,
							Segments varchar(200) not null
							) as
begin
	insert into @r
		select BatchKey, BatchDate, STRING_AGG (Segmento, ' | ') as Segments
		from batch_logbatchfiles
		group by BatchKey, BatchDate
		order by BatchDate;
	return;
end;");

            builder.Sql(@"create or alter function fxBatchGetHeader(@batchKey varchar(100), @batchDate datetime)
	returns @r table (		-- ROWID int not null,
							-- PrestamoId int,
							-- ReferenciaMigracion nvarchar(250) null,
							[IDENTIFICADORDERELACION] [int] null,
							[CodigoMoneda] [varchar](3) null,
							[FechaHoraEmision] [date] NULL,
							[Exp] [varchar](1) null,
							[NumeroAcceso] [varchar](1) null,
							[Tipo] [varchar](4) null,
							[AfiliacionIVA] [varchar](3) null,
							[CodigoEstablecimiento] [varchar](1) null,
							[CorreoEmisor] [varchar](33) null,
							[NITEmisor] [varchar](9) null,
							[NombreComercial] [varchar](24) null,
							[NombreEmisor] [varchar](24) null,
							[EMISORDireccion] [varchar](49) null,
							[EMISORCodigoPostal] [varchar](5) null,
							[EMISORMunicipio] [varchar](9) null,
							[EMISORDepartamento] [varchar](9) null,
							[EMISORPais] [varchar](2) null,
							[IDReceptor] [nvarchar](10) NULL,
							[NombreReceptor] [nvarchar](452) NULL,
							[CorreoReceptor] [varchar](1) null,
							[TIpoEspecial] [varchar](1) null,
							[RECEPTORDireccion] [varchar](6) null,
							[RECEPTORCodigoPostal] [varchar](1) null,
							[RECEPTORMunicipio] [varchar](9) null,
							[RECEPTORDepartamento] [varchar](9) null,
							[RECEPTORPais] [varchar](2) null,
							[GRANTOTAL] [decimal](18, 2) null,
							[IDENTIFICADOR] [varchar](1) null,
							[TIPOPERSONERIA] [varchar](1) null
						) as
begin
declare @json nvarchar(MAX);

	set @json = (		select JsonLog
						from  batch_logbatchfiles
						where BatchKey = @batchKey
								and BatchDate = @batchDate
								and Segmento = 'HEADER'
					);

	insert into @r
		select *
		from openjson(@json)
			with (	-- ROWID int 'strict $.ROWID'
					-- , PrestamoId int '$.""PrestamoId""'
					-- , ReferenciaMigracion nvarchar(250) '$.""ReferenciaMigracion""'
					[IDENTIFICADORDERELACION] int '$.""IDENTIFICADORDERELACION""'

					, [CodigoMoneda] varchar(3) '$.""CodigoMoneda""'
					, [FechaHoraEmision] date '$.""FechaHoraEmision""'
					, [Exp] varchar(1) '$.""Exp""'
					, [NumeroAcceso] varchar(1) '$.""NumeroAcceso""'
					, [Tipo] varchar(4) '$.""Tipo""'
					, [AfiliacionIVA] varchar(3) '$.""AfiliacionIVA""'
					, [CodigoEstablecimiento] varchar(1) '$.""CodigoEstablecimiento""'
					, [CorreoEmisor] varchar(33) '$.""CorreoEmisor""'
					, [NITEmisor] varchar(9) '$.""NITEmisor""'
					, [NombreComercial] varchar(24) '$.""NombreComercial""'
					, [NombreEmisor] varchar(24) '$.""NombreEmisor""'
					, [EMISORDireccion] varchar(49) '$.""EMISORDireccion""'
					, [EMISORCodigoPostal] varchar(5) '$.""EMISORCodigoPostal""'
					, [EMISORMunicipio] varchar(9) '$.""EMISORMunicipio""'
					, [EMISORDepartamento] varchar(9) '$.""EMISORDepartamento""'
					, [EMISORPais] varchar(2) '$.""EMISORPais""'
					, [IDReceptor] nvarchar(10) '$.""IDReceptor""'
					, [NombreReceptor] nvarchar(452) '$.""NombreReceptor""'
					, [CorreoReceptor] varchar(1) '$.""CorreoReceptor""'
					, [TIpoEspecial] varchar(1) '$.""TIpoEspecial""'
					, [RECEPTORDireccion] varchar(6) '$.""RECEPTORDireccion""'
					, [RECEPTORCodigoPostal] varchar(1) '$.""RECEPTORCodigoPostal""'
					, [RECEPTORMunicipio] varchar(9) '$.""RECEPTORMunicipio""'
					, [RECEPTORDepartamento] varchar(9) '$.""RECEPTORDepartamento""'
					, [RECEPTORPais] varchar(2) '$.""RECEPTORPais""'
					, [GRANTOTAL] decimal(18, 2) '$.""GRANTOTAL""'
					, [IDENTIFICADOR] varchar(1) '$.""IDENTIFICADOR""'
					, [TIPO PERSONERIA] varchar(1) '$.""TIPOPERSONERIA""'


			);
	return;
end;");

            builder.Sql(@"create or alter function fxBatchGetPhrases(@batchKey varchar(100), @batchDate datetime)
	returns @r table (		--ROWID int not null,
							[IDENTIFICADORDERELACION] [int] null,
							[TipoFrase] int null,
							[CodigoEscenario] int null,
							[NumeroResolucion] varchar(100) null,
							[FechaResolucion] varchar(100) null) as
begin
declare @json nvarchar(MAX);

	set @json = (		select JsonLog
						from  batch_logbatchfiles
						where BatchKey = @batchKey
								and BatchDate = @batchDate
								and Segmento = 'PHRASES'
					);

	insert into @r
		select *
		from openjson(@json)
			with (	--ROWID int 'strict $.ROWID'
					[IDENTIFICADORDERELACION] int '$.""IDENTIFICADORDERELACION""'
	            , [TipoFrase] int  '$.""TipoFrase""'
	            , [CodigoEscenario] int  '$.""CodigoEscenario""'
	            , [NumeroResolucion] varchar(100) '$.""NumeroResolucion""'
	            , [FechaResolucion] varchar(100) '$.""FechaResolucion""'

	            );
            return;
            end;");

            builder.Sql(@"create or alter function fxBatchGetTRANSUNION(@batchKey varchar(100), @batchDate datetime)
	returns @r table (		--ROWID int not null,
							TIPO_REGISTRO varchar(10) null
					, CORRELATIVO int null
					, TIPO_SUJETO varchar(10) null
					, NACIONALIDAD varchar(10) null
					, NOMBRE_COMPLETO varchar(200) null
					, PrimerApellido varchar(50) null
					, SegundoApellido varchar(50) null
					, ApellidodeCasada varchar(50) null
					, PrimerNombre varchar(50) null
					, SEGUNDO_NOMBRE varchar(50) null
					, IDENTIFICACION1 varchar(50) null
					, IDENTIFICACION2 varchar(50) null
					, IDENTIFICACION3 varchar(50) null
					, IDENTIFICACION4 varchar(50) null
					, IDENTIFICACION5 varchar(50) null
					, FECHA_NACIMIENTO date null
					, SEXO varchar(10) null
					, ESTADO_CIVIL varchar(10) null
					, DIRECCION_RESIDENCIAL varchar(200) null
					, DirResDivGeo1 decimal(18,8) null
					, DirResDivGeo2 decimal(18,8) null
					, DIRECCION_LABORAL varchar(200) null
					, DirLABDivGeo1 decimal(18,8) null
					, DirLABDivGeo2 decimal(18,8) null
					, DIRECCION_EMAIL varchar(100) null
					, TELEFONO_RESIDENCIAL varchar(50) null
					, TELEFONO_LABORAL varchar(50) null
					, TELEFONO_CELULAR varchar(50) null
					, TIPO_OBLIGACION varchar(10) null
					, Moneda varchar(10) null
					, IDENTIFICADOR_TIPOCUENTA varchar(30) null
					, NUMERO_OBLIGACION int null
					, Fecha_de_Apertura date null
					, Fecha_de_Vencimiento date null
					, PERIODO_PAGO varchar(10) null
					, ESTADO varchar(10) null
					, SUB_ESTADO varchar(10) null
					, CALIFICACION varchar(10) null
					, DIAS_MORA int null
					, VALOR_LIMITE decimal(18, 2) null
					, VALOR_SALDO_TOTAL decimal(18, 2) null
					, VALOR_SALDO_MORA decimal(18, 2) null
					, VALOR_CUOTA decimal(18, 2) null
					, TIPO_DEUDOR varchar(10) null
					, TIPO_GARANTIA varchar(10) null
					, NUMERO_GARANTIA varchar(10) null
					, VALOR_GARANTIA varchar(10) null
					, DESCRIPCION varchar(10) null
					, TASA_CAMBIO varchar(10) null
					, MONTO_VENCIDO varchar(10) null
					, MONTO_PAGADO varchar(10) null
					, NUEVO_LIMITE varchar(10) null
					, FECHA_DE_CASTIGO varchar(10) null
					) as
begin
declare @json nvarchar(MAX);

	set @json = (		select JsonLog
						from  batch_logbatchfiles
						where BatchKey = @batchKey
								and BatchDate = @batchDate
								and Segmento = 'TRANSUNION-DATA'
					);

	insert into @r
		select *
		from openjson(@json)
			with (	--ROWID int 'strict $.ROWID'
					TIPO_REGISTRO varchar(10) '$.""TIPO_REGISTRO""'
					, CORRELATIVO int '$.""CORRELATIVO""'
					, TIPO_SUJETO varchar(10) '$.""TIPO_SUJETO""'
					, NACIONALIDAD varchar(10) '$.""NACIONALIDAD""'
					, NOMBRE_COMPLETO varchar(200) '$.""NOMBRE_COMPLETO""'
					, PrimerApellido varchar(50) '$.""PrimerApellido""'
					, SegundoApellido varchar(50) '$.""SegundoApellido""'
					, ApellidodeCasada varchar(50) '$.""ApellidodeCasada""'
					, PrimerNombre varchar(50) '$.""PrimerNombre""'
					, SEGUNDO_NOMBRE varchar(50) '$.""SEGUNDO_NOMBRE""'
					, IDENTIFICACION1 varchar(50) '$.""IDENTIFICACION1""'
					, IDENTIFICACION2 varchar(50) '$.""IDENTIFICACION2""'
					, IDENTIFICACION3 varchar(50) '$.""IDENTIFICACION3""'
					, IDENTIFICACION4 varchar(50) '$.""IDENTIFICACION4""'
					, IDENTIFICACION5 varchar(50) '$.""IDENTIFICACION5""'
					, FECHA_NACIMIENTO date '$.""FECHA_NACIMIENTO""'
					, SEXO varchar(10) '$.""SEXO""'
					, ESTADO_CIVIL varchar(10) '$.""ESTADO_CIVIL""'
					, DIRECCION_RESIDENCIAL varchar(200) '$.""DIRECCION_RESIDENCIAL""'
					, DirResDivGeo1 decimal(18,8) '$.""DirResDivGeo1""'
					, DirResDivGeo2 decimal(18,8) '$.""DirResDivGeo2""'
					, DIRECCION_LABORAL varchar(200) '$.""DIRECCION_LABORAL""'
					, DirLABDivGeo1 decimal(18,8) '$.""DirLABDivGeo1""'
					, DirLABDivGeo2 decimal(18,8) '$.""DirLABDivGeo2""'
					, DIRECCION_EMAIL varchar(100) '$.""DIRECCION_EMAIL""'
					, TELEFONO_RESIDENCIAL varchar(50) '$.""TELEFONO_RESIDENCIAL""'
					, TELEFONO_LABORAL varchar(50) '$.""TELEFONO_LABORAL""'
					, TELEFONO_CELULAR varchar(50) '$.""TELEFONO_CELULAR""'
					, TIPO_OBLIGACION varchar(10) '$.""TIPO_OBLIGACION""'
					, Moneda varchar(10) '$.""Moneda""'
					, IDENTIFICADOR_TIPOCUENTA varchar(30) '$.""IDENTIFICADOR_TIPOCUENTA""'
					, NUMERO_OBLIGACION int '$.""NUMERO_OBLIGACION""'
					, Fecha_de_Apertura date '$.""Fecha_de_Apertura""'
					, Fecha_de_Vencimiento date '$.""Fecha_de_Vencimiento""'
					, PERIODO_PAGO varchar(10) '$.""PERIODO_PAGO""'
					, ESTADO varchar(10) '$.""ESTADO""'
					, SUB_ESTADO varchar(10) '$.""SUB_ESTADO""'
					, CALIFICACION varchar(10) '$.""CALIFICACION""'
					, DIAS_MORA int '$.""DIAS_MORA""'
					, VALOR_LIMITE decimal(18, 2) '$.""VALOR_LIMITE""'
					, VALOR_SALDO_TOTAL decimal(18, 2) '$.""VALOR_SALDO_TOTAL""'
					, VALOR_SALDO_MORA decimal(18, 2) '$.""VALOR_SALDO_MORA""'
					, VALOR_CUOTA decimal(18, 2) '$.""VALOR_CUOTA""'
					, TIPO_DEUDOR varchar(10) '$.""TIPO_DEUDOR""'
					, TIPO_GARANTIA varchar(10) '$.""TIPO_GARANTIA""'
					, NUMERO_GARANTIA varchar(10) '$.""NUMERO_GARANTIA""'
					, VALOR_GARANTIA varchar(10) '$.""VALOR_GARANTIA""'
					, DESCRIPCION varchar(10) '$.""DESCRIPCION""'
					, TASA_CAMBIO varchar(10) '$.""TASA_CAMBIO""'
					, MONTO_VENCIDO varchar(10) '$.""MONTO_VENCIDO""'
					, MONTO_PAGADO varchar(10) '$.""MONTO_PAGADO""'
					, NUEVO_LIMITE varchar(10) '$.""NUEVO_LIMITE""'
					, FECHA_DE_CASTIGO varchar(10) '$.""FECHA_DE_CASTIGO""'


				);
	return;
end;");

            builder.Sql(@"create or alter function fxBatchGetTotalTaxes(@batchKey varchar(100), @batchDate datetime)
	returns @r table (--ROWID int not null,
							[IDENTIFICADORDERELACION] [int] null,
							NombreCorto varchar(100) null,
							TotalMontoImpuesto decimal(16, 2) null) as
begin
declare @json nvarchar(MAX);

	set @json = (		select JsonLog
						from  batch_logbatchfiles
						where BatchKey = @batchKey
								and BatchDate = @batchDate
								and Segmento = 'TOTAL-TAXES'
					);

	insert into @r
		select *
		from openjson(@json)
			with (	--ROWID int 'strict $.ROWID'
					[IDENTIFICADORDERELACION] int '$.""IDENTIFICADORDERELACION""'
	            , [NombreCorto] varchar(100) '$.""NombreCorto""'
	            , [TotalMontoImpuesto] decimal(16, 2) '$.""TotalMontoImpuesto""'

	            );
            return;
            end;");

            builder.Sql(@"create or alter function fxGetSaldosxPrestamo(@pid int)
		returns  @r table (
							Id int,
							ReferenciaMigracion nvarchar(125) null,
							DeudaTotal decimal(18, 2) default 0 null,
							CapitalPrestado decimal(18, 2) default 0 null,
							SaldoCapital decimal(18, 2) default 0 null,
							InteresProyectado decimal(18, 2) default 0 null,
							IvaProyectado decimal(18, 2) default 0 null,
							GastosProyectados decimal(18, 2) default 0 null,
							SaldoInteres decimal(18, 2) default 0 null,
							SaldoIvaInteres decimal(18, 2) default 0 null,
							Mora decimal(18, 2) default 0 null,
							SaldoMora decimal(18, 2) default 0 null,
							IvaMora decimal(18, 2) default 0 null,
							SaldoIvaMora decimal(18, 2) default 0 null,
							Gastos decimal(18, 2) default 0 null,
							SaldoGastos decimal(18, 2) default 0 null,
							IvaGastos decimal(18, 2) default 0 null,
							SaldoIvaGastos decimal(18, 2) default 0 null
						) as
begin


declare @extras decimal(18, 2)
		, @mora  decimal(18, 2)
		, @ivaMora decimal(18, 2)
		, @gastos decimal(18, 2)
		, @ivagastos decimal(18, 2)

		, @tABO_C decimal(18, 2)
		, @tABO_I decimal(18, 2)
		, @tABO_IIVA decimal(18, 2)
		, @tABO_M decimal(18, 2)
		, @tABO_MIVA decimal(18, 2)
		, @tABO_G decimal(18, 2)
		, @tABO_GIVA decimal(18, 2)
		;
	/*
	if (1 = 0)
	begin
		select	Id, ReferenciaMigracion, MontoOtorgado,
				InteresProyectado, IvaProyectado, GastosProyectados, MontoTotalProyectado,
				Plazo, TasaInteres, TasaMora, TasaIva
		from Prestamos
		where Id = @pid;
	end;
	*/
	set @extras = (select SUM(CuotaMora + CuotaIvaMora + CuotaGastos + CuotaIvaGastos) from PlanPagos where PrestamoId = @pid);


	select
			@extras = SUM(CuotaMora + CuotaIvaMora + CuotaGastos + CuotaIvaGastos),
			@mora = sum(CuotaMora),
			@ivaMora = sum(CuotaIvaMora),
			@gastos = sum(CuotaGastos),
			@ivaGastos = sum(CuotaIvaGastos)
	from PlanPagos
	where PrestamoId = @pid;


	-- Consulta de total de abonos por rubro
	if (1 = 1)
	begin
	-- select * from TipoTransaccion
		set @tABO_C = (		select sum(a.MontoCapital)
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Capital')
							where a.PrestamoId = @pid
						);

		set @tABO_I = (		select sum(a.MontoInteres )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Intereses')
							where a.PrestamoId = @pid
						);

		set @tABO_IIVA = (		select sum(a.MontoIvaIntereses )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Iva Intereses')
							where a.PrestamoId = @pid
						);

		set @tABO_M = (		select sum(a.MontoMora )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Mora')
							where a.PrestamoId = @pid
						);

		set @tABO_MIVA = (		select sum(a.MontoIvaMora )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Iva Mora')
							where a.PrestamoId = @pid
						);

		set @tABO_G = (		select sum(a.MontoGastos )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Gastos')
							where a.PrestamoId = @pid
						);

		set @tABO_GIVA = (
							select sum(a.MontoIvaGastos )
							from RegistroCajas a
								inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								inner join TipoTransaccion c on c.Id = b.TipoTransaccionId and c.Nombre in ('Abono Migración', 'Abono Saldo Iva Gastos')
							where a.PrestamoId = @pid
						);

	end;

	insert into @r (Id, ReferenciaMigracion, DeudaTotal, CapitalPrestado, SaldoCapital, InteresProyectado, IvaProyectado, GastosProyectados, SaldoInteres, SaldoIvaInteres, Mora, SaldoMora, IvaMora, SaldoIvaMora, Gastos, SaldoGastos, IvaGastos, SaldoIvaGastos)
		select  a.Id, a.ReferenciaMigracion,
				a.MontoTotalProyectado + @extras as DeudaTotal
				, a.MontoOtorgado as CapitalPrestado
				, a.MontoOtorgado - @tABO_C as SaldoCapital
				, a.InteresProyectado
				, a.IvaProyectado -- => IvaInteresProyectado
				, a.GastosProyectados

				, a.InteresProyectado - @tABO_I as SaldoInteres
				, a.IvaProyectado - @tABO_IIVA as SaldoIvaInteres    -- => IvaInteresProyectado - @tABO_IIVA

				, @mora as Mora
				, @mora - @tABO_M as SaldoMora
				, @ivaMora as IvaMora
				, @ivaMora - @tABO_MIVA as SaldoIvaMora
				, @gastos as Gastos
				, @gastos - @tABO_G as SaldoGastos
				, @ivaGastos as IvaGastos
				, @ivaGastos - @tABO_GIVA as SaldoIvaGastos


		from Prestamos a
		where a.Id = @pid;


	update @r set
				Id = isnull(Id, 0)
				, ReferenciaMigracion = isnull(ReferenciaMigracion, 0)
				, DeudaTotal = isnull(DeudaTotal, 0)
				, CapitalPrestado = isnull(CapitalPrestado, 0)
				, SaldoCapital = isnull(SaldoCapital, 0)
				, InteresProyectado = isnull(InteresProyectado, 0)
				, IvaProyectado = isnull(IvaProyectado, 0)
				, GastosProyectados = isnull(GastosProyectados, 0)
				, SaldoInteres = isnull(SaldoInteres, 0)
				, SaldoIvaInteres = isnull(SaldoIvaInteres, 0)
				, Mora = isnull(Mora, 0)
				, SaldoMora = isnull(SaldoMora, 0)
				, IvaMora = isnull(IvaMora, 0)
				, SaldoIvaMora = isnull(SaldoIvaMora, 0)
				, Gastos = isnull(Gastos, 0)
				, SaldoGastos = isnull(SaldoGastos, 0)
				, IvaGastos = isnull(IvaGastos, 0)
				, SaldoIvaGastos = isnull(SaldoIvaGastos, 0);

	return;
end;");

            builder.Sql(@"-- Asignación inteligente de valor a filtro recibido:
--     > Se pone ""vacío"" si se recibe un nulo
	            --     > Se eliminan espacios de izquierda y derecha
	            --     > Se eliminan 4 veces los espacios dobles
	            --     > Se reemplazan los espacios por ""%""
            create or alter function fxGetSmartCharFilter(@filter varchar(100)) returns varchar(100) as
	            begin
            set @filter	= trim(isnull(@filter, ''));

            set @filter = replace(@filter, '  ', ' ');
            set @filter = replace(@filter, '  ', ' ');
            set @filter = replace(@filter, '  ', ' ');
            set @filter = replace(@filter, '  ', ' ');

            set @filter = replace(@filter, ' ', '%');

            return @filter;
            end;");

            builder.Sql(@"create or alter function fxL68_FixTextValue(@v varchar(max)) returns  varchar(max) as
begin
declare @r varchar(max);
	set @r = trim(isnull(@v, ''));

	set @r = upper(@r);
	set @r = replace(@r, 'Á', 'A');
	set @r = replace(@r, 'É', 'E');
	set @r = replace(@r, 'Í', 'I');
	set @r = replace(@r, 'Ó', 'O');
	set @r = replace(@r, 'Ú', 'U');
	set @r = replace(@r, 'Ñ', 'N');
	set @r = replace(@r, 'Ü', 'U');
	set @r = replace(@r, ' ', '');
	return @r;
end;");

            builder.Sql(@"-- Función de búsqueda personas con filtro aplicado sobre NOMBRE, IDENTIFICACION, NIT, CELULAR, TELEFONO y TELEFONO LABORAL de las personas
-- RESULTADO: Solo se devuelve una tabla con columnas [ EntidadId, PersonaId ]
create or alter function fxMDI_PersonsQry(@filter varchar(100)) returns @r table (EntidadId int, PersonaId int) as
begin
declare @filterSrc varchar(100);
	set @filterSrc = trim(isnull(@filter, ''));

	set @filter = dbo.fxGetSmartCharFilter(@filter);

	insert into @r (EntidadId, PersonaId)
		select distinct a.EntidadId, a.Id as PersonaId
		from v_mdi_personas_full a
			inner join Personas b on b.Id = a.Id
			inner join (
					select '%' + dbo.fxGetSmartCharFilter([value]) + '%' as smartFilter from string_split(@filterSrc, ',') z where not trim([value]) = ''
					union select '%' +  @filter + '%'
				) c
					on a.Nombre						like c.smartFilter
						or b.NumeroDocumento		like c.smartFilter
						or b.NIT					like c.smartFilter
						or b.NumeroCelular			like c.smartFilter
						or b.NumeroTelefono			like c.smartFilter
						or b.NumeroTelefonoLaboral	like c.smartFilter
			;

	return;
end;");

            builder.Sql(@"-- Función de búsqueda personas con filtro aplicado sobre NOMBRE, IDENTIFICACION, NIT, CELULAR, TELEFONO y TELEFONO LABORAL de las personas
-- IMPORTANTE: El resultado se base en el uso de la función [dbo.fxMDI_PersonsQry]
-- RESULTADO: Solo se devuelve una tabla con columnas [ EntidadId, PersonaId, Nombre, NIT, NumeroDocumento, NumeroCelular, NumeroTelefono, NumeroTelefonoLaboral]
create or alter function fxMDI_PersonsQryFull(@filter varchar(100)) returns @r table (
																		EntidadId int
																		, PersonaId int
																		, Nombre varchar(300) null
																		, NIT varchar(100) null
																		, NumeroDocumento varchar(100) null
																		, NumeroCelular varchar(100) null
																		, NumeroTelefono varchar(100) null
																		, NumeroTelefonoLaboral varchar(100) null
                                                                        , Direccion varchar(200) null

																	) as
begin

	insert into @r (EntidadId, PersonaId, Nombre, NumeroDocumento, NIT, NumeroCelular, NumeroTelefono, NumeroTelefonoLaboral, Direccion)
		select distinct a.EntidadId, a.Id as PersonaId,  a.Nombre, b.NumeroDocumento, b.NIT, b.NumeroCelular, b.NumeroTelefono, b.NumeroTelefonoLaboral, b.Direccion
		from v_mdi_personas_full a
			inner join Personas b on b.Id = a.Id
			inner join dbo.fxMDI_PersonsQry(@filter) c on c.PersonaId = a.Id;

	return;
end;");

            builder.Sql(@"create or alter function getFirstPaymentDate(@loanDeliveryDate date, @nextPaymentDate date = null) returns date as
begin
	declare @r date, @aux int, @aux2 int;

	set @r = dateadd(month, 1, @loanDeliveryDate);
	set @nextPaymentDate = isnull(@nextPaymentDate, @loanDeliveryDate);

	set @aux = day(dateadd(day, -1, dateadd(month, 1, datefromparts(year(@r), month(@r), 1))));
	set @aux2 = day(@nextPaymentDate);
	if @aux2 > @aux set @aux2 = @aux

	set @r = datefromparts(year(@r), month(@r), @aux2);

	return @r;
end;");

            builder.Sql(@"create or alter function getOwnerEntityId() returns int as
begin
	declare @r int;
	set @r = 1;
	return @r;
end;");

            builder.Sql(@"create or alter function getQuoteValue(@loanId int) returns decimal(18, 2) as
begin
	declare @r decimal (18, 2);
	declare @n smallint;

	set @n = (select count(*) from PlanPagos where PrestamoId = @loanId);

	if (@n = 0) return @r;

	if (@n = 1) set @r = (select CuotaCapital + CuotaIntereses + CuotaIvaIntereses + CuotaGastos + CuotaIvaGastos from PlanPagos where Id = @loanId);
	else
	begin
		set @r = (
					select CuotaCapital + CuotaIntereses + CuotaIvaIntereses + CuotaGastos + CuotaIvaGastos
					from PlanPagos
					where Id = (	select min(Id)
									from PlanPagos
									where PrestamoId = @loanId and Id > (	select min(Id)
																			from PlanPagos
																			where Id = @loanId
																			)
							)
				);
	end;
	return @r;
end;");

            builder.Sql(@"create or alter procedure sp_PlanPagos_CambioDeFechas (@prestamoId int, @fechaPrimerPago date) as
declare @xdateLog datetime = getdate();

	if (1 = 0) select * from PlanPagos where PrestamoId = @prestamoId;

	if (1 = 0)
	begin
		select	a.Id
			, a.Periodo
			, a.FechaPago
			, case a.Periodo when 1 then b.PRIMER_PAGO else  dateadd( month, (a.Periodo - 1), b.PRIMER_PAGO)   end as NUEVA_FechaPago

		from PlanPagos a, (select convert(date, @fechaPrimerPago) as PRIMER_PAGO) b
		where a.PrestamoId = @prestamoId;
	end;

	-- Registro de log de PlanPagos anterior
	insert into PlanPagosLog (	PrestamoId, FechaLog, PlanPagosId, Periodo, CuotaCapital, CuotaIntereses
								, CuotaIvaIntereses, CuotaMora, CuotaIvaMora, CuotaGastos, CuotaIvaGastos, SaldoCapital
								, SaldoIntereses, SaldoIvaIntereses, SaldoMora, SaldoIvaMora, SaldoGastos, SaldoIvaGastos
								, TotalCuota, SaldoTotal, FechaPago, Aplicado, FechaCreacion, FechaModificacion, Habilitado
								, RegistroCajaId	)
		select @prestamoId as PrestamoId,
					@xdateLog as FechaLog,
					Id as PlanPagosId,
					Periodo,
					CuotaCapital,
					CuotaIntereses,
					CuotaIvaIntereses,
					CuotaMora,
					CuotaIvaMora,
					CuotaGastos,
					CuotaIvaGastos,
					SaldoCapital,
					SaldoIntereses,
					SaldoIvaIntereses,
					SaldoMora,
					SaldoIvaMora,
					SaldoGastos,
					SaldoIvaGastos,
					TotalCuota,
					SaldoTotal,
					FechaPago,
					Aplicado,
					FechaCreacion,
					FechaModificacion,
					Habilitado,
					RegistroCajaId
		from PlanPagos
		where PrestamoId = @prestamoId
		order by Periodo;

	-- Actualización de fechas de pago a partir de la fecha de primer pago del parámetro recibido
	update a
		set a.FechaPago = case a.Periodo
							when 1 then b.PRIMER_PAGO
							else  dateadd( month, (a.Periodo - 1), b.PRIMER_PAGO)
						end
		from PlanPagos a,
				(select convert(date, @fechaPrimerPago) as PRIMER_PAGO) b
		where a.PrestamoId = @prestamoId;");

            builder.Sql(@"create or alter procedure dbo.sp_alterdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int

		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int

		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end

		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;

		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname

		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
go 
exec sp_addextendedproperty 'microsoft_database_tools_support', 1, 'SCHEMA', 'dbo', 'PROCEDURE', 'sp_alterdiagram'
go
deny execute on dbo.sp_alterdiagram to guest
go
grant execute on dbo.sp_alterdiagram to [public]
go");
            
            builder.Sql(@"create or alter procedure sp_batchfile_generator (@showResult bit = 0)  as
Begin

declare @batchKey varchar(36), @batchDate datetime;

declare @tHeader table (	ROWID int identity (1, 1) not null,
							PrestamoId int, ReferenciaMigracion nvarchar(250) null,
							[IDENTIFICADORDERELACION] [int] null,
							[CodigoMoneda] [varchar](3) null,
							[FechaHoraEmision] [date] NULL,
							[Exp] [varchar](1) null,
							[NumeroAcceso] [varchar](1) null,
							[Tipo] [varchar](4) null,
							[AfiliacionIVA] [varchar](3) null,
							[CodigoEstablecimiento] [varchar](1) null,
							[CorreoEmisor] [varchar](33) null,
							[NITEmisor] [varchar](9) null,
							[NombreComercial] [varchar](24) null,
							[NombreEmisor] [varchar](24) null,
							[EMISORDireccion] [varchar](49) null,
							[EMISORCodigoPostal] [varchar](5) null,
							[EMISORMunicipio] [varchar](9) null,
							[EMISORDepartamento] [varchar](9) null,
							[EMISORPais] [varchar](2) null,
							[IDReceptor] [nvarchar](10) NULL,
							[NombreReceptor] [nvarchar](452) NULL,
							[CorreoReceptor] [varchar](1) null,
							[TIpoEspecial] [varchar](1) null,
							[RECEPTORDireccion] [varchar](6) null,
							[RECEPTORCodigoPostal] [varchar](1) null,
							[RECEPTORMunicipio] [varchar](9) null,
							[RECEPTORDepartamento] [varchar](9) null,
							[RECEPTORPais] [varchar](2) null,
							[GRANTOTAL] [decimal](18, 2) null,
							[IDENTIFICADOR] [varchar](1) null,
							[TIPOPERSONERIA] [varchar](1) null
						);

declare @tDetail table (	ROWID int identity (1, 1) not null,
							[IDENTIFICADORDERELACION] [int] null,
							[TIPO] [int] null,
							[BienOServicio] [varchar](1) null,
							[NumeroLinea] [int] null,
							[Cantidad] [int] null,
							[UnidadMedida] [varchar](3) null,
							[Descripcion] [varchar](121) null,
							[PrecioUnitario] [decimal](18, 2) null,
							[Precio] [decimal](18, 2) null,
							[Descuento] [numeric](2, 2) null,
							[NombreCorto1] [varchar](3) null,
							[CodigoUnidadGravable1] [int] null,
							[MontoGravable1] [decimal](16, 2) null,
							[CantidadUnidadesGravables1] [varchar](1) null,
							[MontoImpuesto1] [decimal](16, 2) null,
							[NombreCorto2] [varchar](1) null,
							[CodigoUnidadGravable2] [varchar](1) null,
							[MontoGravable2] [varchar](1) null,
							[CantidadUnidadesGravables2] [varchar](1) null,
							[MontoImpuesto2] [varchar](1) null,
							[TOTAL] [decimal](17, 2) null,
							[CodigoProducto] [varchar](1) null,
							[OtrosDescuento] [varchar](1) null
						);

declare @tTotalTaxes table (ROWID int identity (1, 1) not null,
							[IDENTIFICADORDERELACION] [int] null,
							NombreCorto varchar(100) null,
							TotalMontoImpuesto decimal(16, 2) null
							);

declare @tPhrases table (	ROWID int identity (1, 1) not null,
							[IDENTIFICADORDERELACION] [int] null,
							[TipoFrase] int null,
							[CodigoEscenario] int null,
							[NumeroResolucion] varchar(100) null,
							[FechaResolucion] varchar(100) null
						);

	set nocount on;

	set @batchKey = newid();
	set @batchDate = getdate();

	-- @tHeader
	if (1 = 1)
	begin
		insert into @tHeader (	PrestamoId, ReferenciaMigracion,
								[IDENTIFICADORDERELACION],	[CodigoMoneda],				[FechaHoraEmision],			[Exp],
								[NumeroAcceso],					[Tipo],						[AfiliacionIVA],			[CodigoEstablecimiento],
								[CorreoEmisor],					[NITEmisor],				[NombreComercial],			[NombreEmisor],
								[EMISORDireccion],				[EMISORCodigoPostal],		[EMISORMunicipio],			[EMISORDepartamento],
								[EMISORPais],					[IDReceptor],				[NombreReceptor],			[CorreoReceptor],
								[TIpoEspecial],					[RECEPTORDireccion],		[RECEPTORCodigoPostal],
								[RECEPTORMunicipio],			[RECEPTORDepartamento],	[RECEPTORPais],			[GRANTOTAL],
								[IDENTIFICADOR],				[TIPOPERSONERIA]
							)
			select b.PrestamoId, p.ReferenciaMigracion,
				b.Id														AS [IDENTIFICADORDERELACION]	-- Referencia a sistema DLT/T4M
				, 'GTQ'														AS [CodigoMoneda]				-- CONSTANTE

				-- [X] 20221102 , convert(date, getdate())									AS [FechaHoraEmision]			-- REFERENCIADO / CALCULADO / X SOLICITUD SINFIN
				, b.FechaTransaccion as FechaHoraEmision -- 20221102 SF solicitó cambiar el getdate por este valor...

				, ''														AS [Exp]						-- CONSTANTE
				, ''														AS [NumeroAcceso]				-- CONSTANTE
				, 'FACT'													AS [Tipo]						-- CONSTANTE
				, 'GEN'														AS [AfiliacionIVA]				-- CONSTANTE
				, '1'														AS [CodigoEstablecimiento]		-- SEMI-CONSTANTE | Valor del propietario
				, 'mercedes.delcid@plataforma.com.gt'						AS [CorreoEmisor]				-- SEMI-CONSTANTE | Valor del propietario
				, '104273402'												AS [NITEmisor]					-- SEMI-CONSTANTE | Valor del propietario
				, 'CORPORACIÓN LENDING S.A.'								AS [NombreComercial]			-- SEMI-CONSTANTE | Valor del propietario
				, 'CORPORACIÓN LENDING S.A.'								AS [NombreEmisor]				-- SEMI-CONSTANTE | Valor del propietario
				, '14 CALLE 3-51 EDIFICIO MURANO CENTER ZONA 10 1601'		AS [EMISORDireccion]			-- SEMI-CONSTANTE | Valor del propietario
				, '01010'													AS [EMISORCodigoPostal]		-- SEMI-CONSTANTE | Valor del propietario
				, 'GUATEMALA'												AS [EMISORMunicipio]			-- CONSTANTE
				, 'GUATEMALA'												AS [EMISORDepartamento]		-- CONSTANTE
				, 'GT'														AS [EMISORPais]				-- CONSTANTE

				, case
						when mdi.NIT is null then 'CF'
						when not ISNUMERIC(	substring(mdi.NIT, 1, len(mdi.NIT) - 1 ) ) = 1 then 'CF'
						else mdi.NIT
					end														AS [IDReceptor]					-- REFERENCIADO | NIT
				, mdi.Nombre												AS [NombreReceptor]				-- REFERENCIADO | NOMBRE
				, ''														AS [CorreoReceptor]				-- CONSTANTE !! Porque no lo tenemos
				, ''														AS [TIpoEspecial]				-- CONSTANTE
				, 'CIUDAD'													AS [RECEPTORDireccion]			-- CONSTANTE
				, '0'														AS [RECEPTORCodigoPostal]		-- CONSTANTE
				, 'GUATEMALA'												AS [RECEPTORMunicipio]			-- CONSTANTE
				, 'GUATEMALA'												AS [RECEPTORDepartamento]		-- CONSTANTE
				, 'GT'														AS [RECEPTORPais]				-- CONSTANTE
				, (	b.MontoInteres + b.MontoIvaIntereses + b.MontoMora
					+ b.MontoIVaMora + b.MontoGastos + b.MontoIvaGastos
					)														AS [GRANTOTAL]					-- REFERENCIADO !!!
				, ''														AS [IDENTIFICADOR]				-- CONSTANTE
				, ''														AS [TIPO PERSONERIA]			-- CONSTANTE

			from RegistroCajas b
				inner join Prestamos p on p.Id = b.PrestamoId
				inner join v_mdi_general_full mdi on mdi.EntidadId = p.EntidadPrestamoId

				-- 20221122 > SF ha indicado que solo se deben tomar en cuenta en los encabezados los [RegistrosCajas] que posean alguna
				-- transacción en [EstadoCuentas] de tipo (9, 10, 11, 12, 13, 14) para ser tomadas en cuenta en el BATCH...
				inner join (
								select distinct a.Id
								from RegistroCajas a
									inner join EstadoCuentas b on b.RegistroCajaId = a.Id
								where b.TipoTransaccionId between 9 and 14
					) dark20221122  on dark20221122.Id = b.Id

			where b.Id > 7755
					and b.BatchKey is null

					and not (	b.MontoInteres + b.MontoIvaIntereses + b.MontoMora
								+ b.MontoIVaMora + b.MontoGastos + b.MontoIvaGastos
							) = 0
			order by b.Id;

	end;

	-- @tDetail
	if (1 = 1)
	begin
		insert into @tDetail (	[IDENTIFICADORDERELACION], [TIPO], [BienOServicio], [NumeroLinea], [Cantidad], [UnidadMedida], [Descripcion], [PrecioUnitario], [Precio], [Descuento], [NombreCorto1], [CodigoUnidadGravable1]
								, [MontoGravable1]
, [CantidadUnidadesGravables1], [MontoImpuesto1], [NombreCorto2], [CodigoUnidadGravable2], [MontoGravable2], [CantidadUnidadesGravables2], [MontoImpuesto2], [TOTAL], [CodigoProducto], [OtrosDescuento] )
			select
					[IDENTIFICADORDERELACION]
					, 1 AS [TIPO]
					, 'S' AS [BienOServicio]
					, 1 AS [NumeroLinea]
					, 1 AS [Cantidad]
					, 'UND' AS [UnidadMedida]
					, 'Abono a '
							+ case
									when not b.MontoInteres = 0 or not b.MontoIvaIntereses = 0 then 'intereses'
									else ''
								end
							+ case
									when (not b.MontoInteres = 0 or not b.MontoIvaIntereses = 0 )
										and (not b.MontoMora = 0 or not b.MontoIvaMora = 0) then '/'
									else ''
								end

							+ case
									when not b.MontoMora = 0 or not b.MontoIvaMora = 0 then 'moras'
									else ''
								end
							+ ' de préstamo ID: '
							+ CONVERT(varchar(100), a.PrestamoId) AS [Descripcion]
					-- , d.Descripcion as [Descripcion]
					, (b.MontoInteres + b.MontoIvaIntereses + b.MontoMora + b.MontoIVaMora + b.MontoGastos + b.MontoIvaGastos) AS [PrecioUnitario]
					, 0  AS [Precio]
					, 0.00 AS [Descuento]
					, 'IVA' AS [NombreCorto1]
					, 1 AS [CodigoUnidadGravable1] -- CTE (1 => IVA, 2 => NO HAY)

					, 0 AS [MontoGravable1]
					, '' AS [CantidadUnidadesGravables1]

					 , 0 as [MontoImpuesto1]  -- [MontoGravable1] * 0.12

					, '' AS [NombreCorto2]
					, '' AS [CodigoUnidadGravable2]
					, '' AS [MontoGravable2]
					, '' AS [CantidadUnidadesGravables2]
					, '' AS [MontoImpuesto2]
					, 0 AS [TOTAL] -- [MontoGravable1] + [MontoImpuesto1]

					, '' AS [CodigoProducto]
					, '' AS [OtrosDescuento]
			from @tHeader a
				inner join RegistroCajas b on b.Id = a.[IDENTIFICADORDERELACION]
				-- inner join EstadoCuentas c on c.RegistroCajaId = b.Id
				-- inner join TipoTransaccion d on d.Id = c.TipoTransaccionId
			order by [IDENTIFICADORDERELACION];

		update @tDetail set [Precio] = [PrecioUnitario];
		update @tDetail set MontoGravable1 = PrecioUnitario / 1.12;
		update @tDetail set MontoImpuesto1 = MontoGravable1 * 0.12;
		update @tDetail set TOTAL = MontoGravable1 + MontoImpuesto1;

		delete from @tDetail where TOTAL = 0;

	end;

	-- @tTotalTaxes
	if (1 = 1)
	begin
		insert into @tTotalTaxes ([IDENTIFICADORDERELACION], NombreCorto, TotalMontoImpuesto)
			select [IDENTIFICADORDERELACION], 'IVA' as NombreCorto, sum([MontoImpuesto1])	as TotalMontoImpuesto
			from @tDetail
			group by [IDENTIFICADORDERELACION]
			order by 1;
	end;

	-- @tPhrases
	if (1 = 1)
	begin
		insert into @tPhrases ([IDENTIFICADORDERELACION], TipoFrase, CodigoEscenario, NumeroResolucion, [FechaResolucion])
			select
				[IDENTIFICADORDERELACION]
				, 1 AS [TipoFrase]
				, 1 AS [CodigoEscenario]
				, '' AS [NumeroResolucion]
				, '' AS [FechaResolucion]
			from @tHeader
			order by 1;
	end;

	if (1 = 1)
	begin
		if (select count(*) from @tHeader) > 0
		begin
			insert into batch_logbatchfiles (BatchKey, BatchDate, Segmento, JSONLog) values (@batchKey, @batchDate, 'HEADER', (select * from @tHeader FOR JSON PATH) );
			insert into batch_logbatchfiles (BatchKey, BatchDate, Segmento, JSONLog) values (@batchKey, @batchDate, 'DETAIL', (select * from @tDetail FOR JSON PATH) );
			insert into batch_logbatchfiles (BatchKey, BatchDate, Segmento, JSONLog) values (@batchKey, @batchDate, 'TOTAL-TAXES', (select * from @tTotalTaxes FOR JSON PATH) );
			insert into batch_logbatchfiles (BatchKey, BatchDate, Segmento, JSONLog) values (@batchKey, @batchDate, 'PHRASES', (select * from @tPhrases FOR JSON PATH) );

			update a
				set a.BatchDate = @batchDate, a.BatchKey = @batchKey
			from RegistroCajas a
				inner join @tHeader b on b.[IDENTIFICADORDERELACION] = a.Id;
		end;
	end;



	if (@showResult = 1)
	begin
		select [IDENTIFICADORDERELACION], [CodigoMoneda], [FechaHoraEmision], [Exp], [NumeroAcceso], [Tipo], [AfiliacionIVA], [CodigoEstablecimiento], [CorreoEmisor], [NITEmisor], [NombreComercial], [NombreEmisor], [EMISORDireccion], [EMISORCodigoPostal],



				[EMISORMunicipio], [EMISORDepartamento], [EMISORPais], [IDReceptor], [NombreReceptor], [CorreoReceptor], [TIpoEspecial], [RECEPTORDireccion], [RECEPTORCodigoPostal], [RECEPTORMunicipio], [RECEPTORDepartamento], [RECEPTORPais], [GRANTOTAL]
				, [IDENTIFICADOR], [TIPOPERSONERIA] from @tHeader;
		select [IDENTIFICADORDERELACION], [TIPO], [BienOServicio], [NumeroLinea], [Cantidad], [UnidadMedida], [Descripcion], [PrecioUnitario], [Precio], [Descuento], [NombreCorto1], [CodigoUnidadGravable1],
		[MontoGravable1], [CantidadUnidadesGravables1], [MontoImpuesto1], [NombreCorto2], [CodigoUnidadGravable2], [MontoGravable2], [CantidadUnidadesGravables2], [MontoImpuesto2], [TOTAL], [CodigoProducto], [OtrosDescuento] from @tDetail;
		select [IDENTIFICADORDERELACION], [NombreCorto], [TotalMontoImpuesto] from @tTotalTaxes;
		select [IDENTIFICADORDERELACION], [TipoFrase], [CodigoEscenario], [NumeroResolucion], [FechaResolucion] as FechaResolucion from @tPhrases;
	end;

	set nocount off;

	--if (@showResult = 0)
	select @batchKey as BatchKey, @batchDate as BatchDate;


	if (0 = 1)
		select [IDENTIFICADORDERELACION], Descripcion, PrecioUnitario,  MontoGravable1, MontoImpuesto1, TOTAL, PrecioUnitario - TOTAL as DIFERENCIA
		from @tDetail
		where 1 = 1
			-- and [IDENTIFICADOR DE RELACION] = 8406
				and NOT TOTAL = PrecioUnitario
		order by 1 desc;

End");

            builder.Sql(@"create or alter procedure dbo.sp_dropdiagram
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int

		declare @UIDFound 		int
		declare @DiagId			int

		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end

		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end

		delete from dbo.sysdiagrams where diagram_id = @DiagId;

		return 0;
	END
go
deny execute on dbo.sp_creatediagram to guest
go
grant execute on dbo.sp_creatediagram to [public]
go");

            builder.Sql(@"create or alter procedure dbo.sp_helpdiagramdefinition
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int

		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end

		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ;
		return 0
	END
go
deny execute on dbo.sp_creatediagram to guest
go
grant execute on dbo.sp_creatediagram to [public]
go");

			builder.Sql(@"create or alter procedure dbo.sp_helpdiagrams
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
go
deny execute on dbo.sp_creatediagram to guest
go
grant execute on dbo.sp_creatediagram to [public]
go");

			builder.Sql(@"create or alter proc sp_job_calcularMora as
declare @start datetime = getdate(), @end datetime;
declare @tasaIVA decimal(16, 4) = 0.12;

declare @fechaActual datetime, @fechaReferencia date,
		@cargoMontoMora decimal(18, 2)
		, @cargoMontoIvaMora decimal(18, 2)
		, @capitalVencido decimal(18, 2)
		, @n int, @i int
		;

declare @PrestamoId int
		, @TasaMora decimal(18, 2)
		, @DiasMora int
		, @PlanPagoId int
		, @FechaPago date
		;

declare @tPrestamo table (		ROWID int identity(1,1) not null
								, PrestamoId int
								, TasaMora decimal(18, 2)
								, DiasMora int
								, PlanPagoId int null
								, FechaPago date
							);

	set nocount on;

	set @fechaActual = getdate();
	set @fechaReferencia = convert(date, @fechaActual);

	update PlanPagos set FechaModificacion = FechaCreacion where FechaModificacion = @fechaReferencia;

	insert into @tPrestamo (PrestamoId, TasaMora, DiasMora, PlanPagoId, FechaPago)
		select a.Id, a.TasaMora, a.DiasMora, min(b.Id) as PlanPagoId, min(b.FechaPago) as FechaPago
		from Prestamos a
			left outer join PlanPagos b on b.PrestamoId = a.Id and b.Aplicado = 0
		where a.EstadoPrestamoId in (1, 7, 8)
			-- and a.Id = 261
		group by a.Id, a.TasaMora, a.DiasMora;

	set @n = @@ROWCOUNT;
	set @i = 1;

	while (@i <= @n)
	begin

		select @PrestamoId = PrestamoId
				, @TasaMora = TasaMora
				, @DiasMora = DiasMora
				, @PlanPagoId = PlanPagoId
				, @FechaPago = FechaPago
				, @cargoMontoMora = 0.00
				, @cargoMontoIvaMora = 0.00
				, @capitalVencido = 0.00
		from @tPrestamo
		where ROWID = @i;

		if (1 = 0) select * from @tPrestamo;

		if (1 = 0) print 'PID: ' + convert(varchar(20), @PrestamoId);

		if not @PlanPagoId is null
		begin

			if @FechaPago < @fechaActual  set @DiasMora = datediff(day, @FechaPago, @fechaActual);
			else set @DiasMora = 0;

			if (@DiasMora < 0) select 'ALERTA' as SBJ, @PrestamoId as PID, @fechaActual as FechaActual, @FechaPago as FechaPago, @DiasMora as DiasMora;

			set @capitalVencido = ISNULL(		(
													select sum(SaldoCapital)
													from PlanPagos
													where PrestamoId = @PrestamoId
															and Aplicado = 0
															and FechaPago <= @fechaActual
															and not FechaModificacion = @fechaReferencia
												)
												, 0.00
										);


			/*
			cargoMontoMora = capitalVencido * tasaMora / 365 * prestamo.DiasMora;
			cargoMontoIvaMora = cargoMontoMora * 0.12m;
			planPago.CuotaMora = cargoMontoMora;
			planPago.SaldoMora = cargoMontoMora;
			planPago.CuotaIvaMora = cargoMontoIvaMora;
			planPago.SaldoIvaMora = cargoMontoIvaMora;
			planPago.FechaModificacion = fechaActual.Date;
			*/

			set @cargoMontoMora = @capitalVencido * @TasaMora / 365 * @DiasMora;
			set @cargoMontoIvaMora = @cargoMontoMora * @tasaIVA;

			update PlanPagos set CuotaMora = @cargoMontoMora
								, SaldoMora = @cargoMontoMora
								, CuotaIvaMora = @cargoMontoIvaMora
								, SaldoIvaMora = @cargoMontoIvaMora
								, FechaModificacion = @fechaReferencia
			where Id = @PlanPagoId;

			update PlanPagos set FechaModificacion = @fechaReferencia
			where PrestamoId = @PrestamoId
			and	  Id > @PlanPagoId
			and   FechaPago < @fechaReferencia
			and   Aplicado = 0;

			update Prestamos set DiasMora = @DiasMora where Id = @PrestamoId;

		end;


		set @i += 1;
	end;

	set @end = GETDATE();
	set nocount off;

	select @start as [START], @end as [END], datediff(second, @start, @end) as [SECONDS];");

			builder.Sql(@"create or alter procedure sp_mig15_reasignarFechasPlanPagos(@pid int, @firstQuoteDate date, @showDif bit = 0) as
declare @blockId varchar(255);

	set nocount on;

	set @blockId = newid();

	insert into mig_planpagos_bk (	BLOCKID, PlanPagosId, PrestamoId, Periodo
									, CuotaCapital, CuotaIntereses, CuotaIvaIntereses, CuotaMora, CuotaIvaMora, CuotaGastos, CuotaIvaGastos
									, SaldoCapital, SaldoIntereses, SaldoIvaIntereses, SaldoMora, SaldoIvaMora, SaldoGastos, SaldoIvaGastos
									, TotalCuota, SaldoTotal
									, FechaPago
									, Aplicado
									, FechaCreacion, FechaModificacion
									, Habilitado
									)

		select					@blockId as BLOCKID, Id as PlanPagosId, PrestamoId, Periodo
								, CuotaCapital, CuotaIntereses, CuotaIvaIntereses, CuotaMora, CuotaIvaMora, CuotaGastos, CuotaIvaGastos
								, SaldoCapital, SaldoIntereses, SaldoIvaIntereses, SaldoMora, SaldoIvaMora, SaldoGastos, SaldoIvaGastos
								, TotalCuota, SaldoTotal
								, FechaPago
								, Aplicado
								, FechaCreacion, FechaModificacion
								, Habilitado
		from PlanPagos
		where PrestamoId = @pid
		order by Id;


	update PlanPagos set FechaPago = dateadd(month, 1 * (Periodo - 1), @firstQuoteDate) where PrestamoId = @pid;

	set nocount off;

	if (@showDif = 1)
	begin
		select	a.Periodo
				, b.FechaPago as FechaPago_ANTERIOR
				, a.FechaPago as FechaPago_ACTUAL
		from PlanPagos a
			inner join mig_planpagos_bk b on b.BLOCKID = @blockId and b.PlanPagosId = a.Id
		where a.PrestamoId = @pid
		order by Id;
	end;");

			builder.Sql(@"create or alter procedure sp_pur20230309 (@do bit = 0) as declare @xsql varchar(8000);

	if not object_id('pur_purga20230309_matriz_anterior') is null
	begin
		select 'La tabla [' + 'pur_purga20230309_matriz_anterior' + '] ya existe.' + ' ' + 'Este es su contenido: ';
		select * from pur_purga20230309_matriz_anterior;
		return
	end;

	-- Creación de tabla temporal
	create table #t (	ROWID int identity (1, 1)
						, PARENT_NAME varchar(200) null
						, PARENT_PK_COLNAME varchar(200)
						, PARENT_PK_REFVALUE int null
						, PARENT_COL_NAME varchar(200)
						, OLD_EntidadId int null
						, OLD_PersonaId int null
						, NEW_EntidadId int null
						, NEW_PersonaId int null
						, Executed bit not null default 0
			);

	if (1 = 1)
	begin
		select   @xsql = COALESCE(@xsql + ' union ', '') + XSQL from (
						select  a.name as FK
								, parent.name as FK_ON_TABLE
								, parentcol.name as FK_ON__COLUMN
								, pk.PK_COL_NAME as FK_ON___PKCOL
								, ref.name as FK_REF_TO_TABLE
								, refcol.name as FK_REF_TO_TABLE_COLUMN
								, case when pk.TABLE_NAME is null then 'N' else 'Y' end as PK_OK
								, pk.TABLE_NAME, pk.PK_COL_NAME
								, ROW_NUMBER() OVER(ORDER BY a.name ASC) AS ROWID
								,	''
									-- + case when (ROW_NUMBER() OVER(ORDER BY a.name ASC)) = 1 then '' else 'union ' end
									+ 'select '
										+ '''' + parent.name + ''' as PARENT_NAME'
										+ ', ' + '''' + pk.PK_COL_NAME + ''' as PARENT_PK_COLNAME'
										+ ', ' + 'a.' + pk.PK_COL_NAME + ' as PARENT_PK_REFVALUE'
										+ ', ' + '''' + parentcol.name + ''' as PARENT_COL_NAME'
										-- + ', ' + 'a.' + parentcol.name + ' as OLD_EntidadId'
										+ ', b.EntidadId as OLD_EntidadId, b.PersonaId as OLD_PersonaId'
										+ ', ' + 'per.EntidadId as NEW_EntidadId, b.REF_A_PersonaId as NEW_PersonaId'
										+ ', 0 as Executed'
										+ ' from ' + parent.name + ' a'
											+ ' inner join pur_purga20230309__personasXeliminar b on b.EntidadId = a.' + parentcol.name
											+ ' inner join Personas per on per.Id = b.REF_A_PersonaId'
									as XSQL

						from sys.foreign_keys a
							inner join sys.foreign_key_columns b on b.constraint_object_id = a.object_id
							inner join sys.objects parent on parent.object_id = a.parent_object_id
							inner join sys.objects ref on ref.object_id = a.referenced_object_id
							inner join sys.columns parentcol on parentcol.object_id = parent.object_id and parentcol.column_id = b.parent_column_id
							inner join sys.columns refcol on refcol.object_id = ref.object_id and refcol.column_id = b.referenced_column_id
							left outer join (
												select c.TABLE_NAME, c.COLUMN_NAME , pk1col.PK_COL_NAME
												from INFORMATION_SCHEMA.TABLE_CONSTRAINTS as t
													inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE as c	on t.CONSTRAINT_NAME = c.CONSTRAINT_NAME
													inner join (
																select t.TABLE_NAME, t.CONSTRAINT_NAME, COUNT(*) as PK_NCOLS, MIN(c.COLUMN_NAME) as PK_COL_NAME
																from INFORMATION_SCHEMA.TABLE_CONSTRAINTS t
																	inner join INFORMATION_SCHEMA.KEY_COLUMN_USAGE c on c.CONSTRAINT_NAME = t.CONSTRAINT_NAME
																where t.CONSTRAINT_TYPE = 'PRIMARY KEY'
																group by t.TABLE_NAME, t.CONSTRAINT_NAME
																having COUNT(*) = 1
																) pk1col on pk1col.TABLE_NAME = c.TABLE_NAME
												where t.CONSTRAINT_TYPE = 'PRIMARY KEY'
											) pk on pk.TABLE_NAME = parent.name
						where a.referenced_object_id = object_id('Entidades')
		) z;
	end;

	exec ('insert into #t  (PARENT_NAME, PARENT_PK_COLNAME, PARENT_PK_REFVALUE, PARENT_COL_NAME, OLD_EntidadId, OLD_PersonaId, NEW_EntidadId, NEW_PersonaId, Executed) '
			+ @xsql);



	-- Revisiones
	if (1 = 0 and @do = 0)
	begin
		if (1 = 0) select * from #t;

		if (1 = 1) select PARENT_NAME, COUNT(*) AS N_COUNT, COUNT(DISTINCT PARENT_PK_REFVALUE)  as NCOUNT___DISTINCT___PARENT_PK_REFVALUE from #t group by PARENT_NAME;

		if (1 = 1)
		begin
			select * from #t a inner join AspNetUsers b on b.PersonaId = a.OLD_PersonaId where a.PARENT_NAME = 'Personas';
		end;

		if (1 = 0) select * from #t where PARENT_NAME = 'RelacionEntidades' order by 3;
		if (1 = 0) select a.*, c.Descripcion as TipoRel, b.* from #t a inner join RelacionEntidades b on b.Id = a.PARENT_PK_REFVALUE inner join TipoRelacion c on c.Id = b.TipoRelacionId  where a.PARENT_NAME = 'RelacionEntidades';

		if (1 = 1) select * from #t where PARENT_NAME = 'Prestamos';
		if (1 = 0) select PARENT_PK_REFVALUE, COUNT(*) from #t where PARENT_NAME = 'Prestamos' group by PARENT_PK_REFVALUE having COUNT(*) > 1;
		if (1 = 0) select NEW_EntidadId, COUNT(*)  as N_PRESTAMOS__ from #t where PARENT_NAME = 'Prestamos' group by NEW_EntidadId having COUNT(*) > 1 order by 2 desc;

		if (1 = 0)
		begin

			select NEW_EntidadId, COUNT(*) as N
			from #t a
				inner join Prestamos b on b.EntidadPrestamoId = a.NEW_EntidadId
			where PARENT_NAME = 'Prestamos'
			group by NEW_EntidadId having COUNT(*) > 1;
		end;

		if (1 = 0)
		begin

			select *
			from (
					select NEW_EntidadId, COUNT(*) as NP from #t where PARENT_NAME = 'Prestamos' group by NEW_EntidadId having COUNT(*) > 1
				) a
					RIGHT outer join (

									select NEW_EntidadId, COUNT(*) as N
									from #t a
										inner join Prestamos b on b.EntidadPrestamoId = a.NEW_EntidadId
									where PARENT_NAME = 'Prestamos'
									group by NEW_EntidadId having COUNT(*) > 1
									) b on b.NEW_EntidadId = a.NEW_EntidadId;
		end;

		-- select * from pur_purga20230309 where EntidadId = 859;
		-- select * from pur_purga20230309 where PersonaId = REF_A_PersonaId and ELEGIDO = 'N';
		-- select * from pur_purga20230309 where REF_A_PersonaId = 821

	end;

	-- Generación de tabla MATRIZ ANTERIOR general
	if (@do = 1)
	begin
		if object_id('pur_purga20230309_matriz_anterior') is null select * into pur_purga20230309_matriz_anterior from #t;
	end;

	-- Eliminación de tabla tempoarl
	drop table #t;");

			builder.Sql(@"create or alter procedure sp_pur20230309_part2 as

	if object_id('pur_purga20230309_matriz_anterior') is null
	begin
		select 'La tabla ' + 'pur_purga20230309_matriz_anterior' + ' no existe.';
		return;
	end;

	if object_id('pur_purga20230309_PersonasEliminadasBk') is null
	begin
		select * into pur_purga20230309_PersonasEliminadasBk  from   pur_purga20230309_matriz_anterior a inner join Personas b on b.Id = a.OLD_PersonaId where a.PARENT_NAME = 'Personas';
	end;

	if (1 = 0)
	begin
		select b.EntidadPrestamoId, COUNT(*)
		from pur_purga20230309_matriz_anterior a
			inner join Prestamos b on b.EntidadPrestamoId = a.OLD_EntidadId
		where a.PARENT_NAME = 'Prestamos'
			-- and not a.OLD_PersonaId  in ( 17, 95, 193, 329, 500, 629, 674, 687, 742, 821);
		group by b.EntidadPrestamoId
		having COUNT(*) > 1;
	end;

	update b
		set b.EntidadPrestamoId = a.NEW_EntidadId
	from pur_purga20230309_matriz_anterior a
		inner join Prestamos b on b.EntidadPrestamoId = a.OLD_EntidadId
	where a.PARENT_NAME = 'Prestamos';

	delete b
	from pur_purga20230309_matriz_anterior a
		inner join AspNetUsers b on b.PersonaId = a.PARENT_PK_REFVALUE
	where a.PARENT_NAME = 'Personas';

	delete c
	from pur_purga20230309_matriz_anterior a
		inner join Personas b on b.Id = a.PARENT_PK_REFVALUE
		inner join RelacionEntidades c on c.EntidadHijaId = b.EntidadId
	where a.PARENT_NAME = 'Personas';

	delete b
	from pur_purga20230309_matriz_anterior a
		inner join Personas b on b.Id = a.PARENT_PK_REFVALUE
	where a.PARENT_NAME = 'Personas';");

			builder.Sql(@"create or alter procedure dbo.sp_renamediagram
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname

	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int

		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end

		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;

		select @u_name = USER_NAME(@owner_id)

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end

		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;

		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname

		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end

		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
go
deny execute on dbo.sp_creatediagram to guest
go
grant execute on dbo.sp_creatediagram to [public]
go");

			builder.Sql(@"CREATE proc sp_rpt_CasosBTS as
declare @tAcum table (
							Id int,
							ReferenciaMigracion nvarchar(125) null,
							DeudaTotal decimal(18, 2) default 0 null,
							CapitalPrestado decimal(18, 2) default 0 null,
							SaldoCapital decimal(18, 2) default 0 null,
							InteresProyectado decimal(18, 2) default 0 null,
							IvaProyectado decimal(18, 2) default 0 null,
							GastosProyectados decimal(18, 2) default 0 null,
							SaldoInteres decimal(18, 2) default 0 null,
							SaldoIvaInteres decimal(18, 2) default 0 null,
							Mora decimal(18, 2) default 0 null,
							SaldoMora decimal(18, 2) default 0 null,
							IvaMora decimal(18, 2) default 0 null,
							SaldoIvaMora decimal(18, 2) default 0 null,
							Gastos decimal(18, 2) default 0 null,
							SaldoGastos decimal(18, 2) default 0 null,
							IvaGastos decimal(18, 2) default 0 null,
							SaldoIvaGastos decimal(18, 2) default 0 null
						);

declare @tPrestamo table (ROWID int identity (1, 1) not null, PrestamoId int);
declare @i int, @n int;
	set nocount on;
	insert into @tPrestamo (PrestamoID) select a.Id from Prestamos a;
	set @n = @@ROWCOUNT;

	set @i = 1;
	while (@i <= @n)
	begin
		insert into @tAcum select * from SaldosMigracion( (select PrestamoId from @tPrestamo where ROWID = @i) );
		set @i = @i + 1;
	end;

	--if not object_id('test_al_aire') is null drop table test_al_aire;

	-- set nocount off;

	select
		pre.Id as IdPrestamo,
		pre.ReferenciaMigracion as Referencia
		, mdi.Nombre,
		mdig.Nombre as Gestor,
		pre.MontoOtorgado,
		pre.TasaInteres,
		pre.Plazo,
		pre.MontoTotalProyectado as DeudaTotal,
		pre.InteresProyectado,
		pre.IvaProyectado,
		pre.DiasMora,
		acum.SaldoCapital
		, acum.SaldoInteres as SaldoIntereses
		, acum.SaldoIvaInteres as SaldoIvaIntereses
		, acum.SaldoMora
		, acum.SaldoIvaMora
		, estados.Nombre as Estado
		,(Select Top 1 TotalCuota from PlanPagos where PrestamoId = pre.Id and Aplicado = 0) as CuotaCalculada --Ajuste relizado por SAFC el 17/02/2023
		, convert(date, pre.FechaAprobacion) as FechaAprobacion
		, IsNull(convert(date, pre.FechaAprobacion), convert(date, pre.FechaDesembolso)) as FechaDesembolso
		, IsNull(ppl.PROXIMO_PAGO, '0001-01-01') as ProximoPago
		, IsNull(ppl2.PRIMER_PAGO, '0001-01-01') as FechaPrimerPago
		, IsNull(ppl2.ULTIMO_PAGO, '0001-01-01') as FechaVencimiento
		, IsNull(pagadu.Nombre, ' ') as [Pagaduría]
		, tp.Nombre as TipoPrestamo
	--into test_al_aire

	from
		Prestamos as pre
	Inner Join
		v_mdi_general_full as mdi
	on
		mdi.EntidadId = pre.EntidadPrestamoId
	Inner Join
		v_mdi_general_full as mdig
	on
		mdig.EntidadId = pre.GestorPrestamoId
	Inner Join
		EstadoPrestamos as estados
	on
		estados.Id = pre.EstadoPrestamoId

	left outer join @tAcum acum on acum.Id = pre.Id

	left outer join (
						select PrestamoId, min(FechaPago) as PROXIMO_PAGO
						from PlanPagos
						where Aplicado = 0
						group by PrestamoId
					) ppl on ppl.PrestamoId = pre.ID

	left outer join (
						select PrestamoId,  min(FechaPago) as PRIMER_PAGO, max(FechaPago) as ULTIMO_PAGO
						from PlanPagos
						group by PrestamoId
					) ppl2 on ppl2.PrestamoId = pre.ID

	left outer join v_mdi_general_simple pagadu on pagadu.EntidadId = pre.EmpresaPrestamoId
	inner join TipoPrestamos tp on tp.Id = pre.TipoPrestamoId
	where
		pre.EstadoPrestamoId = 1 or pre.EstadoPrestamoId = 7
	order by pre.Id;

	set nocount off;");

			builder.Sql(@"create or alter procedure sp_sct_balanceRecalculator (@pid int) as
declare @id int, @sant decimal(16, 2), @sact decimal(16, 2), @i int, @n int;
declare @t table (ROWID int identity(1, 1) not null, Id int, Cargo decimal(18, 2), Abono decimal(18, 2),
			SaldoAnterior decimal(16, 2), SaldoActual decimal(16, 2)

);

	set @sant = 0.00;
	set @sact = 0.00;
	set @i = 1;
	insert into @t (Id, Cargo, Abono)
		select Id, Cargo, Abono
		from EstadoCuentas
		where PrestamoId = @pid
		order by Id;

	-- select * from @t;

	set @n = @@rowcount;

	while (@i <= @n)
	begin
		set @sant = @sact;
		select @id = id, @sact = @sant + Cargo - Abono from @t where ROWID = @i;

		update @t set SaldoAnterior = @sant, SaldoActual = @sact where ROWID = @i;

		update EstadoCuentas set SaldoAnterior = @sant, SaldoActual = @sact where Id = @id;
		-- select @i, @id,  Cargo, Abono, @sant, @sact from @t where ROWID = @i;
		set @i = @i + 1;
	end;");

			builder.Sql(@"create or alter procedure sp_sct_cuadrarUltimaCuota (@pid int) as
declare @lastQuoteId int, @descuadres int;
declare @dif_CAPITAL decimal(18, 2), @dif_INTERES decimal(18, 2), @dif_IVA decimal(18, 2);

	select
			@dif_CAPITAL = z.C__DIFERENCIA
			, @dif_INTERES = z.I__DIFERENCIA
			, @dif_IVA = z.IVA__DIFERENCIA
	from (
			select	MontoOtorgado, InteresProyectado, IvaProyectado, Plazo

					, convert(decimal(18, 2), MontoOtorgado / Plazo)							as C__CUOTA__CALCULADO
					, convert(decimal(18, 2), MontoOtorgado / Plazo) * Plazo					as C__CUOTA__CALCULADO_x_NCUOTAS
					, MontoOtorgado - convert(decimal(18, 2), MontoOtorgado / Plazo) * Plazo	as C__DIFERENCIA

					, convert(decimal(18, 2), InteresProyectado / Plazo)			as I__CUOTA__CALCULADO
					, convert(decimal(18, 2), InteresProyectado / Plazo) * Plazo	as I__CUOTA__CALCULADO_x_NCUOTAS
					, InteresProyectado - convert(decimal(18, 2), InteresProyectado / Plazo) * Plazo	as I__DIFERENCIA

					, convert(decimal(18, 2), IvaProyectado / Plazo)			as IVA__CUOTA__CALCULADO
					, convert(decimal(18, 2), IvaProyectado / Plazo) * Plazo	as IVA__CUOTA__CALCULADO_x_NCUOTAS
					, IvaProyectado - convert(decimal(18, 2), IvaProyectado / Plazo) * Plazo	as IVA__DIFERENCIA


			from Prestamos
			where  Id = @pid
		) z;

	set @descuadres = (
						select count(*) as DESCUADRES
						from (
								select	a.MontoOtorgado, a.InteresProyectado, a.IvaProyectado, b.C, b.I, b.IVA
								from Prestamos a, (select sum(CuotaCapital) as C, sum(CuotaIntereses) as I, sum(CuotaIvaIntereses) as IVA from PlanPagos where PrestamoId = @pid) b
								where  a.Id = @pid
								) z
						where not z.C - z.MontoOtorgado = 0
								or not z.I - z.InteresProyectado = 0
								or not z.IVA - z.IvaProyectado = 0
						);

	if (	not @dif_CAPITAL = 0
			or not @dif_INTERES = 0
			or not @dif_IVA = 0
		) and @descuadres > 0
	begin
		set @lastQuoteId = (select max(Id) from PlanPagos where PrestamoId = @pid);

		update PlanPagos set
				CuotaCapital = CuotaCapital + @dif_CAPITAL
				, CuotaIntereses = CuotaIntereses + @dif_INTERES
				, CuotaIvaIntereses = CuotaIvaIntereses + @dif_IVA
		where Id = @lastQuoteId;

		update PlanPagos set TotalCuota = CuotaCapital + CuotaIntereses + CuotaIvaIntereses where Id = @lastQuoteId;
		update PlanPagos set SaldoCapital = CuotaCapital, SaldoIntereses = CuotaIntereses, SaldoIvaIntereses = CuotaIvaIntereses  where Id = @lastQuoteId;

	end;");
			
			builder.Sql(@"CREATE proc sp_sct_payAllCurrentDebtAndCloseLoan (@pid int, @showResult bit = 0) as
declare @nRowsCaja int, @mRowsCaja int;
declare @tipoTranId int, @estadoPrestamoId int,  @regCajId int, @uid nvarchar(450),
		@salActual decimal(18, 2), @salAnterior decimal(18, 2), @v decimal(18, 2),
		@ecId int;

declare @tSal table (	T_SaldoCapital		decimal(18, 2),
						T_SaldoGastos		decimal(18, 2),
						T_SaldoIntereses	decimal(18, 2),
						T_SaldoIvaGastos	decimal(18, 2),
						T_SaldoIvaIntereses	decimal(18, 2),
						T_SaldoIvaMora		decimal(18, 2),
						T_SaldoMora			decimal(18, 2),
						T_Saldo				decimal(18, 2)
					);

	if not 'Activo' = (select b.Descripcion from Prestamos a inner join EstadoPrestamos b on b.Id = a.EstadoPrestamoId where a.Id = @pid)
	begin
		print 'Invalid load state detected...';
		return;
		select 100;
	end;

	if (select count(*) from sct_PlanPagosBk where PrestamoId = @pid) = 0
	begin
		insert into sct_PlanPagosBk (
										Id, PrestamoId, Periodo, CuotaCapital, CuotaIntereses, CuotaIvaIntereses, CuotaMora, CuotaIvaMora, CuotaGastos, CuotaIvaGastos
										, SaldoCapital, SaldoIntereses, SaldoIvaIntereses, SaldoMora, SaldoIvaMora, SaldoGastos, SaldoIvaGastos, TotalCuota
										, SaldoTotal, FechaPago, Aplicado, FechaCreacion, FechaModificacion, Habilitado
										)
			select Id, PrestamoId, Periodo, CuotaCapital, CuotaIntereses, CuotaIvaIntereses, CuotaMora, CuotaIvaMora, CuotaGastos, CuotaIvaGastos
			, SaldoCapital, SaldoIntereses, SaldoIvaIntereses, SaldoMora, SaldoIvaMora, SaldoGastos, SaldoIvaGastos, TotalCuota
			, SaldoTotal, FechaPago, Aplicado, FechaCreacion, FechaModificacion, Habilitado
			from PlanPagos
			where PrestamoId = @pid;
	end;

	exec sp_sct_cuadrarUltimaCuota @pid;

	set @tipoTranId = (select Id from TipoTransaccion where Descripcion = 'Nota de Débito (Ajuste por Liquidación)');
	set @estadoPrestamoId = (select Id from [EstadoPrestamos] where Descripcion = 'Liquidado por Recrédito');
	set @uid = (select Id from AspNetUsers where UserName = 'sys@system.com');
	set @salActual = (select SaldoActual from EstadoCuentas where Id = (select max(Id) from EstadoCuentas where PrestamoId = @pid));
	set @ecId = @@IDENTITY;
	set @salAnterior = @salActual;
	set @nRowsCaja = (select COUNT(*) from RegistroCajas);

	-- Step #1 :: Sobre tabla PlanPagos se sacan todos los saldos
	insert into @tSal
		select sum(SaldoCapital) as T_SaldoCapital
				, sum(SaldoGastos) as T_SaldoGastos
				, sum(SaldoIntereses) as T_SaldoIntereses
				, sum(SaldoIvaGastos) as T_SaldoIvaGastos
				, sum(SaldoIvaIntereses) as T_SaldoIvaIntereses
				, sum(SaldoIvaMora) as T_SaldoIvaMora
				, sum(SaldoMora) as T_SaldoMora
				, sum(SaldoCapital
						+ SaldoGastos
						+ SaldoIntereses
						+ SaldoIvaGastos
						+ SaldoIvaIntereses
						+ SaldoIvaMora
						+ SaldoMora
					) as T_Saldo
		from PlanPagos
		where PrestamoId = @pid;

	if (1 = 0) select * from @tSal;

	-- Step #2 :: Agregar una transacción por la suma de esos saldos en la tabla RegistroCajas
	insert into RegistroCajas (
								AppUserId,				BancoId,				CajaId,				FormaPagoId,
								PrestamoId,				FechaTransaccion,		FechaPago,			NumeroDocumento,
								DiasMora,				MontoPago,				MontoCapital,		MontoInteres,
								MontoIvaIntereses,		MontoMora,				MontoIvaMora,		MontoGastos,
								MontoIvaGastos,			MontoCapitalAnticipado, CuotasAdelantadas,	CuotasVencidas,
								TotalCuotasVencidas,	Observaciones,			MotivoAnulacion,	FechaCreacion,
								FechaModificacion,		Habilitado,				BatchDate,			BatchKey
								)

		select @uid as AppUserId, b.Id as BancoId, c.Id as CajaId, d.Id as FormaPagoId,
				@pid as PrestamoId, getdate() as FechaTransaccion, getdate() as FechaPago, 'N/A' as NumeroDocumento
				, 0 as DiasMora
				, s.T_Saldo as MontoPago
				, s.T_SaldoCapital as MontoCapital
				, s.T_SaldoIntereses as MontoInteres
				, s.T_SaldoIvaIntereses as MontoIvaIntereses
				, s.T_SaldoMora as MontoMora
				, s.T_SaldoIvaMora as MontoIvaMora
				, s.T_SaldoGastos as MontoGastos
				, s.T_SaldoIvaGastos as MontoIvaGastos
				, 0 as MontoCapitalAnticipado
				, 0 as CuotasAdelantadas
				, 0	CuotasVencidas
				, 0 as TotalCuotasVencidas
				, null as Observaciones
				, null as MotivoAnulacion
				, getdate() as FechaCreacion
				, getdate() as FechaModificacion
				, 1 as Habilitado
				, '0001-01-01T00:00:00.0000000' as BatchDate
				, null as BatchKey
		from @tSal s
				inner join Bancos b on b.Descripcion = 'No Aplica'
				inner join Cajas c on c.Nombre = 'Caja General'
				inner join FormaPagos d on d.Descripcion = 'Nota Débito';

	set @regCajId = @@IDENTITY;

	-- 20230328 SF+PCID
	-- Step #2.5 Se registrarán transacciones por saldos de MORA e IVA MORA si existe algún valor...
	if (1 = 1)
	begin
		declare @auxSM decimal(18, 2), @auxSIM decimal(18, 2);

		select @auxSM = T_SaldoMora
				, @auxSIM = T_SaldoIvaMora
		from @tSal;

		if (@auxSM > 0)
		begin
			set @salActual = @salActual + @auxSM;

			insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							tipotran.Id as TipoTransaccionId
							, @auxSM as Cargo
							, 0.00 as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Cargo Mora' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado
					from TipoTransaccion tipotran
					where tipotran.Nombre = 'Cargo Saldo Mora';

			set @salAnterior = @salActual;
		end;

		if (@auxSIM > 0)
		begin
			set @salActual = @salActual + @auxSIM;

			insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							tipotran.Id as TipoTransaccionId
							, @auxSIM as Cargo
							, 0.00 as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Cargo  Iva Mora' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado
					from TipoTransaccion tipotran
					where tipotran.Nombre = 'Cargo Saldo Iva Mora';

			set @salAnterior = @salActual;

		end;
	end;


	set @mRowsCaja = (select COUNT(*) from RegistroCajas);

	-- Step #3 :: Para luego meter cada transacción distinta en estado de cuenta por cada ""rubro"" afectado
	-- Step #4 :: Para luego meter en tabla AbonoCuotas como se afectó cada una de las cuotas de PlanPagos con la parte que le haya tocado.
	if (@nRowsCaja < @mRowsCaja)
	begin

		set @v = (select T_SaldoCapital from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono Capital' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, a.SaldoCapital as CuotaCapital
							, 0.00 as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, 0.00 as CuotaIvaMora
							, 0.00 as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoCapital > 0;

		end;


		set @v = (select T_SaldoIntereses from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono Intereses' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, a.SaldoIntereses as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, 0.00 as CuotaIvaMora
							, 0.00 as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoIntereses > 0;
		end;

		set @v = (select T_SaldoIvaIntereses from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono IVA Intereses' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, 0.00 as CuotaIntereses
							, a.SaldoIvaIntereses as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, 0.00 as CuotaIvaMora
							, 0.00 as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoIvaIntereses > 0;
		end;

		set @v = (select T_SaldoGastos from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono Gastos' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, 0.00 as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, 0.00 as CuotaIvaMora
							, a.SaldoGastos as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoGastos > 0;
		end;


		set @v = (select T_SaldoIvaGastos from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono IVA Gastos' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, 0.00 as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, 0.00 as CuotaIvaMora
							, 0.00 as CuotaGastos
							, a.SaldoIvaGastos as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoIvaGastos > 0;
		end;

		set @v = (select T_SaldoMora from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono Mora' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, 0.00 as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, a.SaldoMora as CuotaMora
							, 0.00 as CuotaIvaMora
							, 0.00 as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoMora > 0;
		end;

		set @v = (select T_SaldoIvaMora from @tSal);
		if  @v > 0
		begin
				set @salActual = @salActual - @v;

				insert into EstadoCuentas (	AppUserId,	PrestamoId,		RegistroCajaId,		TipoTransaccionId,
											Cargo,		Abono,			SaldoAnterior,		SaldoActual,
											Concepto,	FechaCreacion,	FechaModificacion,	Habilitado
											)
					select @uid as AppUserId, @pid as PrestamoId, @regCajId as RegistroCajaId,
							@tipoTranId as TipoTransaccionId
							, 0.00 as Cargo
							, @v as Abono
							, @salAnterior as SaldoAnterior
							, @salActual as SaldoActual
							, 'Abono IVA Mora' as Concepto
							, getdate() as FechaCreacion
							, getdate() as FechaModificacion
							, 1 Habilitado;

				set @ecId = @@IDENTITY;
				set @salAnterior = @salActual;

				insert into AbonoPlanes (	EstadoCuentaId,		PlanPagoId, CuotaCapital, CuotaIntereses,
											CuotaIvaIntereses,	CuotaMora,	CuotaIvaMora, CuotaGastos,
											CuotaIvaGastos
										)
					select @ecId as EstadoCuentaId
							, a.Id as PlanPagoId
							, 0.00 as CuotaCapital
							, 0.00 as CuotaIntereses
							, 0.00 as CuotaIvaIntereses
							, 0.00 as CuotaMora
							, a.SaldoIvaMora as CuotaIvaMora
							, 0.00 as CuotaGastos
							, 0.00 as CuotaIvaGastos
					from PlanPagos a
					where a.PrestamoId = @pid
						and a.SaldoIvaMora > 0;
		end;

	end;


	-- Step #5 :: Para luego cambiar el estado del préstamo al NUEVO-ESTADO-PRESTAMO...
	if (@nRowsCaja < @mRowsCaja)
	begin
		update Prestamos set EstadoPrestamoId = @estadoPrestamoId, DiasMora = 0 where Id = @pid;
	end;

	-- Step #6 :: Se pone valor 0 a todos los saldos de todas las cuotas en la tabla [PlanPagos] y valor 1 a la columna ""Aplicado"".
	if (@nRowsCaja < @mRowsCaja)
	begin
		update PlanPagos set
			SaldoCapital = 0, SaldoGastos = 0, SaldoIntereses = 0, SaldoIvaGastos = 0, SaldoIvaIntereses = 0, SaldoIvaMora = 0, SaldoMora = 0, Aplicado = 1
		where PrestamoId = @pid;
	end;

	-- Step # 7 :: Requerimiento de SF
	-- 20230328 SF indicó que se debía quitar esta cuadradora...
	if (1 = 0) update EstadoCuentas  set SaldoActual = 0 where Id = (select max(Id) from EstadoCuentas where PrestamoId = @pid);

	if (@showResult = 1) and (@nRowsCaja < @mRowsCaja)
	begin
		-- select * from RegistroCajas where Id >= @regCajId;
		select * from EstadoCuentas where PrestamoId = @pid order by Id desc;
		-- select c.* from EstadoCuentas a inner join AbonoPlanes c on c.EstadoCuentaId = a.Id where a.PrestamoId = @pid order by a.Id desc, c.PlanPagoId desc;
		select * from PlanPagos where PrestamoId = @pid;
	end;");

			builder.Sql(@"CREATE proc sp_transunion__batchfile_generator (@showResult bit = 1)  as
-- declare @showResult bit = 1;
declare @batchKey varchar(36), @batchDate datetime, @segmentKey varchar(20) = 'TRANSUNION-DATA';
declare @tData table (
					ROWID int identity (1, 1) not null
					, TIPO_REGISTRO varchar(10) null
					, CORRELATIVO int null
					, TIPO_SUJETO varchar(10) null
					, NACIONALIDAD varchar(10) null
					, NOMBRE_COMPLETO varchar(200) null
					, PrimerApellido varchar(50) null
					, SegundoApellido varchar(50) null
					, ApellidodeCasada varchar(50) null
					, PrimerNombre varchar(50) null
					, SEGUNDO_NOMBRE varchar(50) null
					, IDENTIFICACION1 varchar(50) null
					, IDENTIFICACION2 varchar(50) null
					, IDENTIFICACION3 varchar(50) null
					, IDENTIFICACION4 varchar(50) null
					, IDENTIFICACION5 varchar(50) null
					, FECHA_NACIMIENTO date null
					, SEXO varchar(10) null
					, ESTADO_CIVIL varchar(10) null
					, DIRECCION_RESIDENCIAL varchar(200) null
					, DirResDivGeo1 decimal(18,8) null
					, DirResDivGeo2 decimal(18,8) null
					, DIRECCION_LABORAL varchar(200) null
					, DirLABDivGeo1 decimal(18,8) null
					, DirLABDivGeo2 decimal(18,8) null
					, DIRECCION_EMAIL varchar(100) null
					, TELEFONO_RESIDENCIAL varchar(50) null
					, TELEFONO_LABORAL varchar(50) null
					, TELEFONO_CELULAR varchar(50) null
					, TIPO_OBLIGACION varchar(10) null
					, Moneda varchar(10) null
					, IDENTIFICADOR_TIPOCUENTA varchar(30) null
					, NUMERO_OBLIGACION int null
					, Fecha_de_Apertura date null
					, Fecha_de_Vencimiento date null
					, PERIODO_PAGO varchar(10) null
					, ESTADO varchar(10) null
					, SUB_ESTADO varchar(10) null
					, CALIFICACION varchar(10) null
					, DIAS_MORA int null
					, VALOR_LIMITE decimal(18, 2) null
					, VALOR_SALDO_TOTAL decimal(18, 2) null
					, VALOR_SALDO_MORA decimal(18, 2) null
					, VALOR_CUOTA decimal(18, 2) null
					, TIPO_DEUDOR varchar(10) null
					, TIPO_GARANTIA varchar(10) null
					, NUMERO_GARANTIA varchar(10) null
					, VALOR_GARANTIA varchar(10) null
					, DESCRIPCION varchar(10) null
					, TASA_CAMBIO varchar(10) null
					, MONTO_VENCIDO varchar(10) null
					, MONTO_PAGADO varchar(10) null
					, NUEVO_LIMITE varchar(10) null
					, FECHA_DE_CASTIGO varchar(10) null
					);

	set nocount on;

	set @batchKey = newid();
	set @batchDate = getdate();

	insert into @tData (	TIPO_REGISTRO, CORRELATIVO, TIPO_SUJETO, NACIONALIDAD
							, NOMBRE_COMPLETO
							, PrimerApellido, SegundoApellido, ApellidodeCasada, PrimerNombre, SEGUNDO_NOMBRE
							, IDENTIFICACION1, IDENTIFICACION2, IDENTIFICACION3, IDENTIFICACION4, IDENTIFICACION5
							, FECHA_NACIMIENTO, SEXO, ESTADO_CIVIL
							, DIRECCION_RESIDENCIAL, DirResDivGeo1, DirResDivGeo2
							, DIRECCION_LABORAL, DirLABDivGeo1, DirLABDivGeo2
							, DIRECCION_EMAIL, TELEFONO_RESIDENCIAL, TELEFONO_LABORAL, TELEFONO_CELULAR
							, TIPO_OBLIGACION, Moneda
							, IDENTIFICADOR_TIPOCUENTA, NUMERO_OBLIGACION
							, Fecha_de_Apertura, Fecha_de_Vencimiento
							, PERIODO_PAGO, ESTADO, SUB_ESTADO, CALIFICACION
							, DIAS_MORA, VALOR_LIMITE, VALOR_SALDO_TOTAL, VALOR_SALDO_MORA, VALOR_CUOTA
							, TIPO_DEUDOR, TIPO_GARANTIA, NUMERO_GARANTIA, VALOR_GARANTIA
							, DESCRIPCION, TASA_CAMBIO, MONTO_VENCIDO, MONTO_PAGADO
							, NUEVO_LIMITE, FECHA_DE_CASTIGO
					)
					select
							'CRD'									as TIPO_REGISTRO
							 , row_number() OVER (order by p.Id)	as CORRELATIVO
							, 'F'									as TIPO_SUJETO
							, 'GT'									as NACIONALIDAD -- [!!!] Constante hasta que se hagan arreglos en nuestra DB | Ya hay referencia en [Personas] a [Paises] pero no hay ""clave"" de nacionalidad
							, deudor.NOMBRE							as NOMBRE_COMPLETO
							, deudor.PrimerApellido					as PrimerApellido
							, deudor.SegundoApellido				as SegundoApellido
							, deudor.ApellidoCasada					as ApellidodeCasada
							, deudor.PrimerNombre					as PrimerNombre
							, deudor.SegundoNombre					as SEGUNDO_NOMBRE
							, ''									as IDENTIFICACION1
							, deudor.NIT							as IDENTIFICACION2
							, deudor.DPI							as IDENTIFICACION3
							, ''									as IDENTIFICACION4
							, ''									as IDENTIFICACION5
							, isNull(deudor.FechaNacimiento, '')	as FECHA_NACIMIENTO
							, isNull(g.Descripcion, '')				as SEXO
							, isNull(ec.Descripcion, '')			as ESTADO_CIVIL
							, trim(
									isnull(pp.Direccion, '')
									+ ' ' + isnull(pp.Colonia, '')
									)								as DIRECCION_RESIDENCIAL



							, 0										as DirResDivGeo1
							, 0										as DirResDivGeo2
							, ''									as DIRECCION_LABORAL -- [!!!] Pendiente ver qué se va a poner aquí
							, 0										as DirLABDivGeo1
							, 0										as DirLABDivGeo2
							, isNull(pp.Email, '')					as DIRECCION_EMAIL
							, isNull(pp.NumeroTelefono, '')			as TELEFONO_RESIDENCIAL
							, isNull(pp.NumeroTelefonoLaboral, '')	as TELEFONO_LABORAL
							, isNull(pp.NumeroCelular, '')			as TELEFONO_CELULAR
							, 'CON'									as TIPO_OBLIGACION
							, 'GTQ'									as Moneda
							, ''									as IDENTIFICADOR_TIPOCUENTA
							, p.Id									as NUMERO_OBLIGACION -- Préstamo ID
							, isNull(ppa.FIRST_QUOTE_DATE, '')		as Fecha_de_Apertura
							, isNull(ppa.LAST_QUOTE_DATE, '')		as Fecha_de_Vencimiento
							, 'MEN'									as PERIODO_PAGO
							-- , 'VIG'									as ESTADO

							, case
								when estadop.Nombre in ( 'Activo',  'En Proceso') then 'VIG'
								when estadop.Nombre in ( 'Cartera Saneada') then 'SAN'
								when estadop.Nombre in ( 'Cancelado',  'Cancelado por migración', 'Liquidado por Recrédito') then 'CAN'
								when estadop.Nombre in ( 'En Demanda') then 'DEM'
								else '???'
							end as ESTADO
							-- select * from sys.objects where type = 'u' order by name;
							-- select * from EstadoPrestamos;

							, moraFlag.SUB_ESTADO					as SUB_ESTADO
							, ''									as CALIFICACION
							, p.DiasMora							as DIAS_MORA
							, p.MontoOtorgado						as VALOR_LIMITE
							, saldos_20230110.SaldoTotal			as VALOR_SALDO_TOTAL -- saldos.SaldoTotal (Cambiado porque debe ser solo sobre saldo de capital de cuotas a la fecha en curso)
							, saldos_20230110.SaldoMora				as VALOR_SALDO_MORA -- saldos.SaldoMora (Cambiado porque debe ser solo sobre saldo de ""mora+ivaMora"" de cuotas a la fecha en curso)
							, dbo.getQuoteValue(p.Id)				as VALOR_CUOTA
							, 'DIR'									as TIPO_DEUDOR
							, 'FID'									as TIPO_GARANTIA
							, ''									as NUMERO_GARANTIA
							, ''									as VALOR_GARANTIA
							, ''									as DESCRIPCION
							, ''									as TASA_CAMBIO
							, ''									as MONTO_VENCIDO
							, ''									as MONTO_PAGADO
							, ''									as NUEVO_LIMITE
							, ''									as FECHA_DE_CASTIGO
		from Prestamos p

			inner join EstadoPrestamos estadop on estadop.Id = p.EstadoPrestamoId and not estadop.Nombre = 'Cancelado por migración'
			inner join (	select distinct PrestamoId
							from PlanPagos
							where FechaPago < convert(date, getdate()) -- and Aplicado = 0
						) a on a.PrestamoId = p.Id

			inner join v_mdi_general_full deudor on deudor.EntidadId = p.EntidadPrestamoId
			inner join Personas pp on pp.EntidadId = p.EntidadPrestamoId

			left outer join EstadoCivil ec on ec.Id = pp.EstadoCivilId
			left outer join Generos g on g.Id = pp.GeneroId

			left outer join (	select PrestamoId, count(*) as NQuotes, min(FechaPago) as FIRST_QUOTE_DATE, max(FechaPago) as LAST_QUOTE_DATE from PlanPagos group by PrestamoId) ppa on ppa.PrestamoId = p.Id

			-- SUB_ESTADO => Definido con SF que se pondrá DIA/MOR teniendo MORA cuando se tenga un saldo de alguna cuota con fecha < que la fecha en curso.
			left outer join (	select PrestamoId
										, case
											when 0 = sum(	SaldoCapital + SaldoIntereses + SaldoIvaIntereses + SaldoMora + SaldoIvaMora + SaldoGastos + SaldoIvaGastos) then 'DIA'
											else 'MOR'
										end as SUB_ESTADO
										from PlanPagos
								where FechaPago < convert(date, getdate())
								group by PrestamoId
							) moraFlag on moraFlag.PrestamoId = p.Id

			left outer join (	select PrestamoId
										, sum(	SaldoCapital + SaldoIntereses + SaldoIvaIntereses + SaldoMora + SaldoIvaMora + SaldoGastos + SaldoIvaGastos) as SaldoTotal
										, sum(	SaldoMora + SaldoIvaMora) as SaldoMora
								from PlanPagos
								group by PrestamoId
							) saldos on saldos.PrestamoId = p.Id

			left outer join (	select PrestamoId, sum(SaldoCapital) as SaldoTotal, sum(	SaldoMora + SaldoIvaMora) as SaldoMora
								from PlanPagos
								where FechaPago <= convert(date, getdate())
								group by PrestamoId
							) saldos_20230110 on saldos_20230110.PrestamoId = p.Id

			-- left outer join Paises countries on countries.Id = pp.PaisNacimientoId [!!!] Tipo de columnas no permite hacer el join
			-- where p.Id = 604
			-- where estadop.Nombre in ( 'Cartera Saneada')
			-- where p.DiasMora = 0
		 ; -- [!!!] Pendiente afinar filtrada de registros

	-- select * from Prestamos;
	-- select * from PlanPagos where PrestamoId = 	1203 order by Id
	-- select * from RegistroCajas where PrestamoId = 	1203 order by Id

	if (1 = 1) and (select count(*) from @tData) > 0
	begin
		insert into batch_logbatchfiles (BatchKey, BatchDate, Segmento, JSONLog)
			values (@batchKey, @batchDate, @segmentKey
						, (
								select
										TIPO_REGISTRO, CORRELATIVO, TIPO_SUJETO, NACIONALIDAD
										, NOMBRE_COMPLETO
										, PrimerApellido, SegundoApellido, ApellidodeCasada, PrimerNombre, SEGUNDO_NOMBRE
										, IDENTIFICACION1, IDENTIFICACION2, IDENTIFICACION3, IDENTIFICACION4, IDENTIFICACION5
										, FECHA_NACIMIENTO, SEXO, ESTADO_CIVIL
										, DIRECCION_RESIDENCIAL, DirResDivGeo1, DirResDivGeo2
										, DIRECCION_LABORAL, DirLABDivGeo1, DirLABDivGeo2
										, DIRECCION_EMAIL
										, TELEFONO_RESIDENCIAL, TELEFONO_LABORAL, TELEFONO_CELULAR
										, TIPO_OBLIGACION, Moneda, IDENTIFICADOR_TIPOCUENTA
										, NUMERO_OBLIGACION, Fecha_de_Apertura, Fecha_de_Vencimiento, PERIODO_PAGO, ESTADO, SUB_ESTADO
										, CALIFICACION, DIAS_MORA, VALOR_LIMITE, VALOR_SALDO_TOTAL, VALOR_SALDO_MORA, VALOR_CUOTA, TIPO_DEUDOR
										, TIPO_GARANTIA, NUMERO_GARANTIA, VALOR_GARANTIA, DESCRIPCION
										, TASA_CAMBIO, MONTO_VENCIDO, MONTO_PAGADO, NUEVO_LIMITE, FECHA_DE_CASTIGO
								from @tData
								order by ROWID
								FOR JSON PATH
								)
					);
	end;


	set nocount off;

	if (@showResult = 1) select * from @tData;
	else select @batchKey as BatchKey, @batchDate as BatchDate;");

			builder.Sql(@"create or alter procedure dbo.sp_upgraddiagrams
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;

		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,

			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]

			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_'
			return 2;
		end
		return 1;
	END
go
exec sp_addextendedproperty 'microsoft_database_tools_support', 1, 'SCHEMA', 'dbo', 'PROCEDURE', 'sp_upgraddiagrams'
go");
        }

        protected override void Down(MigrationBuilder builder)
        {
			builder.Sql("drop function if exists fxBatchGetPhrases");
			builder.Sql("drop function if exists fxBatchGetGralList");
			builder.Sql("drop function if exists fxGetSmartCharFilter");
			builder.Sql("drop function if exists fxMDI_PersonsQry");
			builder.Sql("drop function if exists fxMDI_PersonsQryFull");
			builder.Sql("drop function if exists FxSaldoPrestamoListado");
			builder.Sql("drop function if exists fn_diagramobjects");
			builder.Sql("drop function if exists getOwnerEntityId");
			builder.Sql("drop function if exists getFirstPaymentDate");
			builder.Sql("drop function if exists fxGetSaldosxPrestamo");
			builder.Sql("drop function if exists fxL68_FixTextValue");
			builder.Sql("drop function if exists SaldosMigracion");
			builder.Sql("drop function if exists fxBatchGetTRANSUNION");
			builder.Sql("drop function if exists getQuoteValue");
			builder.Sql("drop function if exists fxBatchGetHeader");
			builder.Sql("drop function if exists fxBatchGetDetail");
			builder.Sql("drop function if exists fxBatchGetTotalTaxes");
			
			builder.Sql("drop proc if exists sp_job_calcularMora");
			builder.Sql("drop proc if exists sp_PlanPagos_CambioDeFechas");
			builder.Sql("drop proc if exists sp_upgraddiagrams");
			builder.Sql("drop proc if exists sp_helpdiagrams");
			builder.Sql("drop proc if exists sp_helpdiagramdefinition");
			builder.Sql("drop proc if exists sp_creatediagram");
			builder.Sql("drop proc if exists sp_renamediagram");
			builder.Sql("drop proc if exists sp_alterdiagram");
			builder.Sql("drop proc if exists sp_dropdiagram");
			builder.Sql("drop proc if exists sp_sct_payAllCurrentDebtAndCloseLoan");
			builder.Sql("drop proc if exists ReporteGeneralCreditos");
			builder.Sql("drop proc if exists sp_mig15_reasignarFechasPlanPagos");
			builder.Sql("drop proc if exists sp_rpt_CasosBTS");
			builder.Sql("drop proc if exists sp_sct_balanceRecalculator");
			builder.Sql("drop proc if exists ReporteContabilidad");
			builder.Sql("drop proc if exists sp_batchfile_generator");
			builder.Sql("drop proc if exists sp_sct_cuadrarUltimaCuota");
			builder.Sql("drop proc if exists sp_transunion__batchfile_generator");
			builder.Sql("drop proc if exists sp_pur20230309");
			builder.Sql("drop proc if exists sp_pur20230309_part2");

        }
    }
}
