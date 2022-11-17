namespace API.Helpers
{
    public class CalcularMora : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromHours(6));
        private readonly IHttpClientFactory _httpClientFactory;        

        public CalcularMora(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await DoWorkAsync();
            }
        }

        private /*static*/ async Task DoWorkAsync()
        {
            var client = _httpClientFactory.CreateClient("BackEndDeveloper");
            client.Timeout = TimeSpan.FromMinutes(3);
            var result = await client.GetAsync($"api/Catalogues/actualiza_dias_mora");
            Console.WriteLine(DateTime.Now.ToString("O"));            
        }
    }
}
