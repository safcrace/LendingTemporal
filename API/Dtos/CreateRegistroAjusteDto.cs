namespace API.Dtos
{
    public class CreateRegistroAjusteDto
    {
        public int TipoTransaccionId { get; set; }
        public decimal MontoAjuste { get; set; }
        public DateTime FechaAjuste { get; set; }
        public string Observaciones { get; set; }
    }
}
