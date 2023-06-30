using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ReporteQuickSights
    {
        public int IdPrestamo { get; set; }
        public string? Referencia { get; set; }
        public string? Nombre { get; set; }
        public string? Gestor { get; set; }
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
        public decimal CuotaCalculada { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public DateTime ProximoPago { get; set; }
        public DateTime FechaPrimerPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string? Pagaduría { get; set; }
        public string? TipoPrestamo { get; set; }
        public decimal SaldoTotal { get; set; }
        public int CuotasPendientes { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
