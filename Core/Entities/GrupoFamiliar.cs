using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class GrupoFamiliar : BaseEntity
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        [InverseProperty("NumeroPersonasTrabajan")]
        public List<Persona> TotalPersonasTrabajan { get; set; } = new List<Persona>();

    }
}
