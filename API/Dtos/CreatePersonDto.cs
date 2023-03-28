namespace API.Dtos
{
    public class CreatePersonDto
    {
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public int OcupacionId { get; set; }
        public string? PaisNacimientoId { get; set; }
        public int DepartamentoId { get; set; }
        public string? MunicipioId { get; set; }
        public int TipoViviendaId { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? ApellidoCasada { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? DireccionLaboral { get; set; }
        public string? Colonia { get; set; }
        public string? Nit { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? NumeroCelular { get; set; }
        public string? NumeroTelefonoLaboral { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Comentarios { get; set; }
        public string? CodigoSap { get; set; }
    }
}
