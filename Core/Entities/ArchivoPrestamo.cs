namespace Core.Entities
{
    public class ArchivoPrestamo : BaseEntity
    {
        public Prestamo? Prestamo { get; set; }
        public int PrestamoId { get; set; }
        public string? Descripcion { get; set; }
        public int DocumentoSidId { get; set; }
        public string? NombreDocumentoSid { get; set; }
    }
}
