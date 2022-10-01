using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateEmpresaDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }       
        public string? Email { get; set; }
        public string? Nit { get; set; }              
    }
}
