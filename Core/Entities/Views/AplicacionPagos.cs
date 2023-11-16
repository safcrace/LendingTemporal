using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Views
{
    public class AplicacionPagos
    {
        public int CreditoId { get; set; }
        public string? Referencia { get; set; }
        public string? TipoCredito { get; set; }
        public string? NIT { get; set; }
        public string? Nombre { get; set; }
        //public string? MotivoTransaccion { get; set; }
        //public byte Plazo { get; set; }
        public string? Banco { get; set; }
        public DateTime FechaBoleta { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public string? Ejecutivo { get; set; }
        public decimal TotalTransaccion { get; set; }
        public decimal Capital { get; set; }
        public decimal Intereses { get; set; }
        public decimal IvaIntereses { get; set; }
        public decimal Mora { get; set; }
        public decimal IvaMora { get; set; }
        public string? ArchivoBatch { get; set; }
        public int IdentificadorDeRelacion { get; set; }
    }
}
