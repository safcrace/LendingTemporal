using Core.Entities.Identity;
using Core.Entities;

namespace API.Dtos
{
    public class DesembolsoDto
    {
        public int Id { get; set; }
        public string? AppUserId { get; set; }        
        public int? PrestamoId { get; set; }                
        public decimal CantidadDesembolso { get; set; }
        public string? AprobacionCreditos { get; set; }
        public string? AprobacionDireccion { get; set; }
        public string? AprobacionGerencia { get; set; }      
        public List<DetalleDesembolsoDto>? DetalleDesembolsos { get; set; }
    }
}
