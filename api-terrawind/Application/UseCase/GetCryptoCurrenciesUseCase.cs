// En Application/UseCases/GetCryptoCurrenciesUseCase.cs

using api_terrawind.Core.Entities;
using api_terrawind.Application.Interfaces;
using api_terrawind.Infraestructure.Interfaces;

namespace api_terrawind.Application.UseCases
{
    public class GetCryptoCurrenciesUseCase : IGetCryptoCurrenciesUseCase
    {
        private readonly ICryptoCurrencyRepository _cryptoCurrencyRepository;

        public GetCryptoCurrenciesUseCase(ICryptoCurrencyRepository cryptoCurrencyRepository)
        {
            _cryptoCurrencyRepository = cryptoCurrencyRepository;
        }

        public async Task<IEnumerable<CryptoCurrency>> Execute()
        {
            try
            {
                var cryptoCurrencies = await _cryptoCurrencyRepository.GetCryptoCurrencies();
                if (cryptoCurrencies == null || !cryptoCurrencies.Any())
                {
                    throw new ApplicationException("No cryptocurrencies found.");
                }
                return cryptoCurrencies;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}

