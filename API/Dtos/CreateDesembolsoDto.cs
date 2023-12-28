namespace API.Dtos
{
    public class CreateDesembolsoDto
    {
        public string? AppUserId { get; set; }
        public int? PrestamoId { get; set; }             
        public decimal CantidadDesembolso { get; set; }
        public List<CreateDetalleDesembolsoDto>? DetalleDesembolsos { get; set; } = new List<CreateDetalleDesembolsoDto>();
    }
}
