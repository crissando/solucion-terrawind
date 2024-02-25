using api_terrawind.Core.Entities;

namespace api_terrawind.Application.Interfaces
{
    public interface IGetCryptoCurrenciesUseCase
    {
        Task<CryptoCurrencyResponse> Execute();
    }
}