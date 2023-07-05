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
        public bool TasaInteresRegional { get; set; }
        public bool TasInteresVariable { get; set; }
        public bool TasaInteresFija { get; set; }
        public bool TasaMoraGeneral { get; set; }
        public bool TasaMoraRegional { get; set; }
        public bool TasaMoraVariable { get; set; }
        public bool TasaMoraFija { get; set; }
        public decimal TasaIva  { get; set; }
        public Moneda? Moneda { get; set; }
        public int? MonedaId { get; set; } = 1;
        public bool ParametrosGeneral { get; set; }
        public bool ParametrosRegional { get; set; }        
        public List<DocumentosPrestamo> DocumentosRequeridos { get; set; } = new();
        public ICollection<InteresesRegiones> InteresesRegiones { get; set; } = new List<InteresesRegiones>();
        public ICollection<MoraRegiones> MoraRegiones { get; set; } = new List<MoraRegiones>();
        public ICollection<ParametrosRegiones> ParametrosRegiones { get; set; } = new List<ParametrosRegiones>();
    }
}
