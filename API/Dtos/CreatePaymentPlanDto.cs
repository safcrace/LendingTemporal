using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreatePaymentPlanDto
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
        public DateTime StartDate { get; set; }
    }
}
