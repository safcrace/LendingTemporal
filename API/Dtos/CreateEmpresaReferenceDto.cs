namespace API.Dtos
{
    public class CreateEmpresaReferenceDto
    {
        public int EmpresaId { get; set; }
        public int TipoReferenciaId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
    }
}
