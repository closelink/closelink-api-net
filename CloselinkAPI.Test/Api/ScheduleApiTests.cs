using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;
using NUnit.Framework;
using Moq;

using CloselinkAPI.Client;
using CloselinkAPI.Api;
using CloselinkAPI.Model;

namespace CloselinkAPI.Test
{
    [TestFixture]
    public class ScheduleApiTests
    {
        private ScheduleApi instance;
        private Mock<ApiClient> apiClientMock;

        [SetUp]
        public void Init()
        {
            var configuration = new Mock<Configuration>();
            apiClientMock = new Mock<ApiClient>();
            configuration.Setup(library => library.ApiClient).Returns(apiClientMock.Object);
            configuration.Setup(library => library.ApiKey).Returns("apiKey1");

            instance = new ScheduleApi(configuration.Object);
        }


        [Test]
        public void CreateTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString });


            var response = instance.Create(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task CreateAsyncTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString }));


            var response = await instance.CreateAsync(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void CreateFailTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };


            apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                                                           RestSharp.Method.POST,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]",
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });

            Assert.Throws<ApiException>(() => instance.Create(schedules));
        }

        [Test]
        public void GetTest()
        {
            var scheduleId = "id1";

            var pathParams = new Dictionary<String, String>(){
                { "scheduleId", scheduleId }
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            apiClientMock.Setup(library => library.CallApi("/v1/schedule/{scheduleId}",
                                                           RestSharp.Method.GET,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           It.IsAny<string>(),
                                                           headerParams,
                                                           pathParams,
                                                           "application/json")
                                                           ).Returns(new RestResponse
                                                           {
                                                               StatusCode = HttpStatusCode.OK,
                                                               Content = "{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"}"
                                                           });

            var response = instance.Get(scheduleId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ), response.Data);
        }

        [Test]
        public async Task GetAsyncTest()
        {
            var scheduleId = "id1";

            var pathParams = new Dictionary<String, String>(){
                { "scheduleId", scheduleId }
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule/{scheduleId}",
                                                           RestSharp.Method.GET,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           It.IsAny<string>(),
                                                           headerParams,
                                                           pathParams,
                                                           "application/json")
                                                           ).Returns(Task.FromResult((object)new RestResponse
                                                           {
                                                               StatusCode = HttpStatusCode.OK,
                                                               Content = "{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"}"
                                                           }));

            var response = await instance.GetAsync(scheduleId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ), response.Data);
        }

        [Test]
        public void GetListTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            apiClientMock.Setup(library => library.CallApi("/v1/schedule/list",
                                                           RestSharp.Method.GET,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           It.IsAny<string>(),
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse
                                                           {
                                                               StatusCode = HttpStatusCode.OK,
                                                               Content = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
                                                           });


            var response = instance.GetList();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task GetListAsyncTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule/list",
                                                           RestSharp.Method.GET,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           It.IsAny<string>(),
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(Task.FromResult((object)new RestResponse
                                                           {
                                                               StatusCode = HttpStatusCode.OK,
                                                               Content = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
                                                           }));


            var response = await instance.GetListAsync();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void GetListWithParamsTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var queryParams = new List<KeyValuePair<String, String>>(){
                KeyValuePair.Create("imo", "imo1"),
                KeyValuePair.Create("etaFrom", "2020-01-01T01:00:00.0000000+01:00"),
                KeyValuePair.Create("etaTo", "2020-01-02T01:00:00.0000000+01:00")
            };

            apiClientMock.Setup(library => library.CallApi("/v1/schedule/list",
                                                           RestSharp.Method.GET,
                                                           queryParams,
                                                           It.IsAny<string>(),
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse
                                                           {
                                                               StatusCode = HttpStatusCode.OK,
                                                               Content = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
                                                           });


            var response = instance.GetList("imo1", DateTime.Parse("2020-01-01T00:00:00.000Z"), DateTime.Parse("2020-01-02T00:00:00.000Z"));

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void UpdateTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                                                           RestSharp.Method.PUT,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString });


            var response = instance.Update(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task UpdateAsyncTest()
        {
            var schedules = new List<Schedule>(){
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-01-01T00:00:00.000Z"),
                    DateTime.Parse("2020-01-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo2",
                    DateTime.Parse("2020-02-01T00:00:00.000Z"),
                    DateTime.Parse("2020-02-04T00:00:00.000Z"),
                    "DEGEG"
                )
            };

            var headerParams = new Dictionary<String, String>(){
                { "Accept", "application/json" },
                { "apikey", "apiKey1" }
            };

            var stockJsonString = "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule",
                                                           RestSharp.Method.PUT,
                                                           It.IsAny<List<KeyValuePair<String, String>>>(),
                                                           stockJsonString,
                                                           headerParams,
                                                           It.IsAny<Dictionary<String, String>>(),
                                                           "application/json")
                                                           ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = stockJsonString }));


            var response = await instance.UpdateAsync(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

    }

}
