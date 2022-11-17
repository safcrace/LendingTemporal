using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ReporteGeneralCreditos
    {
        public int IdPrestamo { get; set; }
        public string? Referencia { get; set; }
        public string? Nombre { get; set; }
        public decimal MontoOtorgado { get; set; }
        public decimal TasaInteres { get; set; }
        public byte Plazo { get; set; }
        public decimal DeudaTotal { get; set; }
        public decimal InteresProyectado { get; set; }
        public decimal IvaProyectado { get; set; }
        public int DiasMora { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoIvaIntereses { get; set; }
        public decimal SaldoMora { get; set; }
        public decimal SaldoIvaMora { get; set; }
        public string? Estado { get; set; }
    }
}
