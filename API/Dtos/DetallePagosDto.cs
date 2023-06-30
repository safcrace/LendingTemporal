namespace API.Dtos
{
    public class DetallePagosDto
    {
        public string? AppUserId { get; set; }
        public int BancoId { get; set; }
        public int CajaId { get; set; } = 1;
        public int FormaPagoId { get; set; }
        public int PrestamoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoIntereses { get; set; }
        public decimal MontoIvaIntereses { get; set; }
        public decimal MontoMora { get; set; }
        public decimal MontoIvaMora { get; set; }
        public string Observaciones { get; set; } = "Pago Planilla";
    }
}

