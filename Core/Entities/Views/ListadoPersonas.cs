using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ListadoPersonas
    {
        public int EntidadId { get; set; }
        public int PersonaId { get; set; }
        public string? Nombre { get; set; }
        public string? Nit { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroCelular { get; set; }
        public string? NumeroTelefonoLaboral { get; set; }
        public string? Direccion { get; set; }        
    }
}
