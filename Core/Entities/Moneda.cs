namespace Core.Entities;

public class Moneda : BaseEntity
{
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Simbolo { get; set; } = string.Empty;
}