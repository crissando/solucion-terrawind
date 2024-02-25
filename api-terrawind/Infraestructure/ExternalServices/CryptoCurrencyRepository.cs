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

        public async Task<CryptoCurrencyResponse> GetCryptoCurrencies()
        {
            var response = await _httpClient.GetStringAsync(_apiUrl);
            var cryptoCurrencyResponse = JsonConvert.DeserializeObject<CryptoCurrencyResponse>(response);
            if (cryptoCurrencyResponse == null)
            {
                throw new ("No se encontraron datos");
            }
            else
            {
                return cryptoCurrencyResponse;

            }
        }
    }

    
}
