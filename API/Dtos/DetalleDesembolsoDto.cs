using Core.Entities;

namespace API.Dtos
{
    public class DetalleDesembolsoDto
    {        
        public int DesembolsoId { get; set; }        
        public int? BancoId { get; set; }        
        public int? MedioDesembolsoId { get; set; }        
        public int? TipoCuentaId { get; set; }        
        public int? LoteId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal CantidadDesembolso { get; set; }
        public string? Comentario { get; set; }
        public bool TieneLote { get; set; }
    }
}
