using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class TipoPrestamoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int MinCuotas { get; set; }
    public int MaxCuotas { get; set; }
    public decimal MinInteres { get; set; }
    public decimal MaxInteres { get; set; }
    public decimal MinGastos { get; set; }
    public decimal MaxGastos { get; set; }
    public decimal MinMora { get; set; }
    public decimal MaxMora { get; set; }
    public int DiasGracia { get; set; }
    public decimal MinMonto { get; set; }
    public decimal MaxMonto { get; set; }
    public bool Habilitado { get; set; }
    public bool DisponibleOrganizaciones { get; set; }
    public bool DisponiblePersonas { get; set; }
    public CatalogDto Moneda { get; set; }
    public List<string> DocumentosRequeridos { get; set; } = new();
}

public class CreateTipoPrestamoDto
{
    [Required] public string Nombre { get; set; }
    public int MinCuotas { get; set; } = 1;
    public int MaxCuotas { get; set; } = 1;
    public decimal MinInteres { get; set; } = 0;
    public decimal MaxInteres { get; set; } = 0;
    public decimal MinGastos { get; set; } = 0;
    public decimal MaxGastos { get; set; } = 0;
    public decimal MinMora { get; set; } = 0;
    public decimal MaxMora { get; set; } = 0;
    public int DiasGracia { get; set; } = 0;
    public decimal MinMonto { get; set; } = 0;
    public decimal MaxMonto { get; set; } = 0;
    public int MonedaId { get; set; } = 1;
    public bool DisponibleOrganizaciones { get; set; } = false;
    public bool DisponiblePersonas { get; set; } = false;
    public List<CreateDocumentoPrestamoDto> DocumentosRequeridos { get; set; } = new();
}

public class UpdateTipoPrestamoDto
{
    public string? Nombre { get; set; }
    public int? MinCuotas { get; set; }
    public int? MaxCuotas { get; set; }
    public decimal? MinInteres { get; set; }
    public decimal? MaxInteres { get; set; }
    public decimal? MinGastos { get; set; }
    public decimal? MaxGastos { get; set; }
    public decimal? MinMora { get; set; }
    public decimal? MaxMora { get; set; }
    public int? DiasGracia { get; set; }
    public decimal? MinMonto { get; set; }
    public decimal? MaxMonto { get; set; }
    public int? MonedaId { get; set; }
    public bool? DisponibleOrganizaciones { get; set; }
    public bool? DisponiblePersonas { get; set; }
    public List<CreateDocumentoPrestamoDto> DocumentosRequeridos { get; set; } = new();
}