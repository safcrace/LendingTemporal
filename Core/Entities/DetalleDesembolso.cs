namespace Core.Entities
{
    public class DetalleDesembolso : BaseEntity
    {
        public Desembolso? Desembolso { get; set; }
        public int DesembolsoId { get; set; }
        public Banco? Banco { get; set; }
        public int? BancoId { get; set; }
        public MedioDesembolso? MedioDesembolso { get; set; }
        public int? MedioDesembolsoId { get; set; }
        public TipoCuenta? TipoCuenta { get; set; }
        public int? TipoCuentaId { get; set; }
        public Lote? Lote { get; set; }
        public int? LoteId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal CantidadDesembolso { get; set; }
        public string? Comentario { get; set; }
        public bool TieneLote { get; set; }
        public bool Desembolsado { get; set; }
    }
}
