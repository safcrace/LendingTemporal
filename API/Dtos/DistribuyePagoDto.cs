namespace API.Dtos
{
    public class DistribuyePagoDto
    {
        public decimal MontoPago { get; set; }
        public decimal PagoCapital { get; set; }
        public decimal PagoCapitalAnticipado { get; set; }
        public decimal PagoIntereses { get; set; }
        public decimal PagoIvaIntereses { get; set; }
        public decimal PagoMora { get; set; } = 0;
        public decimal PagoIvaMora { get; set; } = 0;
        public decimal TotalGastos { get; set; } = 0;
        public decimal IvaGastos { get; set; } = 0;
        public decimal SaldoTotalPagar { get; set; } = 0;
        public DateTime FechaProximoPago { get; set; }
        public int DiasMora { get; set; }
        public string EstadoCredito { get; set; }
        public int TotalCuotasVencidas { get; set; }
        public int CuotasVencidasPagadas { get; set; }

    }
}


/*
 MontoPago = montoPago, 
                            PagoCapital = montoCapital,
                            PagoCapitalAnticipado = 0.00,
                            PagoIntereses = montoIntereses,
                            PagoIvaIntereses = montoIvaIntereses,
                            PagoMora = montoMora,
                            PagoIvaMora = montoIvaMora,
                            TotalGastos = planPago.CuotaGastos,
                            IvaGastos = planPago.CuotaIvaGastos,
                            SaldoTotalPagar = planPago.SaldoTotal,
                            FechaProximoPago = planPago.FechaPago.AddMonths(1),
                            DiasMora = 0,
                            EstadoCredito = await _dbContext.Prestamos.Where(p => p.Id == planPago.PrestamoId).Select(p => p.EstadoPrestamo.Nombre).FirstOrDefaultAsync(),
                            TotalCuotasVencidas = 0,
                            CuotasVencidasPagadas = 0 
 
 * */
