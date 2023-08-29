namespace API.Dtos
{
    public class CreaterBitacoraPrestamoDto
    {        
        public int PrestamoId { get; set; }      
        public string? AppUserId { get; set; }        
        public int? EstadoPrestamoId { get; set; }        
        public int? NuevoEstadoPrestamoId { get; set; }
        public string? Comentarios { get; set; }
        public byte TimeInStatus { get; set; } = 0;
        public bool CambioEstado { get; set; } = false;
    }
}
