// En WebApi/Controllers/CryptoCurrencyController.cs

using api_terrawind.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CryptoCurrencyController : ControllerBase
{
    private readonly IGetCryptoCurrenciesUseCase _getCryptoCurrenciesUseCase;

    public CryptoCurrencyController(IGetCryptoCurrenciesUseCase getCryptoCurrenciesUseCase)
    {
        _getCryptoCurrenciesUseCase = getCryptoCurrenciesUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetCryptoCurrencies()
    {
        try
        {
            var cryptoCurrencies = await _getCryptoCurrenciesUseCase.Execute();
            return Ok(cryptoCurrencies);
        }
        catch (ApplicationException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
