using Core.Entities.Identity;

namespace Core.Entities
{
    public class Desembolso : BaseEntity
    {
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public Prestamo? Prestamo { get; set; }
        public int? PrestamoId { get; set; }
        public Banco? Banco { get; set; }
        public int? BancoId { get; set; }
        public MedioDesembolso? MedioDesembolso { get; set; }
        public int? MedioDesembolsoId { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public int? TipoCuentaId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string?  NombreEmisionCheque { get; set; }
        public decimal CantidadDesembolso { get; set; }
    }
}
