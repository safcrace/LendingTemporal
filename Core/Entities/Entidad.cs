using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Entidad : BaseEntity
    {
        public TipoEntidad? EntityType { get; set; }
        public int TipoEntidadId { get; set; }
        [InverseProperty("EntidadPrestamo")]
        public ICollection<Prestamo> EntidadesPrestamos { get; set; } = new List<Prestamo>();
        [InverseProperty("GestorPrestamo")]
        public ICollection<Prestamo> GestoresPrestamos { get; set; } = new List<Prestamo>();
        [InverseProperty("AnalistaPrestamo")]
        public ICollection<Prestamo> AnalistaPrestamos { get; set; } = new List<Prestamo>();
        [InverseProperty("EmpresaPrestamo")]
        public ICollection<Prestamo> EmpresasPrestamos { get; set; } = new List<Prestamo>();
    }
}
