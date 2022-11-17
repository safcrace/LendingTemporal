namespace Core.Entities.Views
{
    public class Detalle
    {
        public int IdentificadorDeRelacion { get; set; }
        public int Tipo { get; set; }
        public string BienOServicio { get; set; } = "S";
        public int NumeroLinea { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; } = "UND";
        public string? Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public string NombreCorto1 { get; set; } = "IVA";
        public int CodigoUnidadGravable1 { get; set; }
        public decimal MontoGravable1 { get; set; }
        public string CantidadUnidadesGravables1 { get; set; } = string.Empty;
        public decimal MontoImpuesto1 { get; set; }
        public string NombreCorto2 { get; set; } = string.Empty;
        public string CodigoUnidadGravable2 { get; set; } = string.Empty;
        public string MontoGravable2 { get; set; } = string.Empty;
        public string CantidadUnidadesGravables2 { get; set; } = string.Empty;
        public string MontoImpuesto2 { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string OtrosDescuento { get; set; } = string.Empty;
    }
}
