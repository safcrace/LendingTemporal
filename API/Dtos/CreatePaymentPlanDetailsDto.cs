using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreatePaymentPlanDetailsDto
    {        
        public int PlanPagoId { get; set; }
        [Required]
        public decimal Mes { get; set; }
        [Required]
        public decimal CuotaCapital { get; set; }
        [Required]
        public decimal CuotaIntereses { get; set; }
        public decimal CuotaGastosAdministrativos { get; set; }
        [Required]
        public decimal CuotaIva { get; set; }
        [Required]
        public decimal TotalCuota { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public DateTime FechaPago { get; set; }
        public bool Aplicado { get; set; } = false;
    }
}
