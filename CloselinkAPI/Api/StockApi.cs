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
    public class StockApi : IApiAccessor
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public StockApi(Configuration configuration = null)
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
        /// Creates new Stock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Stocks to create</param>
        /// <returns>ApiResponse of List&lt;Stock&gt;</returns>
        public ApiResponse<List<Stock>> Create(List<Stock> body)
        {
            var localVarPath = "/v1/stock";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};

            object localVarPostBody = Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("Create", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Stock>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Stock>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Stock>)));
        }

        /// <summary>
        /// Creates new Stock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Stocks to create</param>
        /// <returns>Task of ApiResponse (List&lt;Stock&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Stock>>> CreateAsync(List<Stock> body)
        {
            var localVarPath = "/v1/stock";
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
                Method.POST,
                localVarQueryParams,
                localVarPostBody,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("Create", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Stock>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Stock>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Stock>)));
        }
    }
}