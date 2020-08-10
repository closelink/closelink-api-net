using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using CloselinkAPI.Client;
using CloselinkAPI.Model;

namespace CloselinkAPI.Api
{
    public interface IStockApi : IApiAccessor
    {
        #region Synchronous Operations

        /// <summary>
        /// Creates new Stock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Stock&gt;</returns>
        ApiResponse<List<Stock>> Create (List<Stock> body);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        
        /// <summary>
        /// Creates new Stock data
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Stock&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Stock>>> CreateAsync (List<Stock> body);
        #endregion Asynchronous Operations
    }

    public partial class StockApi : IStockApi
    {
        private CloselinkAPI.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockApi"/> class.
        /// </summary>
        /// <returns></returns>
        public StockApi(String basePath)
        {
            this.Configuration = new CloselinkAPI.Client.Configuration { BasePath = basePath };

            ExceptionFactory = CloselinkAPI.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StockApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public StockApi(CloselinkAPI.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = CloselinkAPI.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = CloselinkAPI.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public CloselinkAPI.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public CloselinkAPI.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }
        
        public ApiResponse< List<Stock> > Create (List<Stock> body)
        {
            var localVarPath = "/v1/stock";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");
            localVarPostBody = this.Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, 
                localVarPathParams, "application/json");

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Create", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Stock>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Stock>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Stock>)));
        }

        
        public async System.Threading.Tasks.Task<ApiResponse<List<Stock>>> CreateAsync (List<Stock> body)
        {
            var localVarPath = "/v1/stock";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");
            localVarPostBody = this.Configuration.ApiClient.Serialize(body);

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, 
                localVarPathParams, "application/json");

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Create", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Stock>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Stock>) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Stock>)));
        }

    }
}
