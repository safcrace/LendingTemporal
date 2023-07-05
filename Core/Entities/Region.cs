namespace Core.Entities
{
    public class Region : BaseEntity
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public List<Departamento>? Departamentos { get; set; }
        public ICollection<InteresesRegiones> InteresesRegiones { get; set; } = new List<InteresesRegiones>();
        public ICollection<MoraRegiones> MoraRegiones { get; set; } = new List<MoraRegiones>();
        public ICollection<ParametrosRegiones> ParametrosRegiones { get; set; } = new List<ParametrosRegiones>();
    }
}
