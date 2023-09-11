namespace Core.Entities;

public class DocumentosPrestamo : BaseEntity
{
    public string? Nombre { get; set; } 
    public string? Descripcion { get; set; }
    public TipoPrestamo? TipoPrestamo { get; set; }
    public int TipoPrestamoId { get; set; }
}