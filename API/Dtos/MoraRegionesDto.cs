namespace API.Dtos
{
    public class MoraRegionesDto
    {
        public int TipoPrestamoId { get; set; }
        public int RegionId { get; set; }
        public decimal TasaMinima { get; set; }
        public decimal TasaMaxima { get; set; }
        public decimal TasaPredeterminada { get; set; }
        public int DiasGracia { get; set; }
    }
}
