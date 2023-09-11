namespace API.Dtos
{
    public class ArchivoPrestamoDto
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int DocumentoSidId { get; set; }
        public string? Descripcion { get; set; }
        public string? NombreDocumentoSid { get; set; }
    }
}
