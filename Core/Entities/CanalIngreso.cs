namespace Core.Entities
{
    public class CanalIngreso : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
