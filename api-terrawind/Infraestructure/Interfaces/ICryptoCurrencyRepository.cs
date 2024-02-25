using api_terrawind.Core.Entities;

namespace api_terrawind.Infraestructure.Interfaces
{
    public interface ICryptoCurrencyRepository
    {
        Task<CryptoCurrencyResponse> GetCryptoCurrencies();
    }
}

