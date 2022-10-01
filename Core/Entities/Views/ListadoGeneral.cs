using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Views
{
    public class ListadoGeneral
    {
        public int Id { get; set; }
        public string Estatus { get; set; } = null!;
        public string DPI { get; set; } = null!;
        public string NIT { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        [Precision(18, 2)]
        public decimal SaldoInicial { get; set; }
        [Precision(18, 2)]
        public decimal SaldoActual { get; set; }
        public string Asesor { get; set; } = null!;
        public bool Habilitado { get; set; }
    }
}
