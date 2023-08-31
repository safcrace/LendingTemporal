using Core.Entities;

namespace API.Dtos
{
    public class DetalleLoteDto
    {
        public int Id { get; set; }
        public int LoteId { get; set; }
        public int SolicitudId { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal Monto { get; set; }
        public string? Documento { get; set; }
        public bool Aprobado { get; set; }
    }
}
