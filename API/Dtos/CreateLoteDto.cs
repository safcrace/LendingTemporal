namespace API.Dtos
{
    public class CreateLoteDto
    {
        public string? AppUserId { get; set; }
        public int TotalCreditos { get; set; }
        public string? TipoLote { get; set; }
        public List<CreateDetalleLoteDto>? DetalleLotes { get; set; }
    }
}
