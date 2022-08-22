using Core.Entities.Identity;

namespace Core.Entities
{
    public class PlanPago : BaseEntity
    {
        public AppUser AppUser { get; set; } = new();
        public string AppUserId { get; set; } = null!;
        public EstadoPlan EstadoPlan { get; set; } = new();
        public int EstadoPlanId { get; set; }
        public Prestamo Prestamo { get; set; } = new();
        public int PrestamoId { get; set; }
        public DateTime FechaPlan { get; set; }
        public decimal MontoPlan { get; set; }
        public decimal MontoCapital { get; set; }
        public byte Plazo { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal TasaIva { get; set; }
        public decimal TasaGastosAdministrativos { get; set; }
        public decimal TasaMora { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoGastosAdministrativos { get; set; }
        public decimal SaldoIva { get; set; }


    }
}
