using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Views : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            builder.Sql(@"CREATE or alter view VEstadoCuenta As
Select
	ec.PrestamoId,
	ec.TipoTransaccionId,
	ec.Cargo,
	ec.Abono,
	ec.SaldoAnterior,
	ec.SaldoActual,
	ec.Concepto,
	FechaCreacion = Case When rc.FechaPago is not null Then rc.FechaPago
						 Else ec.FechaCreacion
					End
From
	EstadoCuentas as ec
Left Join
	RegistroCajas as rc
On
	rc.Id = ec.RegistroCajaId");

            builder.Sql(@"CREATE or alter view v_mdi_general_full as
	select a.Id as EntidadId, c.Id as PersonaId, d.Id as EmpresaId,
			a.TipoEntidadId, b.Descripcion as TipoEntidad,
			replace(
					trim(
							case
								when b.Descripcion = 'Persona'
										then
											case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end
											+ case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end
											+ case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end
											+ case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end
											+ case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end
								else d.Nombre
							end
					)
					, '  ', ' '
			) as Nombre

			, trim(case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end		) as  PrimerNombre
			, trim(case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end		) as  SegundoNombre
			, trim(case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end	) as  PrimerApellido
			, trim(case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end	) as  SegundoApellido
			, trim(case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end	) as  ApellidoCasada

			, isnull(c.Direccion, d.Direccion) as Direccion
			, isnull(c.NumeroTelefono, d.Telefono) as Telefono
			, isnull(c.Email, d.Email) as Email

			, c.NumeroDocumento as DPI
			, isnull(c.NIT, d.Nit) as NIT
			, c.FechaNacimiento
			, a.Habilitado
	from Entidades a
		inner join TipoEntidad b on b.Id = a.TipoEntidadId
		left outer join Personas c on c.EntidadId = a.Id
		left outer join Empresas d on d.EntidadId = a.Id;");

            builder.Sql(@"CREATE or alter view v_mdi_general_simple as
	select a.Id as EntidadId, c.Id as PersonaId, d.Id as EmpresaId,
			a.TipoEntidadId, b.Descripcion as TipoEntidad,
			case
				when b.Descripcion = 'Persona'
					then
							case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end
							+ case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end
							+ case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end
							+ case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end
							+ case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end
				else d.Nombre
			end as Nombre
			, trim(case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end		) as  PrimerNombre
			, trim(case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end		) as  SegundoNombre
			, trim(case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end	) as  PrimerApellido
			, trim(case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end	) as  SegundoApellido
			, trim(case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end	) as  ApellidoCasada

			, a.Habilitado
	from Entidades a
		inner join TipoEntidad b on b.Id = a.TipoEntidadId
		left outer join Personas c on c.EntidadId = a.Id
		left outer join Empresas d on d.EntidadId = a.Id;");
            
            builder.Sql(@"CREATE or alter view v_mdi_personas_simple as
	select c.Id,
			c.EntidadId,
			case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end
				+ case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end
				+ case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end
				+ case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end
				+ case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end
				as Nombre

			, trim(case when c.PrimerNombre is null then '' else ' ' + c.PrimerNombre end		) as  PrimerNombre
			, trim(case when c.SegundoNombre is null then '' else ' ' + c.SegundoNombre end		) as  SegundoNombre
			, trim(case when c.PrimerApellido is null then '' else ' ' + c.PrimerApellido end	) as  PrimerApellido
			, trim(case when c.SegundoApellido is null then '' else ' ' + c.SegundoApellido end	) as  SegundoApellido
			, trim(case when c.ApellidoCasada is null then '' else ' ' + c.ApellidoCasada end	) as  ApellidoCasada
			, c.Habilitado
	from Personas c;");

            builder.Sql(@"CREATE or alter view v_mdi_lista__asesores as
	select c.EntidadId, c.Id as PersonaId, c.Nombre
	from TipoRelacion a
		inner join RelacionEntidades b on b.EntidadPadreId = 1 /* SINFIN PROPIETARIO DEL SISTEMA */
										and b.TipoRelacionId = a.Id
										and b.Habilitado = 1
		inner join v_mdi_personas_simple c on c.EntidadId = b.EntidadHijaId
	where a.Descripcion = 'Asesor';");

            builder.Sql(@"CREATE or alter view v_mdi_lista__empresas_con_planilla as
	select c.EntidadId, c.EmpresaId, c.Nombre
	from TipoRelacion a
		inner join RelacionEntidades b on b.EntidadPadreId = 1 /* SINFIN PROPIETARIO DEL SISTEMA */
										and b.TipoRelacionId = a.Id
										and b.Habilitado = 1
		inner join v_mdi_general_simple c on c.EntidadId = b.EntidadHijaId
	where a.Descripcion = 'Empresa con planilla';");

            builder.Sql(@"CREATE or alter view v_mdi_personas_full as
	select a.Id,
			a.EntidadId,
			case when a.PrimerNombre is null then '' else ' ' + a.PrimerNombre end
				+ case when a.SegundoNombre is null then '' else ' ' + a.SegundoNombre end
				+ case when a.PrimerApellido is null then '' else ' ' + a.PrimerApellido end
				+ case when a.SegundoApellido is null then '' else ' ' + a.SegundoApellido end
				+ case when a.ApellidoCasada is null then '' else ' ' + a.ApellidoCasada end
			as Nombre,
			case when a.PrimerNombre is null then '' else ' ' + a.PrimerNombre end
				+ case when a.SegundoNombre is null then '' else ' ' + a.SegundoNombre end as Nombres

			, case when a.PrimerApellido is null then '' else ' ' + a.PrimerApellido end
				+ case when a.SegundoApellido is null then '' else ' ' + a.SegundoApellido end as Apellidos
			, a.ApellidoCasada

			, a.PrimerNombre, a.SegundoNombre, a.PrimerApellido, a.SegundoApellido

			, a.FechaNacimiento, a.Email, a.Direccion, a.NIT, a.NumeroTelefono,
			a.NumeroDocumento as DPI,
			b.Descripcion as EstadoCivil,
			c.Descripcion as Genero, a.Habilitado
	from Personas a
		left outer join EstadoCivil b on b.Id = a.EstadoCivilId
		left outer join Generos c on c.Id = a.GeneroId;");
            
            builder.Sql(@"CREATE or alter view v_rev20230227__personasRepeXNIT as
	select z.NIT, z.N as REPETICIONES
			, y.EntidadId, y.PersonaId
			, y.TipoEntidad
			, y.Nombre
			, y.PrimerNombre, y.SegundoNombre, y.PrimerApellido, y.SegundoApellido, y.ApellidoCasada
			, y.Direccion, y.Telefono, y.Email, y.DPI, y.FechaNacimiento, y.Habilitado
	from (
				select	replace(replace(NIT, ' ', ''), '-', '') as NIT
						, COUNT(*) as N
				from v_mdi_general_full
				where not NIT is null
						and not replace(replace(NIT, ' ', ''), '-', '') = ''
						and not TRIM(upper(NIT)) in ( 'PENDIENTE', 'CF')
				group by replace(replace(NIT, ' ', ''), '-', '')
				having COUNT(*) > 1
			) z

			inner join v_mdi_general_full y on  replace(replace(y.NIT, ' ', ''), '-', '') = z.NIT;");
            
            builder.Sql(@"-- [1] Listado de personas cuyo DPI está más de una vez.
-- IMPORTANTE 1/3: No se toman en cuenta casos en que DPI es nulo.
-- IMPORTANTE 2/3: No se toman en cuenta casos en que DPI es 'NoDisponible'
-- IMPORTANTE 3/3: Para la búsqueda de DPIs repetidos se aplica un reemplazo de 'espacios' y 'guiones' por vacíos.
CREATE or alter view v_rev20230227__personasRepeXDPI as
	select z.DPI, z.N as REPETICIONES
			, y.EntidadId, y.PersonaId
			, y.TipoEntidad
			, y.Nombre
			, y.PrimerNombre, y.SegundoNombre, y.PrimerApellido, y.SegundoApellido, y.ApellidoCasada
			, y.Direccion, y.Telefono, y.Email, y.NIT, y.FechaNacimiento, y.Habilitado
	from (
				select	replace(replace(DPI, ' ', ''), '-', '') as DPI
						, COUNT(*) as N
				from v_mdi_general_full
				where not DPI is null
						and not replace(replace(DPI, ' ', ''), '-', '') = 'NoDisponible'
				group by replace(replace(DPI, ' ', ''), '-', '')
				having COUNT(*) > 1
			) z

			inner join v_mdi_general_full y on  replace(replace(y.DPI, ' ', ''), '-', '') = z.DPI;");
            
            builder.Sql(@"CREATE or alter view v_rev20230227__personasConMasDeUnPrestamoXNombre as
	select REPLACE(b.Nombre, ' ', '') as NOMBRE_SIN_ESPACIOS, COUNT(*) as PRESTAMOS
	from Prestamos a
		inner join v_mdi_general_full b on b.EntidadId = a.EntidadPrestamoId
	group by REPLACE(b.Nombre, ' ', '') having COUNT(*) > 1;");
            
            builder.Sql(@"CREATE or alter view v_rev20230227__personasConRepeticion_fullmosh as
	select EntidadId, PersonaId from v_rev20230227__personasRepeXNIT
	union select EntidadId, PersonaId from v_rev20230227__personasRepeXDPI
	union select b.EntidadId, b.PersonaId from v_rev20230227__personasConMasDeUnPrestamoXNombre a 	inner join v_mdi_general_full b on  REPLACE(b.Nombre, ' ', '')= a.NOMBRE_SIN_ESPACIOS");

            builder.Sql(@"CREATE or alter view v_rev20230227__consultaFullmoshN1 as
	select pp.EntidadId, pp.Id as PersonaId
			, '' as REF_A_PersonaId
			, 'N' as ELEGIDO
			, b.Nombre as DEUDOR, ep.Descripcion as EstadoPrestamo
			-- ,  p.*
			, pp.PrimerNombre, pp.SegundoNombre, pp.PrimerApellido, pp.SegundoApellido, pp.ApellidoCasada, pp.FechaNacimiento, pp.Email

			, pp.Direccion, pp.Colonia, pp.DepartamentoId, pp.MunicipioId, pp.TipoViviendaId

			, pp.NumeroDocumento, pp.NIT, pp.PaisNacimientoId

			, pp.NumeroTelefono, pp.NumeroCelular
			, pp.DireccionLaboral, pp.NumeroTelefonoLaboral

			, pp.OcupacionId
			, pp.Comentarios

			, pp.FechaCreacion, pp.FechaModificacion, pp.Habilitado

	from v_rev20230227__personasConRepeticion_fullmosh a
		inner join v_mdi_general_full b on  b.PersonaId = a.PersonaId
		left outer join Prestamos p on p.EntidadPrestamoId = b.EntidadId
		left outer join EstadoPrestamos ep on ep.Id = p.EstadoPrestamoId
		inner join Personas pp on pp.Id = b.PersonaId;");

            builder.Sql(@"CREATE or alter view v_sct_listadogeneral as
	select	a.Id
			, a.EntidadPrestamoId as EntidadId
			, g.Id as TipoEntidadId
			, g.Descripcion as TipoEntidad
            , isnull(a.ReferenciaMigracion, '') As ReferenciaMigracion
			, b.Descripcion as Estatus
			, isnull(c.DPI, '') As DPI
			, isnull(c.NIT, '') As NIT
			, c.Nombre
            , c.Telefono
			, a.MontoTotalProyectado as SaldoInicial
			, isnull(e.SaldoActual, 0.00)  as SaldoActual, d.Nombre as Asesor
			, a.Habilitado
	from Prestamos a
		inner join EstadoPrestamos b on b.Id = a.EstadoPrestamoId
		inner join v_mdi_general_full c on c.EntidadId = a.EntidadPrestamoId
		inner join v_mdi_personas_simple d on d.EntidadId = a.GestorPrestamoId
		left outer join (
							select PrestamoId, sum(isnull(Cargo, 0.00) - isnull(Abono, 0.00)) as SaldoActual
							from EstadoCuentas
							group by PrestamoId

						) e on e.PrestamoId = a.Id
		inner join Entidades f on f.Id = a.EntidadPrestamoId
		inner join TipoEntidad g on g.Id = f.TipoEntidadId;

		-- select * from v_sct_listadogeneral");

            builder.Sql(@"CREATE or alter view v_sct_listadogeneral_deudores as
	select a.EntidadId, a.TipoEntidadId, a.NIT, IsNull(a.DPI, '') as DPI, a.Nombre, IsNull(a.Telefono, '') as Telefono
	from v_mdi_general_full a
		inner join (	select distinct EntidadPrestamoId as EntidadId
						from Prestamos
				) b on b.EntidadId = a.EntidadId;");
        }

        protected override void Down(MigrationBuilder builder)
        {
			builder.Sql("DROP VIEW IF EXISTS dbo.VEstadoCuenta;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_general_full;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_general_simple;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_lista__asesores;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_lista__empresas_con_planilla;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_personas_full;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_mdi_personas_simple;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_rev20230227__consultaFullmoshN1;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_rev20230227__personasConMasDeUnPrestamoXNombre;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_rev20230227__personasConRepeticion_fullmosh;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_rev20230227__personasRepeXDPI;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_rev20230227__personasRepeXNIT;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_sct_listadogeneral;");
			builder.Sql("DROP VIEW IF EXISTS dbo.v_sct_listadogeneral_deudores;");
        }
    }
}
