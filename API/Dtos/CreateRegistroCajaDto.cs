namespace API.Dtos
{
    public class CreateRegistroCajaDto
    {
        public string AppUserId { get; set; } = string.Empty;
        public int BancoId { get; set; }
        public int CajaId { get; set; }
        public int FormaPagoId { get; set; }
        public int PrestamoId { get; set; }
        public DateTime? FechaTransaccion { get; set; } = DateTime.Now;
        public DateTime? FechaDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public int DiasMora { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoInteres { get; set; }
        public decimal MontoIvaIntereses { get; set; }
        public decimal MontoMora { get; set; }
        public decimal MontoMoraIntereses { get; set; }
        public decimal MontoGastos { get; set; }
        public decimal MontoIvaGastos { get; set; }
        public decimal MontoCapitalAnticipado { get; set; }
        public int CuotasAdelantadas { get; set; }
        public int CuotasVencidas { get; set; }
        public decimal TotalCuotasVencidas { get; set; }
        public string? Observaciones { get; set; }
        public string? MotivoAnulacion { get; set; }
    }
}
