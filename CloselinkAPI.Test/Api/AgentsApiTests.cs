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
    public class AgentsApiTests
    {
        private AgentsApi _instance;
        private Mock<ApiClient> _apiClientMock;

        [SetUp]
        public void Init()
        {
            var configuration = new Mock<Configuration>();
            _apiClientMock = new Mock<ApiClient>();
            configuration.Setup(library => library.ApiClient).Returns(_apiClientMock.Object);
            configuration.Setup(library => library.ApiKey).Returns("apiKey1");

            _instance = new AgentsApi(configuration.Object);
        }

        [Test]
        public void CreateAgentTest()
        {
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });


            var response = _instance.CreateAgent(agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void CreateAgentFailTest()
        {
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });


            Assert.Throws<ApiException>(() => _instance.CreateAgent(agentRequest));
        }

        [Test]
        public async Task CreateAgentAsyncTest()
        {
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));


            var response = await _instance.CreateAgentAsync(agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void CreateAgentBulkTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/bulk",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });


            var response = _instance.CreateAgentBulk(agentRequests);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task CreateAgentBulkAsyncTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/bulk",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));


            var response = await _instance.CreateAgentBulkAsync(agentRequests);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void CreateAgentBulkFailTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/bulk",
                Method.POST,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });

            Assert.Throws<ApiException>(() => _instance.CreateAgentBulk(agentRequests));
        }

        [Test]
        public void FindAgentByExternalIdTest()
        {
            var externalId = "externalId1";
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/external/{externalId}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });

            var response = _instance.FindAgentByExternalId(externalId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task FindAgentByExternalIdAsyncTest()
        {
            var externalId = "externalId1";
            var agentResponse = createAgentResponse();


            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/external/{externalId}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));

            var response = await _instance.FindAgentByExternalIdAsync(externalId);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }


        [Test]
        public void FindAgentByExternalIdFailTest()
        {
            var externalId = "externalId1";
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/external/{externalId}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });

            Assert.Throws<ApiException>(() => _instance.FindAgentByExternalId(externalId));
        }

        [Test]
        public void FindAgentByIdTest()
        {
            var id = "id";
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/{id}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });

            var response = _instance.FindAgentById(id);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task FindAgentByIdAsyncTest()
        {
            var id = "id";
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/{id}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(Task.FromResult((object)new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));

            var response = await _instance.FindAgentByIdAsync(id);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void FindAgentByIdFailTest()
        {
            var id = "id";
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/{id}",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.Forbidden });

            Assert.Throws<ApiException>(() => _instance.FindAgentById(id));
        }

        [Test]
        public void FindAgentsTest()
        {
            var agentsResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentsResponse.ToJson() });

            var response = _instance.FindAgents();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentsResponse, response.Data);
        }

        [Test]
        public async Task FindAgentsAsyncTest()
        {
            var agentsResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentsResponse.ToJson() }));

            var response = await _instance.FindAgentsAsync();

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentsResponse, response.Data);
        }

        [Test]
        public void FindAgentsFailTest()
        {
            var agentsResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents",
                Method.GET,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                null,
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});

            Assert.Throws<ApiException>(() => _instance.FindAgents());
        }

        [Test]
        public void UpdateAgentTest()
        {
            var id = "id1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/{id}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });


            var response = _instance.UpdateAgent(id, agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task UpdateAgentAsyncTest()
        {
            var id = "id1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/{id}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));


            var response = await _instance.UpdateAgentAsync(id, agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void UpdateAgentFailTest()
        {
            var id = "id1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"id", id}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/{id}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});


            Assert.Throws<ApiException>(() => _instance.UpdateAgent(id, agentRequest));
        }
        
        [Test]
        public void UpdateAgentBulkTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/bulk",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });


            var response =  _instance.UpdateAgentBulk(agentRequests);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task UpdateAgentBulkAsyncTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/bulk",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));


            var response =  await _instance.UpdateAgentBulkAsync(agentRequests);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void UpdateAgentBulkFailTest()
        {
            var agentRequests = createAgentsRequest();
            var agentResponse = createAgentsResponse();

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/bulk",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                It.IsAny<Dictionary<string, string>>(),
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});

            Assert.Throws<ApiException>(() => _instance.UpdateAgentBulk(agentRequests));
        }

        [Test]
        public void UpdateAgentByExternalIdTest()
        {
            var externalId = "externalId1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/external/{externalId}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() });


            var response = _instance.UpdateAgentByExternalId(externalId, agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public async Task UpdateAgentByExternalIdAsyncTest()
        {
            var externalId = "externalId1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApiAsync("/v1/agents/external/{externalId}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(Task.FromResult((object) new RestResponse { StatusCode = HttpStatusCode.OK, Content = agentResponse.ToJson() }));


            var response = await _instance.UpdateAgentByExternalIdAsync(externalId, agentRequest);

            Assert.AreEqual(HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);
            Assert.AreEqual(agentResponse, response.Data);
        }

        [Test]
        public void UpdateAgentByExternalIdFailTest()
        {
            var externalId = "externalId1";
            var agentRequest = createAgentRequest();
            var agentResponse = createAgentResponse();

            var pathParams = new Dictionary<string, string>
            {
                {"externalId", externalId}
            };

            var headerParams = new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"apikey", "apiKey1"}
            };

            _apiClientMock.Setup(library => library.CallApi("/v1/agents/external/{externalId}",
                Method.PUT,
                It.IsAny<List<KeyValuePair<string, string>>>(),
                It.IsAny<object>(),
                headerParams,
                pathParams,
                "application/json")
            ).Returns(new RestResponse {StatusCode = HttpStatusCode.Forbidden});

            Assert.Throws<ApiException>(() => _instance.UpdateAgentByExternalId(externalId, agentRequest));
        }

        private AgentRequestMessage createAgentRequest()
        {
            return new AgentRequestMessage(
                    "Agent 1",
                    new AddressMessage(
                        "Street",
                        "1",
                        "12344",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 1",
                    "customerId1"
                );
        }

        private AgentsRequestMessage createAgentsRequest()
        {
            return new AgentsRequestMessage(
                new List<AgentRequestMessage>{
                new AgentRequestMessage(
                    "Agent 1",
                    new AddressMessage(
                        "Street",
                        "1",
                        "12344",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 1",
                    "customerId1"
                ),
                new AgentRequestMessage(
                    "Agent 2",
                    new AddressMessage(
                        "Street",
                        "2",
                        "25654",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 2",
                    "customerId2"
                )
                });
        }


        private AgentResponseMessage createAgentResponse()
        {
            return new AgentResponseMessage(
                "Agent 1",
                    new AddressMessage(
                        "Street",
                        "1",
                        "12344",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 1",
                    "customerId1"
            );
        }
        private AgentsResponseMessage createAgentsResponse()
        {
            return new AgentsResponseMessage(
                new List<AgentResponseMessage>{
                new AgentResponseMessage(
                    "Agent 1",
                    new AddressMessage(
                        "Street",
                        "1",
                        "12344",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 1",
                    "customerId1"
                ),
                new AgentResponseMessage(
                    "Agent 2",
                    new AddressMessage(
                        "Street",
                        "2",
                        "25654",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "portId1", "portId2" },
                    "Note 2",
                    "customerId2"
                )
                });
        }
    }

}