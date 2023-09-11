namespace Core.Entities
{
    public class AreaPersonas
    {
        public Area? Area { get; set; } 
        public int AreaId { get; set; }
        public Persona? Persona { get; set; } 
        public int PersonaId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
