namespace API.Dtos
{
    public class GralData
    {
        public string CodigoMoneda { get; set; } = "GTQ";
        public string FechaHoraEmision { get; set; } = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss-K");
        public string Tipo { get; set; } = "";
        public string Exportacion { get; set; } = "";
        public string NumeroAcceso { get; set; } = "";
        public string TipoPersoneria { get; set; } = "";
    }
}
