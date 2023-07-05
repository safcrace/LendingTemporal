namespace API.Dtos
{
    public class ParametrosRegionesDto
    {
        public int TipoPrestamoId { get; set; }
        public int RegionId { get; set; }
        public bool MontoFijo { get; set; }
        public bool MontoVariable { get; set; }
        public decimal MontoMinimo { get; set; }
        public decimal MontoMaximo { get; set; }
        public decimal MontoPredeterminado { get; set; }
        public bool PlazoFijo { get; set; }
        public bool PlazoVariable { get; set; }
        public decimal PlazoMinimo { get; set; }
        public decimal PlazoMaximo { get; set; }
        public decimal PlazoPredeterminado { get; set; }
        public byte DiaInicioMes { get; set; }
        public byte DiaQuincena { get; set; }
        public byte DiaFinMes { get; set; }
    }
}
