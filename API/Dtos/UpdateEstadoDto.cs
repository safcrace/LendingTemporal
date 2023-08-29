using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UpdateEstadoDto
    {
        [Required]
        public int PrestamoId { get; set; }
        [Required]
        public int NuevoEstadoId { get; set; }
        [Required]
        public string? AppUserId { get; set; }
        public int? MotivoRechazoId { get; set; } = 0;
        public string? Comentario { get; set; }
    }
}
