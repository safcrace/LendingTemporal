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
    public ICollection<InteresesDepartamentos> InteresesDepartamentos { get; set; } = new List<InteresesDepartamentos>();
    public ICollection<MoraDepartamentos> MoraDepartamentos { get; set; } = new List<MoraDepartamentos>();
    public ICollection<ParametrosDepartamentos> ParametrosDepartamentos { get; set; } = new List<ParametrosDepartamentos>();
    [InverseProperty("DepartamentoNegocio")]
    public List<Persona> DepartamentoNegocios { get; set; } = new List<Persona>();
    //[InverseProperty("DepartamentoResidencia")]
    //public List<Persona> DepartamentoResidencias { get; set; } = new List<Persona>();
}
