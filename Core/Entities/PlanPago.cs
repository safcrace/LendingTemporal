using Core.Entities.Identity;

namespace Core.Entities
{
    public class PlanPago : BaseEntity
    {
        public Prestamo? Prestamo { get; set; }
        public int PrestamoId { get; set; }
        public RegistroCaja? RegistroCaja { get; set; }
        public int? RegistroCajaId { get; set; }
        public int Periodo { get; set; }
        public decimal CuotaCapital { get; set; }
        public decimal CuotaIntereses { get; set; }
        public decimal CuotaIvaIntereses { get; set; }
        public decimal CuotaMora { get; set; }
        public decimal CuotaIvaMora { get; set; }
        public decimal CuotaGastos { get; set; }
        public decimal CuotaIvaGastos { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoIvaIntereses { get; set; }
        public decimal SaldoMora { get; set; }
        public decimal SaldoIvaMora { get; set; }
        public decimal SaldoGastos { get; set; }
        public decimal SaldoIvaGastos { get; set; }
        public decimal TotalCuota { get; set; }        
        public decimal SaldoTotal { get; set; }        
        public DateTime FechaPago { get; set; }
        public bool Aplicado { get; set; }        
        public ICollection<AbonoPlan> AbonoPlanes { get; set; } = new List<AbonoPlan>();
    }
}
