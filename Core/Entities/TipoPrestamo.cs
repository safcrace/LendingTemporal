using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class TipoPrestamo : BaseEntity
    {
        public string? Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; } = string.Empty;
        public bool DisponibleOrganizaciones { get; set; } = false;
        public bool DisponiblePersonas { get; set; } = false;
        public TipoCuota? TipoCuota { get; set; }
        public int? TipoCuotaId { get; set; }
        public bool TasaInteresGeneral { get; set; }
        public bool TasaInteresDepartamental { get; set; }
        public bool TasaInteresVariable { get; set; }
        public bool TasaInteresFija { get; set; }
        public bool TasaMoraGeneral { get; set; }
        public bool TasaMoraDepartamental { get; set; }
        public bool TasaMoraVariable { get; set; }
        public bool TasaMoraFija { get; set; }
        public decimal TasaIva  { get; set; }
        public Moneda? Moneda { get; set; }
        public int? MonedaId { get; set; } = 1;
        public bool ParametrosGeneral { get; set; }
        public bool ParametrosDepartamental { get; set; }
        public string TPA { get; set; }
        public bool PermisosJefeCreditos { get; set; }
        public decimal MontoMinimoJefeCreditos { get; set; }
        public decimal MontoMaximoJefeCreditos { get; set; }
        public bool PermisosComiteGerencia { get; set; }
        public decimal MontoMinimoComiteGerencia { get; set; }
        public decimal MontoMaximoComiteGerencia { get; set; }
        public bool PermisosComiteDirectores { get; set; }
        public decimal MontoMinimoComiteDirectores { get; set; }
        public decimal MontoMaximoComiteDirectores { get; set; }
        public List<DocumentosPrestamo> DocumentosRequeridos { get; set; } = new();
        public ICollection<InteresesDepartamentos> InteresesDepartamentos { get; set; } = new List<InteresesDepartamentos>();
        public ICollection<MoraDepartamentos> MoraDepartamentos { get; set; } = new List<MoraDepartamentos>();
        public ICollection<ParametrosDepartamentos> ParametrosDepartamentos { get; set; } = new List<ParametrosDepartamentos>();
    }
}
