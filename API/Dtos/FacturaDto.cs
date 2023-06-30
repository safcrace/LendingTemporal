namespace API.Dtos
{
    public class FacturaDto
    {
        public RequesterBackendRef? RequesterBackendRef { get; set; }
        public GralData? GralData { get; set; }
        public Emisor? Emisor { get; set; }
        public Receptor? Receptor { get; set; }
        public Frase? Frase { get; set; }
        public List<Detalle>? Detalle { get; set; }
        public TotalImpuestos? TotalImpuestos { get; set; }
        public GrandTotal? GranTotal { get; set; }
        public List<AbonosFacturaCambiaria>? AbonosFacturaCambiaria { get; set; }
        public ComplementoCambiaria? ComplementoCambiaria { get; set; }
        public List<Adendas>? Adendas { get; set; }
    }
}
