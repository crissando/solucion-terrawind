using api_terrawind.Application.Interfaces;
using api_terrawind.Core.Entities;
using api_terrawind.Infraestructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace test_api_terrawind
{
    public class CryptoCurrencyControllerTests
    {
        [Fact]
        public async Task Get_ReturnsAllCryptoCurrencies()
        {
            // Arrange
            var mockUseCase = new Mock<IGetCryptoCurrenciesUseCase>();
            mockUseCase.Setup(useCase => useCase.Execute()).ReturnsAsync(GetTestCryptoCurrencies());
            var controller = new CryptoCurrencyController(mockUseCase.Object);

            // Act
            var result = await controller.GetCryptoCurrencies();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<CryptoCurrency>>(okResult.Value);
            Assert.Equal(3, model.Count);

        }

        private List<CryptoCurrency> GetTestCryptoCurrencies()
        {
            return new List<CryptoCurrency>
        {
            new CryptoCurrency { Id = "1", Name = "Bitcoin" },
            new CryptoCurrency { Id = "2", Name = "Ethereum" },
            new CryptoCurrency { Id = "3", Name = "Ripple" }
        };
        }
    }

}