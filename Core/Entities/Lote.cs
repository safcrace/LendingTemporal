using Core.Entities.Identity;

namespace Core.Entities
{
    public class Lote : BaseEntity
    {        
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }       
        public byte TotalCreditos { get; set; }
        public string? TipoLote { get; set; }
        public bool Aprobado { get; set; }
        public List<DetalleLote>? DetalleLotes { get; set; } = new List<DetalleLote>();
    }
}
