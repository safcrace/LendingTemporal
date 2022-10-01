namespace Core.Entities
{
    public class TipoRelacion : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public ICollection<RelacionEntidad> Entidades { get; set; } = new List<RelacionEntidad>();
    }
}
