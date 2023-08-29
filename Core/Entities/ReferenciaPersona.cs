namespace Core.Entities
{
    public class ReferenciaPersona : BaseEntity
    {
        public Persona? Persona { get; set; }
        public int PersonaId { get; set; }
        public TipoReferencia? TipoReferencia { get; set; }
        public int TipoReferenciaId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
    }
}
