namespace Core.Entities
{
    public class Entrevista : BaseEntity
    {
        public Prestamo? Prestamo { get; set; }
        public int? PrestamoId { get; set; }
        public string? Texto { get; set; }
    }
}
