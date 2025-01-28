using System.Data;
using System.Net.Http.Json;
using WorkerCripto;

namespace WorkerCriptos
{
    public class Worker : BackgroundService
    {
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.coinalyze.net/v1/") // Cambia esto a la URL base de Coinalyze
            };
            _httpClient.DefaultRequestHeaders.Add("api_key", "a6df413e-b322-48d5-b369-c35fa7ec1559"); // Cambia el valor según sea necesario
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Llama a la API de Coinalyze
                //Ejemplo: https://api.coinalyze.net/v1/funding-rate?symbols=ETHUSD_PERP.A,PERP_BITCOIN_USDT.W
                var response = await _httpClient.GetAsync("open-interest?symbols=PERP_BITCOIN_USDT.W", stoppingToken); // Cambia el endpoint
                response.EnsureSuccessStatusCode();

                // Procesa la respuesta (ajusta el modelo a tu necesidad)
                var data = await response.Content.ReadAsStringAsync(cancellationToken: stoppingToken);
                //var data = await response.Content.ReadFromJsonAsync<List<OpenInterestResponse>>(cancellationToken: stoppingToken);

                //Logica de data
                Console.WriteLine(data);
                Library.SendTelegramMessageAsync(data);

                //int timestampfrom = DateTime.Today.AddDays(-1).ToT;

                //Delay entre ejecuciones
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}