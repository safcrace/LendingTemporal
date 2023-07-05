namespace Core.Entities;

public class DocumentosPrestamo : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public TipoPrestamo? TipoPrestamo { get; set; }
    public int TipoPrestamoId { get; set; }
}