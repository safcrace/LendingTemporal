using Core.Entities.Identity;
using System.Buffers.Text;

namespace Core.Entities
{
    public class EstadoCuenta : BaseEntity
    {
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public Prestamo? Prestamo { get; set; }
        public int PrestamoId { get; set; }
        public RegistroCaja? RegistroCaja { get; set; }
        public int? RegistroCajaId { get; set; }
        public TipoTransaccion? TipoTransaccion { get; set; }
        public int TipoTransaccionId { get; set; }
        public decimal Cargo { get; set; }
        public decimal Abono { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoActual { get; set; }
        public string? Concepto { get; set; }
        public ICollection<AbonoPlan> AbonoPlanes { get; set; } = new List<AbonoPlan>();
    }
}
