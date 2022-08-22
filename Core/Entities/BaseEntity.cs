using Core.Interfaces;

namespace Core.Entities;

public class BaseEntity 
{
    public int Id { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
    public bool Habilitado { get; set; } = true;
}
