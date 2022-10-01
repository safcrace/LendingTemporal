
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
        }

        public DbSet<AbonoPlan>? AbonoPlanes { get; set; }
        public DbSet<Banco>? Bancos { get; set; }
        public DbSet<Caja>? Cajas { get; set; }        
        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<DestinoPrestamo>? DestinoPrestamos { get; set; }        
        public DbSet<DetallePlanPagoTemporal>? DetallePlanPagoTemporales { get; set; }
        public DbSet<Entidad>? Entidades { get; set; }
        public DbSet<Empresa>? Empresas { get; set; }
        public DbSet<EstadoCivil>? EstadoCivil { get; set; }
        public DbSet<EstadoCuenta>? EstadoCuentas { get; set; }        
        public DbSet<EstadoPrestamo>? EstadoPrestamos { get; set; }
        public DbSet<FormaPago>? FormaPagos { get; set; }
        public DbSet<Genero> Generos { get; set; } = null!;                
        public DbSet<Municipio>? Municipios { get; set; }                   
        public DbSet<Pais>? Paises { get; set; }
        public DbSet<Persona>? Personas { get; set; }        
        public DbSet<PlanPago>? PlanPagos { get; set; }        
        public DbSet<Prestamo>? Prestamos { get; set; }        
        public DbSet<RegistroCaja>? RegistroCajas { get; set; }        
        public DbSet<RelacionEntidad>? RelacionEntidades { get; set; }        
        public DbSet<Sesion>? Sesiones { get; set; }        
        public DbSet<TipoBitacora>? TipoBitacoras { get; set; }        
        public DbSet<TipoPrestamo>? TipoPrestamos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            Scalars.RegisterFunctions(modelBuilder);

            modelBuilder.Entity<ListadoGeneral>().HasNoKey().ToView("v_sct_listadogeneral");
            modelBuilder.Entity<ListadoAsesor>().HasNoKey().ToView("v_mdi_lista__asesores");

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