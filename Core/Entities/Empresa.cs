namespace Core.Entities
{
    public class Empresa : BaseEntity
    {
        public Entidad? Entidad { get; set; }
        public int? EntidadId { get; set; }
        public Departamento? Departamento { get; set; }
        public int? DepartamentoId { get; set; }
        public Municipio? Municipio { get; set; }
        public string? MunicipioId { get; set; }
        public SegmentoNegocio? SegmentoNegocio { get; set; }
        public int? SegmentoNegocioId { get; set; }
        public SubSegmentoNegocio? SubSegmentoNegocio { get; set; }
        public int? SubSegmentoNegocioId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Alias { get; set; } = string.Empty;
        public DateTime? FechaInicioOperaciones { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Nit { get; set; }
        public List<ContactoEmpresa>? ContactoEmpresas { get; set; } = new List<ContactoEmpresa>();
    }
}
