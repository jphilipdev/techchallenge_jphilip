using Newtonsoft.Json;
using NLog;
using RaceDay.ApiProxies.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RaceDay.ApiProxies
{
    public class ApiAgent : IApiAgent
    {
        public TResponse Get<TRequest, TResponse>(TRequest request)
            where TResponse : new()
        {
            return new TResponse();
        }

        private readonly ILogger _logger;
        private static HttpClient HttpClient = new HttpClient();

        public ApiAgent()
        {
            _logger = LogManager.GetCurrentClassLogger();

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResponse> Get<TResponse>(string url)
        {
            _logger.Info($"GET {url}");

            var response = await HttpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            _logger.Info($"Response: {responseBody}");

            var result = JsonConvert.DeserializeObject<TResponse>(responseBody);

            return result;
        }
    }
}