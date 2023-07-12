namespace Core.Entities
{
    public class Region : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public List<Departamento>? Departamentos { get; set; }
        
    }
}
