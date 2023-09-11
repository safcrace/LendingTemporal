using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateTipoPrestamoDto
    {      
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool DisponibleOrganizaciones { get; set; } = false;
        public bool DisponiblePersonas { get; set; } = false;
        public int MonedaId { get; set; }
        public int TipoCuotaId { get; set; }
        public bool TasaInteresGeneral { get; set; } = false;
        public bool TasaInteresDepartamental { get; set; } = false;
        public bool TasaInteresVariable { get; set; } = false;
        public bool TasaInteresFija { get; set; } = false;
        public List<CreateInteresesDepartamentosDto>? InteresesDepartamentos { get; set; }
        public bool TasaMoraGeneral { get; set; } = false;
        public bool TasaMoraDepartamental { get; set; } = false;
        public bool TasaMoraVariable { get; set; } = false;
        public bool TasaMoraFija { get; set; } = false;
        public List<CreateMoraDepartamentosDto>? MoraDepartamentos { get; set; }
        public decimal TasaIva { get; set; }
        public string Tpa { get; set; } = "Hola";
        public bool ParametrosGeneral { get; set; } = false;
        public bool ParametrosDepartamental { get; set; } = false;
        public bool PermisosJefeCreditos { get; set; } = false;
        public decimal MontoMinimoJefeCreditos { get; set; }
        public decimal MontoMaximoJefeCreditos { get; set; }
        public bool PermisosComiteGerencia { get; set; } = false;
        public decimal MontoMinimoComiteGerencia { get; set; }
        public decimal MontoMaximoComiteGerencia { get; set; }
        public bool PermisosComiteDirectores { get; set; } = false;
        public decimal MontoMinimoComiteDirectores { get; set; }
        public decimal MontoMaximoComiteDirectores { get; set; }
        public List<CreateParametrosDepartamentosDto>? ParametrosDepartamentos { get; set; }
        public List<CreateDocumentoPrestamoDto>? DocumentosRequeridos { get; set; } 
    }
}
