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
    public class ScheduleApiTests
    {
        private ScheduleApi _instance;
        private Mock<ApiClient> _apiClientMock;

        [SetUp]
        public void Init()
        {
            var configuration = new Mock<Configuration>();
            _apiClientMock = new Mock<ApiClient>();
            configuration.Setup(library => library.ApiClient).Returns(_apiClientMock.Object);
            configuration.Setup(library => library.ApiKey).Returns("apiKey1");

            _instance = new ScheduleApi(configuration.Object);
        }


        [Test]
        public void CreateTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            const string stockJsonString =
                "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            _apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.OK, Content = stockJsonString});


            var response = _instance.Create(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task CreateAsyncTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse
                {StatusCode = HttpStatusCode.OK, Content = stockJsonString}));


            var response = await _instance.CreateAsync(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void CreateFailTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };


            _apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]",
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});

            Assert.Throws<ApiException>(() => _instance.Create(schedules));
        }

        [Test]
        public void GetTest()
        {
            const string scheduleId = "id1";

            var pathParams = new Dictionary<string, string>
            {
                {"scheduleId", scheduleId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/schedule/{scheduleId}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<string>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    "{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"}"
            });

            var response = _instance.Get(scheduleId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
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
            const string scheduleId = "id1";

            var pathParams = new Dictionary<string, string>
            {
                {"scheduleId", scheduleId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule/{scheduleId}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<string>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    "{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"}"
            }));

            var response = await _instance.GetAsync(scheduleId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
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
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/schedule/list",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<string>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
            });


            var response = _instance.GetList();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task GetListAsyncTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule/list",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<string>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
            }));


            var response = await _instance.GetListAsync();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void GetListWithParamsTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var queryParams = new List<KeyValuePair<string, string>>
            {
                KeyValuePair.Create("imo", "imo1"),
                KeyValuePair.Create("etaFrom", "2020-01-01T01:00:00.0000000+01:00"),
                KeyValuePair.Create("etaTo", "2020-01-02T01:00:00.0000000+01:00")
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/schedule/list",
                Method.GET,
                queryParams,
                It.IsAny<string>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse
            {
                StatusCode = HttpStatusCode.OK,
                Content =
                    "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]"
            });


            var response = _instance.GetList("imo1", DateTime.Parse("2020-01-01T00:00:00.000Z"),
                DateTime.Parse("2020-01-02T00:00:00.000Z"));

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public void UpdateTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            _apiClientMock.Setup(library => library.CallApi("/v1/schedule",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.OK, Content = stockJsonString});


            var response = _instance.Update(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }

        [Test]
        public async Task UpdateAsyncTest()
        {
            var schedules = new List<Schedule>
            {
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

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            var stockJsonString =
                "[{\"imo\":\"imo1\",\"eta\":\"2020-01-01T01:00:00+01:00\",\"etd\":\"2020-01-04T01:00:00+01:00\",\"locode\":\"DEHAM\"},{\"imo\":\"imo2\",\"eta\":\"2020-02-01T01:00:00+01:00\",\"etd\":\"2020-02-04T01:00:00+01:00\",\"locode\":\"DEGEG\"}]";

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/schedule",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                stockJsonString,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse
                {StatusCode = HttpStatusCode.OK, Content = stockJsonString}));


            var response = await _instance.UpdateAsync(schedules);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode) response.StatusCode);
            Assert.AreEqual(schedules, response.Data);
        }
    }
}