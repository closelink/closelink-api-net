using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CloselinkAPI.Api;
using CloselinkAPI.Client;
using CloselinkAPI.Model;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace CloselinkAPI.Test.Api
{
    [TestFixture]
    public class StockApiTests
    {
        private StockApi _instance;
        private Mock<ApiClient> _apiClientMock;

        [SetUp]
        public void Init()
        {
            var configuration = new Mock<Configuration>();
            _apiClientMock = new Mock<ApiClient>();
            configuration.Setup(library => library.ApiClient).Returns(_apiClientMock.Object);
            configuration.Setup(library => library.ApiKey).Returns("apiKey1");

            _instance = new StockApi(configuration.Object);
        }

        [Test]
        public void CreateTest()
        {
            var stocks = new List<Stock>
            {
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AeCirc
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.MeCylHs
                )
            };

            Dictionary<string, string> headerParams = new Dictionary<string, string>()
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            _apiClientMock.Setup(library => library.CallApi("/v1/stock",
                Method.POST,
                It.IsAny<IEnumerable<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.OK, Content = stockJsonString});


            var response = _instance.Create(stocks);


            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(stocks, response.Data);
        }

        [Test]
        public void CreateFailTest()
        {
            var stocks = new List<Stock>
            {
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AeCirc
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.MeCylHs
                )
            };

            Dictionary<string, string> headerParams = new Dictionary<string, string>()
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            _apiClientMock.Setup(library => library.CallApi("/v1/stock",
                RestSharp.Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});


            Assert.Throws<ApiException>(() => _instance.Create(stocks));
        }

        [Test]
        public async Task CreateAsyncTest()
        {
            List<Stock> stocks = new List<Stock>()
            {
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AeCirc
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.MeCylHs
                )
            };

            var headerParams = new Dictionary<string, string>()
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/stock",
                RestSharp.Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse
                {StatusCode = HttpStatusCode.OK, Content = stockJsonString}));


            var response = await _instance.CreateAsync(stocks);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(stocks, response.Data);
        }
    }
}