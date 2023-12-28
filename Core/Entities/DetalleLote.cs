namespace Core.Entities
{
    public class DetalleLote : BaseEntity
    {
        public Lote? Lote { get; set; }
        public int LoteId { get; set; }
        public int SolicitudId { get; set; }
        public int DetalleDesembolsoId { get; set; }
        public string? NombreEmisionCheque { get; set;}
        public decimal Monto { get; set; }
        public string? Documento { get; set; }
        public bool Aprobado { get; set; }
    }
}
