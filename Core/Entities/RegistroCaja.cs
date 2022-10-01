using Core.Entities.Identity;

namespace Core.Entities
{
    public class RegistroCaja : BaseEntity
    {
        public AppUser? AppUser { get; set; }
        public string AppUserId { get; set; } = string.Empty;
        public Banco? Banco { get; set; }
        public int BancoId { get; set; }
        public Caja? Caja { get; set; }
        public int CajaId { get; set; }
        public FormaPago? FormaPago { get; set; }
        public int FormaPagoId { get; set; }
        public Prestamo? Prestamo { get; set; }
        public int PrestamoId { get; set; }        
        public DateTime? FechaTransaccion { get; set; } = DateTime.Now;
        public DateTime? FechaDocumento { get; set; }
        public string NumeroDocumento { get; set; } = string.Empty;
        public int DiasMora { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoInteres { get; set; }
        public decimal MontoIvaIntereses { get; set; }
        public decimal MontoMora { get; set; }
        public decimal MontoIvaMora { get; set; }
        public decimal MontoGastos { get; set; }
        public decimal MontoIvaGastos { get; set; }
        public decimal MontoCapitalAnticipado { get; set; }
        public byte CuotasAdelantadas { get; set; }        
        public byte CuotasVencidas { get; set; }
        public decimal TotalCuotasVencidas { get; set; }        
        public string Observaciones { get; set; } = null!;
        public string MotivoAnulacion { get; set; } = null!;
    }
}
