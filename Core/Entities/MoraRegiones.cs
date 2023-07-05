namespace Core.Entities
{
    public class MoraRegiones
    {
        public TipoPrestamo TipoPrestamo { get; set; } = null!;
        public int TipoPrestamoId { get; set; }
        public Region Region { get; set; } = null!;
        public int RegionId { get; set; }
        public decimal TasaMinima { get; set; }
        public decimal TasaMaxima { get; set; }
        public decimal TasaPredeterminada { get; set; }
        public byte DiasGracia { get; set; }
        public bool Habilitado { get; set; }
    }
}
