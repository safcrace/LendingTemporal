namespace API.Dtos
{
    public class DatosPersonaDto
    {
        public int Id { get; set; }
        public int EntidadId { get; set; }
        public int? ExpedienteSidId { get; set; }
        public int? GeneroId { get; set; }
        public string? DescripcionGenero { get; set; }
        public int? EstadoCivilId { get; set; }
        public string? DescripcionEstadoCivil { get; set; }
        public int? OcupacionSinFinId { get; set; }
        //public string? PaisNacimientoId { get; set; }
        public int? DepartamentoId { get; set; }
        public string? DescripcionDepartamento { get; set; }
        public string? MunicipioId { get; set; }
        public string? DescripcionMunicipio { get; set; }
        //public int? TipoViviendaId { get; set; }
        public int? EscolaridadId { get; set; }
        public int? GrupoFamiliarId { get; set; }
        public int? NumeroPersonasTrabajanId { get; set; }
        public int? DepartamentoNegocioId { get; set; }
        public string? MunicipioNegocioId { get; set; }
        public int? SegmentoNegocioId { get; set; }
        public int? SubSegmentoNegocioId { get; set; }
        public int? UbicacionNegocioId { get; set; }
        public int? ClientesHabitualesId { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? TercerNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? ApellidoCasada { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public bool PoseeNegocio { get; set; }
        public bool PoseeRegistroSAT { get; set; }
        public string? NombreNegocio { get; set; }
        public string? DireccionNegocio { get; set; }
        //public string? Colonia { get; set; }
        public string? Nit { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? NumeroCelular { get; set; }
        public string? NumeroTelefonoNegocio { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime FechaInicioNegocio { get; set; }
        public decimal VentasMensuales { get; set; }
        public decimal GanaciasMensuales { get; set; }
        public decimal OtrosIngresos { get; set; }
        public string? OrigenOtrosIngresos { get; set; }
        //public string? Comentarios { get; set; }
        //public string? CodigoSap { get; set; }
    }
}

