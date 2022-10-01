using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreatePaymentPlanDetailsDto
    {        
        public int PrestamoId { get; set; }
        [Required]
        public int Periodo { get; set; }
        [Required]
        public decimal CuotaCapital { get; set; }
        [Required]
        public decimal CuotaIntereses { get; set; }
        [Required]
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
        [Required]
        public decimal TotalCuota { get; set; }
        [Required]
        public decimal SaldoTotal { get; set; }
        [Required]
        public DateTime FechaPago { get; set; }
        public bool Aplicado { get; set; } = false;
    }
}
