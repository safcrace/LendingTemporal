using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ListadoDesembolso
    {
        public int SolicitudId { get; set; }
        public int DesembolsoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int TiempoSolicitud { get; set; }
        public string? NombreProspecto { get; set; }
        public string? DPI { get; set; }
        public string? Nit { get; set; }
        public string? Telefono { get; set; }
        public string? NumeroCelular { get; set; }
        public string? NumeroCuenta { get; set; }
        public string? AprobacionCreditos { get; set; }
        public string? AprobacionDireccion { get; set; }
        public string? AprobacionGerencia { get; set; }
        public decimal Monto { get; set; }
        public string? NombreEmisionCheque { get; set; }
        public int MedioDesembolsoId { get; set; }
    }
}
