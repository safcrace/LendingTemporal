namespace API.Dtos
{
    public class InteresesRegionesDto
    {       
        public int TipoPrestamoId { get; set; }
        public int RegionId { get; set; }
        public decimal TasaMinima { get; set; }
        public decimal TasaMaxima { get; set; }
        public decimal TasaPredeterminada { get; set; }
        public bool Habilitado { get; set; }
    }
}
