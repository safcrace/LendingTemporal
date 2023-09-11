namespace Core.Entities.Views
{
    public class ListadoEntidades
    {
        public int EntidadId { get; set; }
        public int TipoEntidadId { get; set; }
        public string? TipoEntidad { get; set; }
        public string? NombreEntidad { get; set; }
        public string? DPI { get; set; }
        public string? NIT { get; set; }        
        public string? Telefono { get; set; }
        public string? NumeroCelular { get; set; }        
        public string? Direccion { get; set; }
    }
}
