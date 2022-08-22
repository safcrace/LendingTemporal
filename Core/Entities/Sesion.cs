using Core.Entities.Identity;

namespace Core.Entities;

public class Sesion
{
    public int Id { get; set; }
    public TipoBitacora? TipoBitacora { get; set; }
    public int TipoBitacoraId { get; set; }
    public AppUser? AppUser { get; set; }
    public string? AppUserId { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string? Token { get; set; }
}
