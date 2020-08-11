using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using RestSharp;
using NUnit.Framework;
using Moq;

using CloselinkAPI.Client;
using CloselinkAPI.Api;
using CloselinkAPI.Model;

namespace CloselinkAPI.Test
{
    [TestFixture]
    public class StockApiTests
    {
        private StockApi instance;
        private Mock<ApiClient> apiClientMock;

        [SetUp]
        public void Init()
        {
            var configuration = new Mock<Configuration>();
            apiClientMock = new Mock<ApiClient>();
            configuration.Setup(library => library.ApiClient).Returns(apiClientMock.Object);
            configuration.Setup(library => library.ApiKey).Returns("apiKey1");

            instance = new StockApi(configuration.Object);
        }

        [Test]
        public void CreateTest()
        {
            var stocks = new List<Stock>(){
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AE_CIRC
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.ME_CYL_HS
                )
            };

            Dictionary<String, String> headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            apiClientMock.Setup(library => library.CallApi("/v1/stock",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString });


            var response = instance.Create(stocks);


            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(stocks, response.Data);
        }

        [Test]
        public void CreateFailTest()
        {
            var stocks = new List<Stock>(){
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AE_CIRC
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.ME_CYL_HS
                )
            };

            Dictionary<String, String> headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            apiClientMock.Setup(library => library.CallApi("/v1/stock",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });


            Assert.Throws<ApiException>(() => instance.Create(stocks));
        }

        [Test]
        public async Task CreateAsyncTest()
        {
            List<Stock> stocks = new List<Stock>(){
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AE_CIRC
                ),
                new Stock(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.ME_CYL_HS
                )
            };

            Dictionary<String, String> headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"dateMeasured\":\"2020-01-01T01:00:00+01:00\",\"quantity\":5000,\"oilType\":\"AE_CIRC\"},{\"imo\":\"imo2\",\"dateMeasured\":\"2020-02-01T01:00:00+01:00\",\"quantity\":7000,\"oilType\":\"ME_CYL_HS\"}]";

            apiClientMock.Setup(library => library.CallApiAsync("/v1/stock",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString }));


            var response = await instance.CreateAsync(stocks);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(stocks, response.Data);
        }

    }

}
