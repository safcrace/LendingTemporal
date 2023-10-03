
using Core.Entities;
using Core.Entities.Functions;
using Core.Entities.Identity;
using Core.Entities.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(300);
        }

        public DbSet<AbonoPlan>? AbonoPlanes { get; set; }
        public DbSet<AplicacionPagos>? AplicacionPagos { get; set; }
        public DbSet<Banco>? Bancos { get; set; }
        public DbSet<Caja>? Cajas { get; set; }        
        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<DestinoPrestamo>? DestinoPrestamos { get; set; }        
        public DbSet<DetallePlanPagoTemporal>? DetallePlanPagoTemporales { get; set; }
        public DbSet<Entidad>? Entidades { get; set; }
        public DbSet<Empresa>? Empresas { get; set; }
        public DbSet<EstadoCivil>? EstadoCivil { get; set; }
        public DbSet<EstadoCuenta>? EstadoCuentas { get; set; }        
        public DbSet<EstadoCuentaPrestamo>? EstadoCuentaPrestamos { get; set; }        
        public DbSet<EstadoOrigen>? EstadosOrigen { get; set; }
        public DbSet<EstadoPrestamo>? EstadoPrestamos { get; set; }
        public DbSet<FormaPago>? FormaPagos { get; set; }
        public DbSet<Genero> Generos { get; set; } = null!;                
        public DbSet<ListadoGeneral>? ListadoGeneral { get; set; }                   
        public DbSet<Municipio>? Municipios { get; set; }                   
        public DbSet<Ocupacion>? Ocupaciones { get; set; }                   
        public DbSet<Pais>? Paises { get; set; }
        public DbSet<Persona>? Personas { get; set; }        
        public DbSet<PlanPago>? PlanPagos { get; set; }        
        public DbSet<Prestamo>? Prestamos { get; set; }        
        public DbSet<RegistroCaja>? RegistroCajas { get; set; }        
        public DbSet<RelacionEntidad>? RelacionEntidades { get; set; }        
        public DbSet<ReporteCasosBTS>? ReporteCasosBTS { get; set; }        
        public DbSet<Sesion>? Sesiones { get; set; }        
        public DbSet<TipoBitacora>? TipoBitacoras { get; set; }        
        public DbSet<TipoPrestamo>? TipoPrestamos { get; set; }
        public DbSet<TipoTransaccion>? TipoTransaccion { get; set; }
        public DbSet<TipoVivienda>? TiposVivienda { get; set; }

        public IQueryable<SaldosMigracion> SaldosMigracion(int prestamoId)
        {
            return FromExpression(() => SaldosMigracion(prestamoId));
        }

        public IQueryable<Encabezado> fxBatchGetHeader(string batchKey, DateTime batchDate)
        {
            return FromExpression(() => fxBatchGetHeader(batchKey, batchDate));
        }

        public IQueryable<Detalle> fxBatchGetDetail(string batchKey, DateTime batchDate)
        {
            return FromExpression(() => fxBatchGetDetail(batchKey, batchDate));
        }

        public IQueryable<TotalImpuestos> fxBatchGetTotalTaxes(string batchKey, DateTime batchDate)
        {
            return FromExpression(() => fxBatchGetTotalTaxes(batchKey, batchDate));
        }

        public IQueryable<Frases> fxBatchGetPhrases(string batchKey, DateTime batchDate)
        {
            return FromExpression(() => fxBatchGetPhrases(batchKey, batchDate));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            Scalars.RegisterFunctions(modelBuilder);

            modelBuilder.Entity<ListadoGeneral>().HasNoKey().ToView("v_sct_listadogeneral");
            modelBuilder.Entity<ListadoAsesor>().HasNoKey().ToView("v_mdi_lista__asesores");
            modelBuilder.Entity<ListadoEmpresaPlanilla>().HasNoKey().ToView("v_mdi_lista__empresas_con_planilla");
            modelBuilder.Entity<AplicacionPagos>().HasNoKey().ToView(null);
            modelBuilder.Entity<EstadoCuentaPrestamo>().HasNoKey().ToView("VEstadoCuenta");
            modelBuilder.Entity<ReporteGeneralCreditos>().ToSqlQuery(@"Exec ReporteGeneralCreditos");            
            //modelBuilder.Entity<AplicacionPagos>().ToSqlQuery(@"Exec ReporteContabilidad '2022-11-01', '2022-11-16'  ");            
            modelBuilder.Entity<BatchFile>().ToSqlQuery(@"Exec sp_batchfile_generator");            
            modelBuilder.Entity<ReporteTransUnion>().ToSqlQuery(@"Exec sp_transunion__batchfile_generator");            
            modelBuilder.Entity<ReporteQuickSights>().ToSqlQuery(@"sp_reporte_moras_completo");            
            modelBuilder.Entity<ReporteCasosBTS>().ToSqlQuery(@"declare @tAcum table (
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
		, IsNull((Select Top 1 TotalCuota from PlanPagos where PrestamoId = pre.Id and Aplicado = 0), 0) as CuotaCalculada --Ajuste relizado por SAFC el 17/02/2023	:: 29/09/2023	
		, convert(date, pre.FechaAprobacion) as FechaAprobacion
		, IsNull(convert(date, pre.FechaAprobacion), convert(date, pre.FechaDesembolso)) as FechaDesembolso
		, IsNull(ppl.PROXIMO_PAGO, '0001-01-01') as ProximoPago
		, IsNull(ppl2.PRIMER_PAGO, '0001-01-01') as FechaPrimerPago
		, IsNull(ppl2.ULTIMO_PAGO, '0001-01-01') as FechaVencimiento
		, IsNull(pagadu.Nombre, ' ') as [Pagaduría]
		, tp.Nombre as TipoPrestamo
		, SaldoTotal = IsNull((select Sum(SaldoCapital + SaldoIntereses + SaldoIvaIntereses + SaldoMora + SaldoIVaMora) From PlanPagos where prestamoId = pre.Id and FechaPago < GETDATE()),0)
		, CuotasPendientes = IsNull((Select count(Id) From PlanPagos where PrestamoId = pre.Id And Aplicado = 0 and FechaPago < GETDATE()),0)
		, IsNull(mdi.Telefono, '') as Telefono
		, IsNull(mdi.Direccion, '') as Direccion
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
		pre.EstadoPrestamoId = 1 or pre.EstadoPrestamoId = 7 or pre.EstadoPrestamoId = 8
	order by pre.Id;
	
	set nocount off");

            modelBuilder.Entity<SaldosMigracion>().HasNoKey().ToTable(name: null);
			modelBuilder.Entity<Encabezado>().HasNoKey().ToView(null);
			modelBuilder.Entity<Detalle>().HasNoKey().ToView(null);
			modelBuilder.Entity<TotalImpuestos>().HasNoKey().ToView(null);
			modelBuilder.Entity<Frases>().HasNoKey().ToView(null);

            modelBuilder.HasDbFunction(() => SaldosMigracion(0));
            modelBuilder.HasDbFunction(() => fxBatchGetHeader("",DateTime.Now));
            modelBuilder.HasDbFunction(() => fxBatchGetDetail("",DateTime.Now));
            modelBuilder.HasDbFunction(() => fxBatchGetTotalTaxes("",DateTime.Now));
            modelBuilder.HasDbFunction(() => fxBatchGetPhrases("",DateTime.Now));

            modelBuilder.Entity<AbonoPlan>().HasKey(pp => new { pp.EstadoCuentaId, pp.PlanPagoId });
            modelBuilder.Entity<AbonoPlan>().
                HasOne(pp => pp.EstadoCuenta).WithMany(pp => pp.AbonoPlanes).HasForeignKey(t => t.EstadoCuentaId);
            modelBuilder.Entity<AbonoPlan>().
                HasOne(tt => tt.PlanPago).WithMany(tt => tt.AbonoPlanes).HasForeignKey(t => t.PlanPagoId);
                //.OnDelete(DeleteBehavior.NoAction);
        }
    }
}

/*
 *      dotnet ef migrations add OrderedEntityAdded -p Infrastructure -s API -c StoreContext
 *      dotnet ef migrations remove -p Infrastructure -s API -c StoreContext 
 *      dotnet ef database update -p infrastructure -s API
 */