namespace Core.Entities
{
    public class ContactoEmpresa : BaseEntity
    {
        public Empresa? Empresa { get; set; }
        public int? EmpresaId { get; set; }
        public Ocupacion? Ocupacion { get; set; }
        public int OcupacionId { get; set; }
        public string? Nombre { get; set; }
    }
}
