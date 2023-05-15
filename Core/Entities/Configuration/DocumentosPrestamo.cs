namespace Core.Entities.Configuration;

public class DocumentosPrestamo : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public TipoPrestamo? TipoPrestamo { get; set; }
    public int TipoPrestamoId { get; set; }
}