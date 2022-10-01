namespace Core.Entities
{
    public class RelacionEntidad : BaseEntity
    {
        public TipoRelacion? TipoRelacion { get; set; } 
        public int TipoRelacionId { get; set; }
        public Entidad? EntidadPadre { get; set; }
        public int EntidadPadreId { get; set; }
        public Entidad? EntidadHija { get; set; }
        public int EntidadHijaId { get; set; }
    }
}
