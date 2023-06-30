namespace API.Dtos
{
    public class Detalle
    {
        public string BienOServicio { get; set; } = "";
        public string UnidadMedida { get; set; } = "";
        public string Cantidad { get; set; } = "";
        public string Descripcion { get; set; } = "";
        public string NumeroLinea { get; set; } = ""; // int
        public string PrecioUnitario { get; set; } = "";
        public string Precio { get; set; } = "";
        public string Descuento { get; set; } = "";
        public string Total { get; set; } = "";
        public string NombreCorto1 { get; set; } = "";
        public string CodigoUnidadGravable1 { get; set; } = ""; // int
        public string CantidadUnidadesGravables1 { get; set; } = "";
        public string MontoGravable1 { get; set; } = "";
        public string MontoImpuesto1 { get; set; } = "";
        public string OtrosDescuento { get; set; } = "";
        public string CodigoProducto { get; set; } = "";
    }
}
