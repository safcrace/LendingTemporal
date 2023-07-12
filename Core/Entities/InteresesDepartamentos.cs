namespace Core.Entities
{
    public class InteresesDepartamentos
    {
        public TipoPrestamo? TipoPrestamo { get; set; }
        public int TipoPrestamoId { get; set; }
        public Departamento? Departamento { get; set; } 
        public int DepartamentoId { get; set; }
        public decimal TasaMinima { get; set; }
        public decimal TasaMaxima { get; set; }
        public decimal TasaPredeterminada { get; set; }
        public bool Habilitado { get; set; } = true;
    }
}
