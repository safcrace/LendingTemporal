using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AbonoPlan
    {
        public EstadoCuenta EstadoCuenta { get; set; } = null!;
        public int EstadoCuentaId { get; set; }
        public PlanPago PlanPago { get; set; } = null!;
        public int PlanPagoId { get; set; }
        public decimal CuotaCapital { get; set; }
        public decimal CuotaIntereses { get; set; }
        public decimal CuotaIvaIntereses { get; set; }
        public decimal CuotaMora { get; set; }
        public decimal CuotaIvaMora { get; set; }
        public decimal CuotaGastos { get; set; }
        public decimal CuotaIvaGastos { get; set; }
        
    }
}
