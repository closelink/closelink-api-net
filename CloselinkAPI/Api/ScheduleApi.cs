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
    public class ScheduleApi : IApiAccessor
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ScheduleApi(Configuration configuration = null)
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
        /// Creates new Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Schedules to create</param>
        /// <returns>ApiResponse of List&lt;Schedule&gt;</returns>
        public ApiResponse<List<Schedule>> Create(List<Schedule> body)
        {
            const string localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
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

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }


        /// <summary>
        /// Creates new Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Schedules to create</param>
        /// <returns>Task of ApiResponse (List&lt;Schedule&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> CreateAsync(List<Schedule> body)
        {
            const string localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
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

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }


        /// <summary>
        /// Finds a Schedule by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scheduleId"></param>
        /// <returns>ApiResponse of Schedule</returns>
        public ApiResponse<Schedule> Get(string scheduleId)
        {
            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null)
                throw new ApiException(400, "Missing required parameter 'scheduleId' when calling ScheduleApi->Get");

            const string localVarPath = "/v1/schedule/{scheduleId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"scheduleId", Configuration.ApiClient.ParameterToString(scheduleId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};


            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("Get", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Schedule>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Schedule) Configuration.ApiClient.Deserialize(localVarResponse, typeof(Schedule)));
        }

        /// <summary>
        /// Finds a Schedule by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scheduleId"></param>
        /// <returns>Task of ApiResponse (Schedule)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Schedule>> GetAsync(string scheduleId)
        {
            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null)
                throw new ApiException(400, "Missing required parameter 'scheduleId' when calling ScheduleApi->Get");

            var localVarPath = "/v1/schedule/{scheduleId}";
            var localVarPathParams = new Dictionary<string, string>
                {{"scheduleId", Configuration.ApiClient.ParameterToString(scheduleId)}};
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("Get", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<Schedule>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Schedule) Configuration.ApiClient.Deserialize(localVarResponse, typeof(Schedule)));
        }

        /// <summary>
        /// Finds a List of Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imo">Optional imo filter (optional)</param>
        /// <param name="etaFrom">Optional eta from date filter (optional)</param>
        /// <param name="etaTo">Optional eta to date filter (optional)</param>
        /// <returns>ApiResponse of List&lt;Schedule&gt;</returns>
        public ApiResponse<List<Schedule>> GetList(string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null)
        {
            var localVarPath = "/v1/schedule/list";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};


            if (imo != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "imo", imo)); // query parameter
            if (etaFrom != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "etaFrom", etaFrom)); // query parameter
            if (etaTo != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "etaTo", etaTo)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) Configuration.ApiClient.CallApi(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("GetList", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }


        /// <summary>
        /// Finds a List of Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="imo">Optional imo filter (optional)</param>
        /// <param name="etaFrom">Optional eta from date filter (optional)</param>
        /// <param name="etaTo">Optional eta to date filter (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Schedule&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> GetListAsync(string imo = null,
            DateTime? etaFrom = null, DateTime? etaTo = null)
        {
            const string localVarPath = "/v1/schedule/list";
            var localVarPathParams = new Dictionary<string, string>();
            var localVarQueryParams = new List<KeyValuePair<string, string>>();
            var localVarHeaderParams = new Dictionary<string, string> {{"Accept", "application/json"}};


            if (imo != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "imo", imo)); // query parameter
            if (etaFrom != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "etaFrom", etaFrom)); // query parameter
            if (etaTo != null)
                localVarQueryParams.AddRange(
                    Configuration.ApiClient.ParameterToKeyValuePairs("", "etaTo", etaTo)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = Configuration.ApiKey;
            }

            // make the HTTP request
            var localVarResponse = (IRestResponse) await Configuration.ApiClient.CallApiAsync(
                localVarPath,
                Method.GET,
                localVarQueryParams,
                null,
                localVarHeaderParams,
                localVarPathParams,
                "application/json"
            );

            var localVarStatusCode = (int) localVarResponse.StatusCode;

            var exception = ExceptionFactory?.Invoke("GetList", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }

        /// <summary>
        /// Updates future Schedules (Overrides all future Schedules)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Schedules to update</param>
        /// <returns>ApiResponse of List&lt;Schedule&gt;</returns>
        public ApiResponse<List<Schedule>> Update(List<Schedule> body)
        {
            const string localVarPath = "/v1/schedule";
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

            var exception = ExceptionFactory?.Invoke("Update", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }

        /// <summary>
        /// Updates future Schedules (Overrides all future Schedules)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body">List of Schedules to update</param>
        /// <returns>Task of ApiResponse (List&lt;Schedule&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> UpdateAsync(List<Schedule> body)
        {
            const string localVarPath = "/v1/schedule";
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

            var exception = ExceptionFactory?.Invoke("Update", localVarResponse);
            if (exception != null) throw exception;

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>) Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }
    }
}