namespace API.Dtos
{
    public class CreateDetalleDesembolsoDto
    {
        public int DesembolsoId { get; set; }
        public int? BancoId { get; set; }
        public int? MedioDesembolsoId { get; set; }
        public int? TipoCuentaId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal CantidadDesembolso { get; set; }
    }
}
