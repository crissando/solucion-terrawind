// En Infrastructure/ExternalServices/CryptoCurrencyRepository.cs

using api_terrawind.Core.Entities;
using Newtonsoft.Json;
using api_terrawind.Infraestructure.Interfaces;

namespace api_terrawind.Infraestructure.ExternalServices
{
    public class CryptoCurrencyRepository : ICryptoCurrencyRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public CryptoCurrencyRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ExternalServices:CryptoCurrencyApi"];
        }

        public async Task<IEnumerable<CryptoCurrency>> GetCryptoCurrencies()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var cryptoCurrencies = JsonConvert.DeserializeObject<CryptoCurrencyResponse>(response);
            return cryptoCurrencies.Data;
        }
    }

    // Clase auxiliar para deserializar la respuesta del servicio externo
    public class CryptoCurrencyResponse
    {
        public List<CryptoCurrency> Data { get; set; }
    }
}
