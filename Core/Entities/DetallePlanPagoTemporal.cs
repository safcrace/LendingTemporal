namespace Core.Entities
{
    public class DetallePlanPagoTemporal
    {
        public int Id { get; set; }
        public string? PlanPagoId { get; set; }
        public int Mes { get; set; }
        public decimal CuotaCapital { get; set; }
        public decimal CuotaIntereses { get; set; }
        public decimal CuotaGastosAdministrativos { get; set; }
        public decimal CuotaIvaIntereses { get; set; }        
        public decimal TotalCuota { get; set; }
        public decimal SaldoCapital { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
