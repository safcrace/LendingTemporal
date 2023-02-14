namespace Core.Entities.Views
{
    public class EstadoCuentaPrestamo
    {
        public int PrestamoId { get; set; }
        public int TipoTransaccionId { get; set; }
        public Decimal Cargo { get; set; }
        public Decimal Abono { get; set; }
        public Decimal SaldoAnterior { get; set; }
        public Decimal SaldoActual { get; set; }
        public string? Concepto { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
