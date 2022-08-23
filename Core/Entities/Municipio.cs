using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Municipio 
{
    public string Id { get; set; }
    public Departamento Departamento { get; set; }
    public int DepartamentoId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public DateTime FechaUltimaModificacion { get; set; } = DateTime.Now;
    public bool Enabled { get; set; } = true;    
    //[InverseProperty("MunicipioNacimiento")]
    //public List<Persona> MunicipioNacimientos { get; set; } = new List<Persona>();
    //[InverseProperty("MunicipioResidencia")]
    //public List<Persona> MunicipioResidencias { get; set; } = new List<Persona>();
}
