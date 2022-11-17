namespace Core.Entities.Views
{
    public class Encabezado
    {
        public int IdentificadorDeRelacion { get; set; }
        public string CodigoMoneda { get; set; } = "GTQ";
        public DateTime FechaHoraEmision { get; set; }
        public string Exp { get; set; } = string.Empty;
        public string NumeroAcceso { get; set; } = string.Empty;
        public string Tipo { get; set; } = "FACT";
        public string AfiliacionIVA { get; set; } = "GEN";
        public string CodigoEstablecimiento { get; set; } = "1";
        public string? CorreoEmisor { get; set; }
        public string? NITEmisor { get; set; }
        public string? NombreComercial { get; set; }
        public string? NombreEmisor { get; set; }
        public string? EMISORDireccion { get; set; }
        public string? EMISORCodigoPostal { get; set; }
        public string? EMISORMunicipio { get; set; }
        public string? EMISORDepartamento { get; set; }
        public string? EMISORPais { get; set; }
        public string? IDReceptor { get; set; }
        public string? NombreReceptor { get; set; }
        public string? CorreoReceptor { get; set; } = string.Empty;
        public string? TipoEspecial { get; set; } = string.Empty;
        public string? RECEPTORDireccion { get; set; }
        public string? RECEPTORCodigoPostal { get; set; }
        public string? RECEPTORMunicipio { get; set; }
        public string? RECEPTORDepartamento { get; set; }
        public string? RECEPTORPais { get; set; }
        public decimal GranTotal { get; set; }
        public string Identificador { get; set; } = string.Empty;
        public string TipoPersoneria { get; set; } = string.Empty;
    }
}

