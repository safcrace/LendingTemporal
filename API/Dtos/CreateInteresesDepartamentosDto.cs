namespace API.Dtos
{
    public class CreateInteresesDepartamentosDto
    {
        public int TipoPrestamoId { get; set; }
        public int DepartamentoId { get; set; }
        public decimal TasaMinima { get; set; }
        public decimal TasaMaxima { get; set; }
        public decimal TasaPredeterminada { get; set; }
    }
}
