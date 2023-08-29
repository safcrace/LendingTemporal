using Core.Entities.Identity;

namespace Core.Entities
{
    public class BitacoraFicha : BaseEntity
    {
        public Entidad? Entidad { get; set; }
        public int? EntidadId { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUserAuthorized { get; set; }
        public string? AppUserAuthorizedId { get; set; }       
        public string? Comentarios { get; set; }        
    }
}
