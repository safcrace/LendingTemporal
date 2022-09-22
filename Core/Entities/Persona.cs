using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

[Index(nameof(NIT), IsUnique = true)]
public class Persona : BaseEntity
{    
    public Genero? Genero { get; set; }
    public int? GeneroId { get; set; } = 1;
    public EstadoCivil? EstadoCivil { get; set; } 
    public int? EstadoCivilId { get; set; }       
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }    
    public string? ApellidoCasada { get; set; }    
    public DateTime? FechaNacimiento { get; set; } = DateTime.Now;
    [EmailAddress]
    public string? Email { get; set; } = String.Empty;    
    public string? Direccion { get; set; }    
    public string? NIT { get; set; }
    public string? NumeroTelefono { get; set; }
    public string? NumeroDocumento { get; set; } 
}
