using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class Persona : BaseEntity
{
    public AppUser? AppUser { get; set; }
    public Entidad? Entidad { get; set; }
    public int? EntidadId { get; set; }    
    public Genero? Genero { get; set; }
    public int? GeneroId { get; set; } = 1;
    public EstadoCivil? EstadoCivil { get; set; } 
    public int? EstadoCivilId { get; set; }
    public Pais? PaisNacimiento { get; set; }
    public string? PaisNacimientoId { get; set; }
    public Departamento? Departamento { get; set; }
    public int? DepartamentoId { get; set; }
    public Municipio? Municipio { get; set; }
    public string? MunicipioId { get; set; }
    public Ocupacion? Ocupacion { get; set; }
    public int? OcupacionId { get; set; }
    public TipoVivienda? TipoVivienda { get; set; }
    public int? TipoViviendaId { get; set; }
    public string? PrimerNombre { get; set; }    
    public string? PrimerApellido { get; set; }
    public string? SegundoNombre { get; set; }
    public string? SegundoApellido { get; set; }    
    public string? ApellidoCasada { get; set; }
    public DateTime? FechaNacimiento { get; set; } = null;
    [EmailAddress]
    public string? Email { get; set; } = String.Empty;    
    public string? Direccion { get; set; }    
    public string? Colonia { get; set; }    
    public string? NIT { get; set; }
    public string? NumeroTelefono { get; set; }
    public string? NumeroCelular { get; set; }
    public string? NumeroTelefonoLaboral { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? DireccionLaboral { get; set; }
    public string? Comentarios { get; set; }
    public string? CodigoSAP { get; set; }
}
