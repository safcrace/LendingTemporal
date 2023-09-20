namespace API.Dtos;

public class TipoPrestamoDto
{
    public int Id { get; set; }
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
    public bool TasaMoraGeneral { get; set; } = false;
    public bool TasaMoraDepartamental { get; set; } = false;
    public bool TasaMoraVariable { get; set; } = false;
    public bool TasaMoraFija { get; set; } = false;    
    public decimal TasaIva { get; set; }
    public string TPA { get; set; }
    public bool ParametrosGeneral { get; set; } = false;
    public bool ParametrosDepartamental { get; set; } = false;
    public bool PermisosAnalista { get; set; } = false;
    public decimal MontoMinimoAnalista { get; set; }
    public decimal MontoMaximoAnalista { get; set; }
    public bool PermisosJefeCreditos { get; set; } = false;
    public decimal MontoMinimoJefeCreditos { get; set; }
    public decimal MontoMaximoJefeCreditos { get; set; }
    public bool PermisosComiteGerencia { get; set; } = false;
    public decimal MontoMinimoComiteGerencia { get; set; }
    public decimal MontoMaximoComiteGerencia { get; set; }
    public bool PermisoComiteDirectores { get; set; } = false;
    public decimal MontoMinimoComiteDirectores { get; set; }
    public decimal MontoMaximoComiteDirectores { get; set; }
    public bool Habilitado { get; set; }
}
