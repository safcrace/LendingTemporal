namespace API.Dtos
{
    public class RegionDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int NumeroDepartamentos { get; set; }
        public List<string>? NombreDepartamentos { get; set; }
        public bool Habilitado { get; set; }
    }
}
