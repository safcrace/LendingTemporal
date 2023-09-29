namespace API.Dtos
{
    public class DatosPrestamoDto
    {
        public int Id { get; set; }
        public string? ReferenciaMigracion { get; set; }        
        public string AppUserId { get; set; } = null!;        
        public int? CarpetaSidId { get; set; }
        public int? EntidadPrestamoId { get; set; }        
        public int? EstadoPrestamoId { get; set; }
        public string? NombreEstadoPrestamo { get; set; }
        public int? EstadoOrigenId { get; set; }        
        public int? ProductoInteresadoId { get; set; }
        public string? DescripcionProductoInteresado { get; set; }
        public int? MontoInteresadoId { get; set; }        
        public string? DescripcionMontoInteresado { get; set; }
        public int? CanalIngresoId { get; set; }
        public string? DescripcionCanalIngreso { get; set; }
        public int? DestinoPrestamoId { get; set; }        
        public int? TipoPrestamoId { get; set; }        
        public int? GestorPrestamoId { get; set; }        
        public string? NombreAsesor { get; set; }
        public int? AnalistaPrestamoId { get; set; }        
        public string? NombreAnalista { get; set; }
        public int? EmpresaPrestamoId { get; set; }
        public int? OrigenSolicitudId { get; set; }        
        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaDesembolso { get; set; }
        public decimal MontoRealSolicitado { get; set; }
        public decimal MontoOtorgado { get; set; }
        public decimal InteresProyectado { get; set; }
        public decimal IvaProyectado { get; set; }
        public decimal GastosProyectados { get; set; }
        public decimal MontoTotalProyectado { get; set; }
        public int TipoCuotaPrestamo { get; set; }
        public byte Plazo { get; set; }
        public byte PlazoMinimo { get; set; }
        public byte PlazoMaximo { get; set; }
        public byte PlazoPredeterminado { get; set; }
        public decimal TasaInteresMinima { get; set; }
        public decimal TasaInteresMaxima { get; set; }
        public decimal TasaInteresPredeterminada { get; set; }
        public decimal TasaInteres { get; set; }        
        public decimal TasaIvaAsignada { get; set; }
        public decimal TasaIva { get; set; }
        public decimal TasaMora { get; set; }
        public decimal TasaGastos { get; set; }
        public int DiasMora { get; set; }
        public DateTime? FechaPlan { get; set; }       
        public string? ObjetivoCredito { get; set; }
        public string? TipoCuota { get; set; }
        public int DesembolsoId { get; set; }
    }
}
