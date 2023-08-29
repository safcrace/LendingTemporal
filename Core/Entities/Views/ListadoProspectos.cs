using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ListadoProspectos
    {
        public int SolicitudId { get; set; }
        public int EntidadId { get; set; }
        public int TipoEntidadId { get; set; }
        public string? TipoEntidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string? NombreProspecto { get; set; }
        public string? DPI { get; set; }
        public string? NIT { get; set; }
        public string? Telefono { get; set; }
        public string? NumeroCelular { get; set; }
        public int CanalId { get; set; }
        public string? CanalNombre { get; set; }
        public int EstadoPrestamoId { get; set; }
        public string? Estado { get; set; }
        public string? AppUserId { get; set; }
        public int GestorAsignadoId { get; set; }
        public string? Direccion { get; set; }
        public int TiempoEnEstado { get; set; }
        public string? NombreAsesor { get; set; }
        public int? AnalistaAsignadoId { get; set; }
        public string? NombreAnalista { get; set; }
        public int TipoPrestamoId { get; set; }
    }
}
