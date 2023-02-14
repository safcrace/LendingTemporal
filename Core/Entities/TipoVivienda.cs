namespace Core.Entities
{
    public class TipoVivienda : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public List<Persona> Personas { get; set; } = new List<Persona>();

    }
}
