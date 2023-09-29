using API.Dtos;

namespace API.Dtos
{
    public class InfoPrestamoDto
    {
        public int SolicitudId { get; set; }
        public string? NombreProspecto { get; set; }
        public string? ProductoInteresado { get; set; }
        public decimal MontoRealSolicitado { get; set; }
        public int Plazo { get; set; }
        public decimal TasaIntereses { get; set; }
        public string? DescripcionTipoCuota { get; set; }
        public string? NombreAsesor { get; set; }
    }
}

