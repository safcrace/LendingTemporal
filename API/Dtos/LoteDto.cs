using Core.Entities.Identity;

namespace API.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public byte TotalCreditos { get; set; }
        public string? GeneradoPor { get; set; }
        public string? TipoLote { get; set; }
        public bool Aprobado { get; set; }
        public bool Habilitado { get; set; }
    }
}
