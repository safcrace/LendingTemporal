namespace API.Dtos
{
    public class ObtenerSaldosDto
    {
        public decimal SaldoCapital { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoIvaInteres { get; set; }
        public decimal SaldoMora { get; set; }
        public decimal SaldoIvaMora { get; set; }
        public decimal TotalSaldo { get; set; }
    }
}