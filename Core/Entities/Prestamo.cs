using Core.Entities.Identity;
using System.Security.Cryptography;

namespace Core.Entities
{
    public class Prestamo : BaseEntity
    {
        public string? ReferenciaMigracion { get; set; }
        public AppUser? AppUser { get; set; }
        public string AppUserId { get; set; } = null!;
        public Entidad? EntidadPrestamo { get; set; }
        public int? EntidadPrestamoId { get; set; }
        public EstadoPrestamo? EstadoPrestamo { get; set; }
        public int? EstadoPrestamoId { get; set; }
        public EstadoOrigen? EstadoOrigen { get; set; }
        public int? EstadoOrigenId { get; set; }
        public ProductoInteresado? ProductoInteresado { get; set; }
        public int? ProductoInteresadoId { get; set; }
        public MontoInteresado? MontoInteresado { get; set; }
        public int? MontoInteresadoId { get; set; }
        public CanalIngreso? CanalIngreso { get; set; }
        public int? CanalIngresoId { get; set; }
        public DestinoPrestamo? DestinoPrestamo { get; set; }
        public int? DestinoPrestamoId { get; set; }
        public TipoPrestamo? TipoPrestamo { get; set; }
        public int? TipoPrestamoId { get; set; }
        public Entidad? GestorPrestamo { get; set; }
        public int? GestorPrestamoId { get; set; }
        public Entidad? AnalistaPrestamo { get; set; }
        public int? AnalistaPrestamoId { get; set; }
        public Entidad? EmpresaPrestamo { get; set; }
        public int? EmpresaPrestamoId { get; set; }
        public OrigenSolicitud? OrigenSolicitud { get; set; }
        public int? OrigenSolicitudId { get; set; }
        public MotivoRechazo? MotivoRechazo { get; set; }
        public int? MotivoRechazoId { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaDesembolso { get; set; }
        public decimal MontoRealSolicitado { get; set; }        
        public decimal MontoOtorgado { get; set; }
        public decimal InteresProyectado { get; set; }
        public decimal IvaProyectado { get; set; }
        public decimal GastosProyectados { get; set; }
        public decimal MontoTotalProyectado { get; set; }
        public byte Plazo { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal TasaIva { get; set; }
        public decimal TasaMora { get; set; }
        public decimal TasaGastos { get; set; }
        public int DiasMora { get; set; }
        public DateTime? FechaPlan { get; set; }
        public string? TokenAutorización { get; set; }
        public string? ObjetivoCredito { get; set; }
        public int? CarpetaSidId { get; set; }
        public List<BitacoraPrestamo> BitacoraPrestamos { get; set; } = new List<BitacoraPrestamo>();
    }
}
