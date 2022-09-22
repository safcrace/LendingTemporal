
using Core.Entities;
using Core.Entities.Functions;
using Core.Entities.Identity;
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

        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<DestinoPrestamo>? DestinoPrestamos { get; set; }
        public DbSet<DetallePlanPago>? DetallePlanPagos { get; set; }
        public DbSet<DetallePlanPagoTemporal>? DetallePlanPagoTemporales { get; set; }
        public DbSet<Empresa>? Empresas { get; set; }
        public DbSet<EstadoCivil>? EstadoCivil { get; set; }
        public DbSet<EstadoCuenta>? EstadoCuentas { get; set; }
        public DbSet<EstadoPlan>? EstadoPlanes { get; set; }
        public DbSet<EstadoPrestamo>? EstadoPrestamos { get; set; }
        public DbSet<Genero> Generos { get; set; } = null!;        
        public DbSet<Gestor> Gestores { get; set; } = null!;        
        public DbSet<Municipio>? Municipios { get; set; }       
        public DbSet<Pais>? Paises { get; set; }
        public DbSet<Persona>? Personas { get; set; }        
        public DbSet<PlanPago>? PlanPagos { get; set; }        
        public DbSet<Prestamo>? Prestamos { get; set; }        
        public DbSet<Relacion>? Relaciones { get; set; }        
        public DbSet<Sesion>? Sesiones { get; set; }        
        public DbSet<TipoBitacora>? TipoBitacoras { get; set; }        
        public DbSet<TipoPrestamo>? TipoPrestamos { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            Scalars.RegisterFunctions(modelBuilder);
        }
    }
}

/*
 *      dotnet ef migrations add OrderedEntityAdded -p Infrastructure -s API -c StoreContext
 *      dotnet ef migrations remove -p Infrastructure -s API -c StoreContext 
 *      dotnet ef database update -p infrastructure -s API
 */