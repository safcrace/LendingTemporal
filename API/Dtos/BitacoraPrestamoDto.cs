namespace API.Dtos
{
    public class BitacoraPrestamoDto
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }        
        public string? AppUserId { get; set; }
        public string? NombreUsuario { get; set; }
        public int? EstadoPrestamoId { get; set; }        
        public int? NuevoEstadoPrestamoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? Comentarios { get; set; }
        public byte TimeInStatus { get; set; }
        public bool CambioEstado { get; set; }
    }
}
