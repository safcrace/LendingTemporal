using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

[Index(nameof(NIT), IsUnique = true)]
public class Persona : BaseEntity
{
    public string? AppUserId { get; set; } = null!;
    public Pais Pais { get; set; } = new();
    public string? PaisId { get; set; }
    public Pais Nacionalidad { get; set; } = new();    
    public string? NacionalidadId { get; set; }
    public Relacion Relacion { get; set; } = new();
    public int RelacionId { get; set; }
    public Departamento DepartamentoNacmiento { get; set; } = new();
    public int? DepartamentoNacmientoId { get; set; }
    public Departamento DepartamentoResidencia { get; set; } = new();
    public int? DepartamentoResidenciaId { get; set; }
    public Genero Genero { get; set; } = new();
    public int? GeneroId { get; set; }
    public Municipio MunicipioNacimiento { get; set; } = new();   
    public string? MunicipioNacimientoId { get; set; }
    public Municipio MunicipioResidencia { get; set; } = new();    
    public string? MunicipioResidenciaId { get; set; }
    public EstadoCivil EstadoCivil { get; set; } = new();
    public int? EstadoCivilId { get; set; }       
    public string? Nombres { get; set; }
    public string? Apellidos { get; set; }    
    public string? ApellidoCasada { get; set; }    
    public DateTime? FechaNacimiento { get; set; }
    [EmailAddress]
    public string? Email { get; set; }    
    public string? Direccion { get; set; }    
    public string? NIT { get; set; }
    public string? NumeroTelefono { get; set; }
    public string? NumeroDocumento { get; set; }    
}
