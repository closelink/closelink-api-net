using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using CloselinkAPI.Client;
using CloselinkAPI.Model;


namespace CloselinkAPI.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class AgentsApi : IApiAccessor
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AgentsApi(Configuration configuration = null)
        {
            Configuration = configuration ?? Configuration.Default;
            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }

                return _exceptionFactory;
            }
            set => _exceptionFactory = value;
        }

        /// <summary>
        /// Create agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>AgentResponseMessage</returns>
        public ApiResponse<AgentResponseMessage> CreateAgent(AgentRequestMessage body)
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("CreateAgent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Create agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>Task of ApiResponse (AgentResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentResponseMessage>> CreateAgentAsync(AgentRequestMessage body)
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };

            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("CreateAgent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Create multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsRequestMessage</param>
        /// <returns>ApiResponse of AgentsResponseMessage</returns>
        public ApiResponse<AgentsResponseMessage> CreateAgentBulk(AgentsRequestMessage body)
        {
            const string localVarPath = "/v1/agents/bulk";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("CreateAgentBulk", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Create multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsRequestMessage</param>
        /// <returns>Task of ApiResponse (AgentsResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsResponseMessage>> CreateAgentBulkAsync(AgentsRequestMessage body)
        {
            const string localVarPath = "/v1/agents/bulk";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("CreateAgentBulk", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Find agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <returns>ApiResponse of AgentResponseMessage</returns>
        public ApiResponse<AgentResponseMessage> FindAgentByExternalId(string externalId)
        {
            // verify the required parameter 'externalId' is set
            if (externalId == null)
                throw new ApiException(400, "Missing required parameter 'externalId' when calling AgentsApi->FindAgentByExternalId");

            const string localVarPath = "/v1/agents/external/{externalId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"externalId", Configuration.ApiClient.ParameterToString(externalId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgentByExternalId", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Find agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <returns>Task of ApiResponse (AgentResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentResponseMessage>> FindAgentByExternalIdAsync(string externalId)
        {
            // verify the required parameter 'externalId' is set
            if (externalId == null)
                throw new ApiException(400, "Missing required parameter 'externalId' when calling AgentsApi->FindAgentByExternalId");

            const string localVarPath = "/v1/agents/external/{externalId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"externalId", Configuration.ApiClient.ParameterToString(externalId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgentByExternalId", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Find agent by ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <returns>ApiResponse of AgentResponseMessage</returns>
        public ApiResponse<AgentResponseMessage> FindAgentById(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AgentsApi->FindAgentById");

            const string localVarPath = "/v1/agents/{id}";
            var localVarPathParams = new Dictionary<string, string>
                {{"id", Configuration.ApiClient.ParameterToString(id)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgentById", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Find agent by ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <returns>Task of ApiResponse (AgentResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentResponseMessage>> FindAgentByIdAsync(string id)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AgentsApi->FindAgentById");

            const string localVarPath = "/v1/agents/{id}";
            var localVarPathParams = new Dictionary<string, string>
                {{"id", Configuration.ApiClient.ParameterToString(id)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgentById", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Find agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="customerIds">List of customer IDs (optional)</param>
        /// <param name="searchQuery">Search query (optional)</param>
        /// <param name="portIds">List of port IDs (optional)</param>
        /// <returns>ApiResponse of AgentsResponseMessage</returns>
        public ApiResponse<AgentsResponseMessage> FindAgents(
                List<string> customerIds = null,
                string searchQuery = null,
                List<string> portIds = null
            )
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            if (customerIds != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "customerIds", customerIds)); // query parameter
            if (searchQuery != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchQuery", searchQuery)); // query parameter
            if (portIds != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "portIds", portIds)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)Configuration.ApiClient.CallApi(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgents", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Find agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="customerIds">List of customer IDs (optional)</param>
        /// <param name="searchQuery">Search query (optional)</param>
        /// <param name="portIds">List of port IDs (optional)</param>
        /// <returns>Task of ApiResponse (AgentsResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsResponseMessage>> FindAgentsAsync(
                List<string> customerIds = null, 
                string searchQuery = null, 
                List<string> portIds = null
            )
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            if (customerIds != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "customerIds", customerIds)); // query parameter
            if (searchQuery != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchQuery", searchQuery)); // query parameter
            if (portIds != null)
                localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "portIds", portIds)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse)await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int)localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("FindAgents", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Update agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>ApiResponse of AgentResponseMessage</returns>
        public ApiResponse<AgentResponseMessage> UpdateAgent(string id, AgentRequestMessage body)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AgentsApi->UpdateAgent");

            const string localVarPath = "/v1/agents/{id}";
            var localVarPathParams = new Dictionary<string, string>
                {{"id", Configuration.ApiClient.ParameterToString(id)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Update agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>Task of ApiResponse (AgentResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentResponseMessage>> UpdateAgentAsync(string id, AgentRequestMessage body)
        {
            // verify the required parameter 'id' is set
            if (id == null)
                throw new ApiException(400, "Missing required parameter 'id' when calling AgentsApi->UpdateAgent");

            const string localVarPath = "/v1/agents/{id}";
            var localVarPathParams = new Dictionary<string, string>
                {{"id", Configuration.ApiClient.ParameterToString(id)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgent", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Update multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsRequestMessage</param>
        /// <returns>ApiResponse of AgentsResponseMessage</returns>
        public ApiResponse<AgentsResponseMessage> UpdateAgentBulk(AgentsRequestMessage body)
        {
            const string localVarPath = "/v1/agents/bulk";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgentBulk", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Update multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsRequestMessage</param>
        /// <returns>Task of ApiResponse (AgentsResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsResponseMessage>> UpdateAgentBulkAsync(AgentsRequestMessage body)
        {
            const string localVarPath = "/v1/agents/bulk";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgentBulk", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentsResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsResponseMessage)));
        }

        /// <summary>
        /// Update agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>ApiResponse of AgentResponseMessage</returns>
        public ApiResponse<AgentResponseMessage> UpdateAgentByExternalId(string externalId, AgentRequestMessage body)
        {
            // verify the required parameter 'externalId' is set
            if (externalId == null)
                throw new ApiException(400, "Missing required parameter 'externalId' when calling AgentsApi->UpdateAgentByExternalId");

            const string localVarPath = "/v1/agents/external/{externalId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"externalId", Configuration.ApiClient.ParameterToString(externalId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgentByExternalId", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

        /// <summary>
        /// Update agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <param name="body">AgentRequestMessage</param>
        /// <returns>Task of ApiResponse (AgentResponseMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentResponseMessage>> UpdateAgentByExternalIdAsync(string externalId, AgentRequestMessage body)
        {
            // verify the required parameter 'externalId' is set
            if (externalId == null)
                throw new ApiException(400, "Missing required parameter 'externalId' when calling AgentsApi->UpdateAgentByExternalId");

            const string localVarPath = "/v1/agents/external/{externalId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"externalId", Configuration.ApiClient.ParameterToString(externalId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};
            var localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.PUT,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("UpdateAgentByExternalId", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<AgentResponseMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentResponseMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentResponseMessage)));
        }

    }
}
