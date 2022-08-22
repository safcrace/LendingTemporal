namespace Core.Entities
{
    public class DetallePlanPago : BaseEntity
    {
        public PlanPago PlanPago { get; set; } = new();
        public int PlanPagoId { get; set; }
        public int Mes { get; set; }
        public decimal CuotaCapital { get; set; }
        public decimal CuotaIntereses { get; set; }
        public decimal CuotaGastosAdministrativos { get; set; }
        public decimal CuotaIva { get; set; }
        public decimal SubTotalCuota { get; set; }
        public decimal TotalCuota { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaPago { get; set; }
        public bool Aplicado { get; set; }
    }
}
