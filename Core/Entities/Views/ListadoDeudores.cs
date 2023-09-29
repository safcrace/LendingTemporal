using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    public class ListadoDeudores
    {
        public int EntidadId { get; set; }        
        public int TipoEntidadId { get; set; }
        public string TipoEntidad { get; set; }
        public string NIT { get; set; } = null!;
        public string DPI { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Telefono { get; set; }
        
    }
}
