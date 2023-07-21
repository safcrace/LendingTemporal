namespace Core.Entities
{
    public class ProductoInteresado : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
