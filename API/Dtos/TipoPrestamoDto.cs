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
    public bool TasaInteresRegional { get; set; } = false;
    public bool TasaInteresVariable { get; set; } = false;
    public bool TasaInteresFija { get; set; } = false;    
    public bool TasaMoraGeneral { get; set; } = false;
    public bool TasaMoraRegional { get; set; } = false;
    public bool TasaMoraVariable { get; set; } = false;
    public bool TasaMoraFija { get; set; } = false;    
    public decimal TasaIva { get; set; }
    public bool ParametrosGeneral { get; set; } = false;
    public bool ParametrosRegional { get; set; } = false;    
}


//public class UpdateTipoPrestamoDto
//{
//    public string? Nombre { get; set; }
//    public int? MinCuotas { get; set; }
//    public int? MaxCuotas { get; set; }
//    public decimal? MinInteres { get; set; }
//    public decimal? MaxInteres { get; set; }
//    public decimal? MinGastos { get; set; }
//    public decimal? MaxGastos { get; set; }
//    public decimal? MinMora { get; set; }
//    public decimal? MaxMora { get; set; }
//    public int? DiasGracia { get; set; }
//    public decimal? MinMonto { get; set; }
//    public decimal? MaxMonto { get; set; }
//    public int? MonedaId { get; set; }
//    public bool? DisponibleOrganizaciones { get; set; }
//    public bool? DisponiblePersonas { get; set; }
//    public List<CreateDocumentoPrestamoDto> DocumentosRequeridos { get; set; } = new();
//}