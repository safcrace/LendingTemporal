using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Views
{
    public class SaldosMigracion
    {
        public int Id { get; set; }
        public string? ReferenciaMigracion { get; set; } = string.Empty;
        public decimal DeudaTotal { get; set; }
        public decimal CapitalPrestado { get; set; }
        public decimal SaldoCapital { get; set; }
        public decimal InteresProyectado { get; set; }
        public decimal IvaProyectado { get; set; }
        public decimal GastosProyectados { get; set; }
        public decimal SaldoInteres { get; set; }
        public decimal SaldoIvaInteres { get; set; }
        public decimal Mora { get; set; }
        public decimal SaldoMora { get; set; }
        public decimal IvaMora { get; set; }
        public decimal SaldoIvaMora { get; set; }
        public decimal Gastos { get; set; }
        public decimal SaldoGastos { get; set; }
        public decimal IvaGastos { get; set; }
        public decimal SaldoIvaGastos { get; set; }
    }    
}
