namespace API.Dtos
{
    public class CreatePersonDto
    {
        public int GeneroId { get; set; }
        public int EstadoCivilId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? ApellidoCasada { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public int Nit { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? NumeroDocumento { get; set; }
    }
}
