using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdatePersonLendingDto
    {
        [Required]
        public int personId { get; set; }
        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        [Required]
        public string NumeroDocumento { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string NumeroTelefono { get; set; }
        [Required]
        public string NIT { get; set; }
        [Required]
        public int EstadoCivilId { get; set; }
        public int AsesorId { get; set; }
        public int? EmpresaPlanillaId { get; set; }
        public int TipoPrestamoId { get; set; }
    }
}

