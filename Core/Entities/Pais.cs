namespace Core.Entities;

public class Pais
{
    public string? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Nacionalidad { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
    public bool Habilitado { get; set; } = true;    
    public List<Departamento>? Departamentos { get; set; }
}
