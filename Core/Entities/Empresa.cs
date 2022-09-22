namespace Core.Entities
{
    public class Empresa : BaseEntity
    {
        public Gestor? Gestor { get; set; }
        public int GestorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string Nit { get; set; } = null!;
    }
}
