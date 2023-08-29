using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class EstadoPrestamo : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        [InverseProperty("NuevoEstadoPrestamo")]
        public List<BitacoraPrestamo> NuevoEstadoPrestamos { get; set; } = new List<BitacoraPrestamo>();

    }
}
