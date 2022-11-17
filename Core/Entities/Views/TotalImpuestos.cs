namespace Core.Entities.Views
{
    public class TotalImpuestos
    {
        public int IdentificadorDeRelacion { get; set; }
        public string NombreCorto { get; set; } = "IVA";
        public decimal TotalMontoImpuesto { get; set; }
    }
}
