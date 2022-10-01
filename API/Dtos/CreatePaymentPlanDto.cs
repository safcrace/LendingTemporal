using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreatePaymentPlanDto
    {
        [Required]
        public string AppUserId { get; set; } = null!;                
        [Required]
        public int PrestamoId { get; set; }
        public DateTime FechaPlan { get; set; } = DateTime.Now;        
        [Required]
        public byte Plazo { get; set; }
        [Required]
        public decimal TasaInteres { get; set; }
        [Required]
        public decimal TasaIva { get; set; }
        public decimal TasaMora { get; set; } = 0.0m;
        public decimal TasaGastos { get; set; } = 0.0m;
        public ICollection<CreatePaymentPlanDetailsDto> PlanPagos { get; set; } = new List<CreatePaymentPlanDetailsDto>();
    }
}
