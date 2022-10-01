namespace Core.Entities
{
    public class TipoEntidad : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public ICollection<Entidad> Entidades { get; set; } = new List<Entidad>();
    }
}