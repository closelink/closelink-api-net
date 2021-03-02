using System;
using System.Collections.Generic;
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
        /// <param name="body">AgentMessage</param>
        /// <returns>AgentMessage</returns>
        public ApiResponse<AgentMessage> CreateAgent(AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Create agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentMessage</param>
        /// <returns>Task of ApiResponse (AgentMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentMessage>> CreateAgentAsync(AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Create multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsMessage</param>
        /// <returns>ApiResponse of AgentsMessage</returns>
        public ApiResponse<AgentsMessage> CreateAgentBulk(AgentsMessage body)
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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Create multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsMessage</param>
        /// <returns>Task of ApiResponse (AgentsMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsMessage>> CreateAgentBulkAsync(AgentsMessage body)
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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Find agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <returns>ApiResponse of AgentMessage</returns>
        public ApiResponse<AgentMessage> FindAgentByExternalId(string externalId)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Find agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <returns>Task of ApiResponse (AgentMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentMessage>> FindAgentByExternalIdAsync(string externalId)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Find agent by ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <returns>ApiResponse of AgentMessage</returns>
        public ApiResponse<AgentMessage> FindAgentById(string id)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Find agent by ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <returns>Task of ApiResponse (AgentMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentMessage>> FindAgentByIdAsync(string id)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Find agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids">List of agent IDs (optional)</param>
        /// <param name="customerIds">List of customer IDs (optional)</param>
        /// <param name="searchQuery">Search query (optional)</param>
        /// <param name="externalIds">List of external IDs (optional)</param>
        /// <returns>ApiResponse of AgentsMessage</returns>
        public ApiResponse<AgentsMessage> FindAgents(
                List<string> ids = null, 
                List<string> customerIds = null, 
                string searchQuery = null, 
                List<string> externalIds = null
            )
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            if (ids != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "ids", ids)); // query parameter
            if (customerIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "customerIds", customerIds)); // query parameter
            if (searchQuery != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchQuery", searchQuery)); // query parameter
            if (externalIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "externalIds", externalIds)); // query parameter

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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Find agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="ids">List of agent IDs (optional)</param>
        /// <param name="customerIds">List of customer IDs (optional)</param>
        /// <param name="searchQuery">Search query (optional)</param>
        /// <param name="externalIds">List of external IDs (optional)</param>
        /// <returns>Task of ApiResponse (AgentsMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsMessage>> FindAgentsAsync(
                List<string> ids = null, 
                List<string> customerIds = null, 
                string searchQuery = null, 
                List<string> externalIds = null
            )
        {
            const string localVarPath = "/v1/agents";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> { { "Accept", "application/json" } };


            if (ids != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "ids", ids)); // query parameter
            if (customerIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "customerIds", customerIds)); // query parameter
            if (searchQuery != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "searchQuery", searchQuery)); // query parameter
            if (externalIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("multi", "externalIds", externalIds)); // query parameter

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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage)Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Update agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <param name="body">AgentMessage</param>
        /// <returns>ApiResponse of AgentMessage</returns>
        public ApiResponse<AgentMessage> UpdateAgent(string id, AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Update agent 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="id">Agent ID</param>
        /// <param name="body">AgentMessage</param>
        /// <returns>Task of ApiResponse (AgentMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentMessage>> UpdateAgentAsync(string id, AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Update multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsMessage</param>
        /// <returns>ApiResponse of AgentsMessage</returns>
        public ApiResponse<AgentsMessage> UpdateAgentBulk(AgentsMessage body)
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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Update multiple agents 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">AgentsMessage</param>
        /// <returns>Task of ApiResponse (AgentsMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentsMessage>> UpdateAgentBulkAsync(AgentsMessage body)
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

            return new ApiResponse<AgentsMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentsMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentsMessage)));
        }

        /// <summary>
        /// Update agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <param name="body">AgentMessage</param>
        /// <returns>ApiResponse of AgentMessage</returns>
        public ApiResponse<AgentMessage> UpdateAgentByExternalId(string externalId, AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

        /// <summary>
        /// Update agent by external ID 
        /// </summary>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="externalId">External ID</param>
        /// <param name="body">AgentMessage</param>
        /// <returns>Task of ApiResponse (AgentMessage)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AgentMessage>> UpdateAgentByExternalIdAsync(string externalId, AgentMessage body)
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

            return new ApiResponse<AgentMessage>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AgentMessage) Configuration.ApiClient.Deserialize(localVarResponse, typeof(AgentMessage)));
        }

    }
}
