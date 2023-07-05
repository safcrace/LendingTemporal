namespace API.Dtos;

public class DocumentoPrestamoDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
}

public class CreateDocumentoPrestamoDto
{
    public string? Nombre { get; set; }
}