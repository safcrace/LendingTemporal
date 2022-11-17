using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreatePaymentPlanTemporalDto
    {
        [Required]
        public decimal PrincipalAmount { get; set; }
        [Required]
        public decimal InterestRate { get; set; }
        [Required]
        public int Term { get; set; }
        public decimal AdministrativeExpesesRate { get; set; } 
        public decimal TaxRate { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime PayDate { get; set; }
    }
}
