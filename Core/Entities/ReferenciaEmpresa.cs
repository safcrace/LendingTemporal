namespace Core.Entities
{
    public class ReferenciaEmpresa : BaseEntity
    {
        public Empresa? Empresa { get; set; }
        public int EmpresaId { get; set; }
        public TipoReferencia? TipoReferencia { get; set; }
        public int TipoReferenciaId { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Telefono { get; set; }
    }
}
