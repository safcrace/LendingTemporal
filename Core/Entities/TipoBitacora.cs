namespace Core.Entities;

public class TipoBitacora : BaseEntity
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }        
}
