namespace API.Dtos
{
    public class ReferenciaEmpresaDto
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public int TipoReferenciaId { get; set; }
        public string? DescripciónReferencia { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
    }
}
