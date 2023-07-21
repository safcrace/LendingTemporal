using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Municipio 
{
    public string? Id { get; set; }
    public Departamento? Departamento { get; set; }
    public int DepartamentoId { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaModificacion { get; set; } = DateTime.Now;
    public bool Habilitado { get; set; } = true;
    [InverseProperty("MunicipioNegocio")]
    public List<Persona> MunicipioNegocios { get; set; } = new List<Persona>();
    //[InverseProperty("MunicipioResidencia")]
    //public List<Persona> MunicipioResidencias { get; set; } = new List<Persona>();
}
