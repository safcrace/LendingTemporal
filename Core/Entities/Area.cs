namespace Core.Entities
{
    public class Area : BaseEntity
    {
        public string? Nombre { get; set; }

        public ICollection<AreaPersonas> AreaPersonas { get; set; } = new List<AreaPersonas>();
    }
}
