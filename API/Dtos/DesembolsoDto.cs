using Core.Entities.Identity;
using Core.Entities;

namespace API.Dtos
{
    public class DesembolsoDto
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }        
        public int? PrestamoId { get; set; }        
        public int? BancoId { get; set; }        
        public int? MedioDesembolsoId { get; set; }        
        public int? TipoCuentaId { get; set; }        
        public int? LoteId { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public decimal CantidadDesembolso { get; set; }
        public string? AprobacionCreditos { get; set; }
        public string? AprobacionDireccion { get; set; }
        public string? AprobacionGerencia { get; set; }
        public bool TieneLote { get; set; }
    }
}
