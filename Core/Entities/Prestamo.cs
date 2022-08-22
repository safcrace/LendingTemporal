using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Prestamo : BaseEntity
    {
        public AppUser AppUser { get; set; } = new ();
        public string AppUserId { get; set; } = null!;
        public Persona Persona { get; set; } = new ();
        public int PersonaId { get; set; }
        public EstadoPrestamo EstadoPresamo { get; set; } = new ();
        public int EstadoPrestamoId { get; set; }
        public DestinoPrestamo DestinoPrestamo { get; set; } = new ();
        public int DestinoPrestamoId { get; set; }
        public TipoPrestamo TipoPrestamo { get; set; } = new ();
        public int TipoPrestamoId { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal SaldoIntereses { get; set; }
        public decimal SaldoIva { get; set; }
        public decimal SaldoGastosAdministrativos { get; set; }
        public decimal SaldoMora { get; set; }
        public decimal InteresesAcumulados { get; set; }
    }
}
