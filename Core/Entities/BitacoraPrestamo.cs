using Core.Entities.Identity;

namespace Core.Entities
{
    public class BitacoraPrestamo : BaseEntity
    {
        public Prestamo? Prestamo { get; set; }
        public int PrestamoId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public EstadoPrestamo? EstadoPrestamo { get; set; }
        public int? EstadoPrestamoId { get; set; }
        public EstadoPrestamo? NuevoEstadoPrestamo { get; set; }
        public int? NuevoEstadoPrestamoId { get; set; }
        public string? Comentarios { get; set; }
        public byte TimeInStatus { get; set; }
        public bool CambioEstado { get; set; } 
    }
}
