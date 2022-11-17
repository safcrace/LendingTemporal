namespace API.Dtos
{
    public class CreateRegistroCajaDto
    {
        public string AppUserId { get; set; } = string.Empty;
        public int BancoId { get; set; } = 1;
        public int CajaId { get; set; } = 1;
        public int FormaPagoId { get; set; } = 2;
        public int PrestamoId { get; set; }
        public int TipoTransaccionId { get; set; }
        public int PlanPagoId { get; set; }
        public DateTime? FechaTransaccion { get; set; } = DateTime.Now;
        public DateTime? FechaDocumento { get; set; } = null;
        public string? NumeroDocumento { get; set; }
        public int DiasMora { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoInteres { get; set; }
        public decimal MontoIvaIntereses { get; set; }
        public decimal MontoMora { get; set; } = 0.00m;
        public decimal MontoIvaMora { get; set; } = 0.00m;
        public decimal MontoGastos { get; set; } = 0.00m;
        public decimal MontoIvaGastos { get; set; } = 0.00m;
        public decimal MontoCapitalAnticipado { get; set; } = 0.00m;
        public int CuotasAdelantadas { get; set; } = 0;  
        public int CuotasVencidas { get; set; } = 0;
        public decimal TotalCuotasVencidas { get; set; } = 0;
        public string? Observaciones { get; set; }
        public string? MotivoAnulacion { get; set; }
    }
}
