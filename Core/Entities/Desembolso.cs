using Core.Entities.Identity;

namespace Core.Entities
{
    public class Desembolso : BaseEntity
    {
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public Prestamo? Prestamo { get; set; }
        public int? PrestamoId { get; set; }
        public decimal MontoDesembolso { get; set; }
        public string? AprobacionCreditos { get; set; }
        public string? AprobacionDireccion { get; set; }
        public string? AprobacionGerencia { get; set; }
    }
}
