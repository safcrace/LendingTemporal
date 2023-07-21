namespace Core.Entities
{
    public class SegmentoNegocio : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public List<SubSegmentoNegocio> SubSegmentoNegocios { get; set; } = new();
    }
}
