namespace API.Dtos
{
    public class CreatePersonReferenceDto
    {        
        public int PersonaId { get; set; }        
        public int TipoReferenciaId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
    }
}
