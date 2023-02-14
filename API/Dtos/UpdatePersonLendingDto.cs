using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdatePersonLendingDto
    {
        [Required]
        public int personId { get; set; }
        [Required]
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? ApellidoCasada { get; set; }
        public int GeneroId { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required]
        public string? NumeroDocumento { get; set; }
        [Required]
        public string? Direccion { get; set; }
        public string? Colonia { get; set; }
        public int? TipoViviendaId { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? NumeroTelefono { get; set; }
        public string? NumeroCelular { get; set; }
        public string? NumeroTelefonoLaboral { get; set; }
        [Required]
        public string? NIT { get; set; }
        [Required]
        public int EstadoCivilId { get; set; }
        public string PaisNacimientoId { get; set; }
        public int DepartamentoId { get; set; }
        public string MunicipioId { get; set; }
        public int AsesorId { get; set; }
        public int OcupacionId { get; set; }
        public int? EmpresaPlanillaId { get; set; }
        public string? DireccionLaboral { get; set; }
        public int TipoPrestamoId { get; set; }
        public string? Comentarios { get; set; }
    }
}

