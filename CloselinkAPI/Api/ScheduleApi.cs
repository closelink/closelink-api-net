using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using CloselinkAPI.Client;
using CloselinkAPI.Model;

namespace CloselinkAPI.Api
{

    public interface IScheduleApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Creates new Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Schedule&gt;</returns>
        ApiResponse<List<Schedule>> Create(List<Schedule> body);

        /// <summary>
        /// Finds a Schedule by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scheduleId"></param>
        /// <returns>ApiResponse of Schedule</returns>
        ApiResponse<Schedule> Get(string scheduleId);

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
        ApiResponse<List<Schedule>> GetList(string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null);

        /// <summary>
        /// Updates future Schedules (Overrides all future Schedules)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>ApiResponse of List&lt;Schedule&gt;</returns>
        ApiResponse<List<Schedule>> Update(List<Schedule> body = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations

        /// <summary>
        /// Creates new Schedules
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Schedule&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> CreateAsync(List<Schedule> body = null);

        /// <summary>
        /// Finds a Schedule by id
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scheduleId"></param>
        /// <returns>Task of ApiResponse (Schedule)</returns>
        System.Threading.Tasks.Task<ApiResponse<Schedule>> GetAsync(string scheduleId);

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
        System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> GetListAsync(string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null);

        /// <summary>
        /// Updates future Schedules (Overrides all future Schedules)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="CloselinkAPI.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="body"> (optional)</param>
        /// <returns>Task of ApiResponse (List&lt;Schedule&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> UpdateAsync(List<Schedule> body);
        #endregion Asynchronous Operations
    }

    public partial class ScheduleApi : IScheduleApi
    {
        private CloselinkAPI.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ScheduleApi(String basePath)
        {
            this.Configuration = new CloselinkAPI.Client.Configuration { BasePath = basePath };

            ExceptionFactory = CloselinkAPI.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ScheduleApi(CloselinkAPI.Client.Configuration configuration = null)
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
        public CloselinkAPI.Client.Configuration Configuration { get; set; }

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


        public ApiResponse<List<Schedule>> Create(List<Schedule> body)
        {
            var localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Create", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }



        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> CreateAsync(List<Schedule> body)
        {

            var localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Create", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }



        public ApiResponse<Schedule> Get(string scheduleId)
        {
            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null)
                throw new ApiException(400, "Missing required parameter 'scheduleId' when calling ScheduleApi->Get");

            var localVarPath = "/v1/schedule/{scheduleId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");

            if (scheduleId != null) localVarPathParams.Add("scheduleId", this.Configuration.ApiClient.ParameterToString(scheduleId)); // path parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Get", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Schedule>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Schedule)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Schedule)));
        }

        public async System.Threading.Tasks.Task<ApiResponse<Schedule>> GetAsync(string scheduleId)
        {
            // verify the required parameter 'scheduleId' is set
            if (scheduleId == null)
                throw new ApiException(400, "Missing required parameter 'scheduleId' when calling ScheduleApi->Get");

            var localVarPath = "/v1/schedule/{scheduleId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");

            if (scheduleId != null) localVarPathParams.Add("scheduleId", this.Configuration.ApiClient.ParameterToString(scheduleId)); // path parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Get", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Schedule>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Schedule)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Schedule)));
        }


        public ApiResponse<List<Schedule>> GetList(string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null)
        {

            var localVarPath = "/v1/schedule/list";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");

            if (imo != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "imo", imo)); // query parameter
            if (etaFrom != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "etaFrom", etaFrom)); // query parameter
            if (etaTo != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "etaTo", etaTo)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetList", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }



        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> GetListAsync(string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null)
        {

            var localVarPath = "/v1/schedule/list";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>();
            Object localVarPostBody = null;

            localVarHeaderParams.Add("Accept", "application/json");

            if (imo != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "imo", imo)); // query parameter
            if (etaFrom != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "etaFrom", etaFrom)); // query parameter
            if (etaTo != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "etaTo", etaTo)); // query parameter

            // authentication (apikey) required
            if (!String.IsNullOrEmpty(this.Configuration.ApiKey))
            {
                localVarHeaderParams["apikey"] = this.Configuration.ApiKey;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetList", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }

        public ApiResponse<List<Schedule>> Update(List<Schedule> body)
        {

            var localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Update", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }


        public async System.Threading.Tasks.Task<ApiResponse<List<Schedule>>> UpdateAsync(List<Schedule> body)
        {

            var localVarPath = "/v1/schedule";
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
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.PUT, localVarQueryParams, localVarPostBody, localVarHeaderParams,
                localVarPathParams, "application/json");

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("Update", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<List<Schedule>>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Schedule>)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(List<Schedule>)));
        }

    }
}
