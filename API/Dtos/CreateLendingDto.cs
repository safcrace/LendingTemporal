using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateLendingDto
    {
        [Required]
        public string AppUserId { get; set; }
        public int PersonaId { get; set; }
        public int GestorId { get; set; }
        public int EstadoPrestamoId { get; set; }
        public int DestinoPrestamoId { get; set; }
        public int TipoPrestamoId { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoIva { get; set; }
        public decimal SaldoGastosAdministrativos { get; set; }
        public decimal SaldoMora { get; set; }
        public CreatePersonDto CreatePersonDto { get; set; } = new CreatePersonDto();
    }
}
