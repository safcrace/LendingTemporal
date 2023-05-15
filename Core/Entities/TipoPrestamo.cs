using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Configuration;

namespace Core.Entities
{
    public class TipoPrestamo : BaseEntity
    {
        public string? Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public int MinCuotas { get; set; } = 1;
        public int MaxCuotas { get; set; } = 1;
        [Column(TypeName = "decimal(18, 2)")] public decimal MinInteres { get; set; } = 0;
        [Column(TypeName = "decimal(18, 2)")] public decimal MaxInteres { get; set; } = 0;
        [Column(TypeName = "decimal(18, 2)")] public decimal MinGastos { get; set; } = 0;
        [Column(TypeName = "decimal(18, 2)")] public decimal MaxGastos { get; set; } = 0;
        [Column(TypeName = "decimal(18, 2)")] public decimal MinMora { get; set; } = 0;
        [Column(TypeName = "decimal(18, 2)")] public decimal MaxMora { get; set; } = 0;
        public int DiasGracia { get; set; } = 0;
        public Currency? Currency { get; set; }
        public int CurrencyId { get; set; } = 1;
        [Column(TypeName = "decimal(18, 2)")] public decimal MinMonto { get; set; } = 1;
        [Column(TypeName = "decimal(18, 2)")] public decimal MaxMonto { get; set; } = 0;
        public HashSet<DocumentosPrestamo> DocumentosRequeridos { get; set; } = new();
        public bool DisponibleOrganizaciones { get; set; } = false;
        public bool DisponiblePersonas { get; set; } = false;
    }
}
