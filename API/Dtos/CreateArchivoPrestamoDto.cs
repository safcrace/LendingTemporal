using Core.Entities;

namespace API.Dtos
{
    public class CreateArchivoPrestamoDto : BaseEntity
    {        
        public int PrestamoId { get; set; }
        public int DocumentoSidId { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreDocumentoSid { get; set; }
        public bool Requerido { get; set; }
    }
}
