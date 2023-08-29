using Core.Entities;

namespace API.Dtos
{
    public class UpdateProspectoDto
    {
        public string? AppUserModificoId { get; set; }
        public string? AppUserAutorizoId { get; set; }
        public DatosPrestamoDto? DatosPrestamo { get; set; }
        public DatosPersonaDto? DatosPersona { get; set; }
        public DatosEmpresaDto? DatosEmpresa { get; set; }
        public List<DatosContactoEmpresaDto>? DatosContactoEmpresa { get; set; }
    }
}
