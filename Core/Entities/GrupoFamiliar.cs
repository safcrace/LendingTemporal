namespace Core.Entities
{
    public class GrupoFamiliar : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
