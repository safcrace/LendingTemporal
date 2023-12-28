namespace API.Dtos
{
    public class CreateDetalleLoteDto
    {
        public int LoteId { get; set; }
        public int SolicitudId { get; set; }
        public int DetalleDesembolsoId { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal Monto { get; set; }
        public string? Documento { get; set; }
    }
}
