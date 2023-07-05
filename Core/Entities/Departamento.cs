using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Departamento : BaseEntity
{
    public Pais? Pais { get; set; }
    public string? PaisId { get; set; }
    public Region? Region { get; set; }
    public int? RegionId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public List<Municipio>? Municipios { get; set; }            
    //[InverseProperty("DepartamentoNacmiento")]
    //public List<Persona> DepartamentoNacimientos { get; set; } = new List<Persona>();
    //[InverseProperty("DepartamentoResidencia")]
    //public List<Persona> DepartamentoResidencias { get; set; } = new List<Persona>();
}
