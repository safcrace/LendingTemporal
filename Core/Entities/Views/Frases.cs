namespace Core.Entities.Views
{
    public class Frases
    {
        public int IdentificadorDeRelacion { get; set; }
        public int TipoFrase { get; set; }
        public int CodigoEscenario { get; set; }
        public string NumeroResolucion { get; set; } = string.Empty;
        public string FechaResolucion { get; set; } = string.Empty;
    }
}
