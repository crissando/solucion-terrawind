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
            var model = Assert.IsType<CryptoCurrencyResponse>(okResult.Value);
            Assert.Equal(8, model.data.Count);

        }

        private CryptoCurrencyResponse GetTestCryptoCurrencies()
        {
            return new CryptoCurrencyResponse
            {
                data = new List<CryptoCurrency>
                    {
                        new CryptoCurrency
                        {
                            Id = "90",
                            Symbol = "BTC",
                            Name = "Bitcoin",
                            Nameid = "bitcoin",
                            Rank = 1,
                            Price_usd = "51688.64",
                            Percent_change_24h = "2.14",
                            Percent_change_1h = "0.26",
                            Percent_change_7d = "0.63",
                            Price_btc = "1.00",
                            Market_cap_usd = "1014895635069.30",
                            Volume24 = 13904355682.326113,
                            Volume24a = 21232253337.123516,
                            Csupply = "19634790.00",
                            Tsupply = "19634790",
                            Msupply = "21000000"
                        },
                        new CryptoCurrency
                        {
                            Id = "80",
                            Symbol = "ETH",
                            Name = "Ethereum",
                            Nameid = "ethereum",
                            Rank = 2,
                            Price_usd = "3015.70",
                            Percent_change_24h = "3.62",
                            Percent_change_1h = "0.63",
                            Percent_change_7d = "9.69",
                            Price_btc = "0.058343",
                            Market_cap_usd = "369046670568.96",
                            Volume24 = 7726367478.267682,
                            Volume24a = 11791612512.493917,
                            Csupply = "122375302.00",
                            Tsupply = "122375302",
                            Msupply = ""
                        },
                        new CryptoCurrency
                        {
                            Id = "518",
                            Symbol = "USDT",
                            Name = "Tether",
                            Nameid = "tether",
                            Rank = 3,
                            Price_usd = "1.00",
                            Percent_change_24h = "-0.02",
                            Percent_change_1h = "-0.54",
                            Percent_change_7d = "0.03",
                            Price_btc = "0.000019",
                            Market_cap_usd = "90736579513.65",
                            Volume24 = 30772474134.70789,
                            Volume24a = 43996276666.70108,
                            Csupply = "90653779562.00",
                            Tsupply = "93609080552.592",
                            Msupply = ""
                        },
                        new CryptoCurrency
                        {
                            Id = "2710",
                            Symbol = "BNB",
                            Name = "Binance Coin",
                            Nameid = "binance-coin",
                            Rank = 4,
                            Price_usd = "380.25",
                            Percent_change_24h = "2.01",
                            Percent_change_1h = "-0.21",
                            Percent_change_7d = "7.10",
                            Price_btc = "0.007356",
                            Market_cap_usd = "63425492161.39",
                            Volume24 = 455875314.5370755,
                            Volume24a = 964850065.1749966,
                            Csupply = "166801148.00",
                            Tsupply = "192443301",
                            Msupply = "200000000"
                        },
                        new CryptoCurrency
                        {
                            Id = "48543",
                            Symbol = "SOL",
                            Name = "Solana",
                            Nameid = "solana",
                            Rank = 5,
                            Price_usd = "104.36",
                            Percent_change_24h = "5.78",
                            Percent_change_1h = "-0.16",
                            Percent_change_7d = "-2.48",
                            Price_btc = "0.002019",
                            Market_cap_usd = "44500161290.81",
                            Volume24 = 1008953512.6644392,
                            Volume24a = 1407908732.625645,
                            Csupply = "426405733.00",
                            Tsupply = "491561409.22682",
                            Msupply = ""
                        },
                        new CryptoCurrency
                        {
                            Id = "46971",
                            Symbol = "STETH",
                            Name = "Staked Ether",
                            Nameid = "staked-ether",
                            Rank = 6,
                            Price_usd = "3006.61",
                            Percent_change_24h = "3.42",
                            Percent_change_1h = "0.52",
                            Percent_change_7d = "9.47",
                            Price_btc = "0.058167",
                            Market_cap_usd = "27721543551.59",
                            Volume24 = 21520473.60364731,
                            Volume24a = 22534364.55320477,
                            Csupply = "9220200.00",
                            Tsupply = "9220200.1186575",
                            Msupply = "9220200.1186575"
                        },
                        new CryptoCurrency
                        {
                            Id = "33285",
                            Symbol = "USDC",
                            Name = "USD Coin",
                            Nameid = "usd-coin",
                            Rank = 7,
                            Price_usd = "1.00",
                            Percent_change_24h = "0.02",
                            Percent_change_1h = "0.00",
                            Percent_change_7d = "0.05",
                            Price_btc = "0.000019",
                            Market_cap_usd = "24076311145.74",
                            Volume24 = 2438163240.9707327,
                            Volume24a = 3806914694.6803565,
                            Csupply = "24069612011.00",
                            Tsupply = "24069612011.432",
                            Msupply = ""
                        },
                        new CryptoCurrency
                        {
                            Id = "58",
                            Symbol = "XRP",
                            Name = "XRP",
                            Nameid = "ripple",
                            Rank = 8,
                            Price_usd = "0.546109",
                            Percent_change_24h = "2.65",
                            Percent_change_1h = "0.17",
                            Percent_change_7d = "-0.43",
                            Price_btc = "0.000011",
                            Market_cap_usd = "23433278556.08",
                            Volume24 = 692340020.8622277,
                            Volume24a = 1082019486.855397,
                            Csupply = "42909539227.00",
                            Tsupply = "99991841593",
                            Msupply = "100000000000"
                        }
                    }
            };
        }
    }

}