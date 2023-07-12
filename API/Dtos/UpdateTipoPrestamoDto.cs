using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateTipoPrestamoDto
    {
        [Required]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool DisponibleOrganizaciones { get; set; } = false;
        public bool DisponiblePersonas { get; set; } = false;
        public int MonedaId { get; set; }
        public int TipoCuotaId { get; set; }
        public bool TasaInteresGeneral { get; set; } = false;
        public bool TasaInteresRegional { get; set; } = false;
        public bool TasaInteresVariable { get; set; } = false;
        public bool TasaInteresFija { get; set; } = false;
        public List<CreateInteresesDepartamentosDto>? InteresesDepartamentos { get; set; }
        public bool TasaMoraGeneral { get; set; } = false;
        public bool TasaMoraRegional { get; set; } = false;
        public bool TasaMoraVariable { get; set; } = false;
        public bool TasaMoraFija { get; set; } = false;
        public List<CreateMoraDepartamentosDto>? MoraDepartamentos { get; set; }
        public decimal TasaIva { get; set; }
        public bool ParametrosGeneral { get; set; } = false;
        public bool ParametrosRegional { get; set; } = false;
        public List<CreateParametrosDepartamentosDto>? ParametrosDepartamentos { get; set; }
        //public List<CreateDocumentoPrestamoDto> DocumentosRequeridos { get; set; } = new();
    }
}
