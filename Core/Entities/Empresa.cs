namespace Core.Entities
{
    public class Empresa : BaseEntity
    {
        public Entidad? Entidad { get; set; }
        public int? EntidadId { get; set; }        
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Nit { get; set; } = null!;
    }
}
