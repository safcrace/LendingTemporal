namespace Core.Entities
{
    public class SubSegmentoNegocio : BaseEntity
    {
        public SegmentoNegocio SegmentoNegocio { get; set; }
        public int SegmentoNegocioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
