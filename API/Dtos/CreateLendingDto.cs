using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateLendingDto
    {
        [Required]
        public string AppUserId { get; set; } = string.Empty;        
        public string? AppUserAutorizoId { get; set; }
        [Required]
        public byte TipoEntidad { get; set; }
        public int EntidadPrestamoId { get; set; } = 0;
        public int? EstadoPrestamoId { get; set; } = 9;
        public int? ProductoInteresadoId { get; set; }
        public int? MontoInteresadoId { get; set; }
        public int? CanalIngresoId { get; set; }
        public int? DestinoPrestamoId { get; set; } 
        public int? TipoPrestamoId { get; set; }
        public int? GestorPrestamoId { get; set; }
        public int? EmpresaPrestamoId { get; set; }
        public DateTime? FechaAprobacion { get; set; } = DateTime.Now;
        public DateTime? FechaDesembolso { get; set; }
        public decimal MontoOtorgado { get; set; }
        public decimal InteresProyectado { get; set; } = 0;
        public decimal IvaProyectado { get; set; } = 0;
        public decimal GastosProyectados { get; set; } = 0;
        public decimal MontoTotalProyectado { get; set; } = 0;
        public int?  Plazo { get; set; }
        public decimal TasaInteres { get; set; } = 0;
        public decimal TasaIva { get; set; } = 0;
        public decimal TasaMora { get; set; } = 0;
        public decimal TasaGastos { get; set; } = 0;
        public DateTime FechaPlan { get; set; }        
        public CreatePersonDto? CreatePersonDto { get; set; }
        public CreateEmpresaDto? CreateCompanyDto { get; set; }
    }
}
