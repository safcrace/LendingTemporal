namespace API.Dtos
{
    public class ListadoTiposCreditoDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int TipoCuotaId { get; set; }
        public string? TipoCuota { get; set; }
        public int MonedaId { get; set; }
        public string? Moneda { get; set; }
        public bool Habilitado { get; set; }
    }
}
