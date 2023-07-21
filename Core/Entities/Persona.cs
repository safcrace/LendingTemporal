﻿using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

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
    public Ocupacion? OcupacionSinFin { get; set; }
    public int? OcupacionSinFinId { get; set; }
    public TipoVivienda? TipoVivienda { get; set; }
    public int? TipoViviendaId { get; set; }
    public Escolaridad? Escolaridad { get; set; }
    public int? EscolaridadId { get; set; }
    public GrupoFamiliar? GrupoFamiliar { get; set; }
    public Departamento? DepartamentoNegocio { get; set; }
    public int? DepartamentoNegocioId { get; set; }
    public Municipio? MunicipioNegocio { get; set; }
    public string? MunicipioNegocioId { get; set; }
    public int? GrupoFamiliarId { get; set; }
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
    public string? NumeroTelefonoNegocio { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? NombreNegocio { get; set; }
    public string? DireccionNegocio { get; set; }
    public string? Comentarios { get; set; }
    public string? CodigoSAP { get; set; }
}
