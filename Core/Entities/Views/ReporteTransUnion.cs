using Microsoft.EntityFrameworkCore;

namespace Core.Entities.Views
{
    [Keyless]
    public class ReporteTransUnion
    {
        public string? Tipo_Registro { get; set; }
        public int Correlativo { get; set; }
        public char Tipo_Sujeto { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Nombre_Completo { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? ApellidoDeCasada { get; set; }
        public string? PrimerNombre { get; set; }
        public string? Identificacion1 { get; set; }
        public string? Identificacion2 { get; set; }
        public string? Identificacion3 { get; set; }
        public string? Identificacion4 { get; set; }
        public string? Identificacion5 { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string? Sexo { get; set; }
        public decimal DirResDivGeo1 { get; set; }
        public decimal DirResDivGeo2 { get; set; }
        public string? Direccion_Laboral { get; set; }
        public decimal DirLabDivGeo1 { get; set; }
        public decimal DirLabDivGeo2 { get; set; }
        public string? Direccion_Email { get; set; }
        public string? Telefono_Residencial { get; set; }
        public string? Telefono_Laboral { get; set; }
        public string? Telefono_Celular { get; set; }
        public string? Tipo_Obligacion { get; set; }
        public string Moneda { get; set; }
        public string Identificador_TipoCuenta { get; set; }
        public int Numero_Obligacion { get; set; }
        public DateTime Fecha_De_Apertura { get; set; }
        public DateTime Fecha_De_Vencimiento { get; set; }
        public string? Periodo_Pago { get; set; }
        public string? Estado { get; set; }
        public string? Sub_Estado { get; set; }
        public string? Calificacion { get; set; }
        public int Dias_Mora { get; set; }
        public decimal Valor_Limite { get; set; }
        public decimal Valor_Saldo_Total { get; set; }
        public decimal Valor_Saldo_Mora { get; set; }
        public decimal Valor_Cuota { get; set; }
        public string? Tipo_Deudor { get; set; }
        public string? Tipo_Garantia { get; set; }
        public string? Numero_Garantia { get; set; }
        public string? Valor_Garantia { get; set; }
        public string? Descripcion { get; set; }
        public string? Tasa_Cambio { get; set; }
        public string? Monto_Vencido { get; set; }
        public string? Monto_Pagado { get; set; }
        public string? Nuevo_Limite { get; set; }
        public string? Fecha_De_Castigo { get; set; }
    }
}
